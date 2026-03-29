using Jwt_Music.Context;
using Jwt_Music_Api.Dtos.MLDtos; // DTO'larının olduğu namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

namespace Jwt_Music_Web.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController(AppDbContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {

            // Son 30 günün tarih listesini oluştur
            var last30Days = Enumerable.Range(0, 30)
                .Select(i => DateTime.Now.Date.AddDays(-i))
                .OrderBy(date => date)
                .ToList();

            // Veritabanından son 30 günlük dinlemeleri çek ve tarihe göre grupla
            var monthlyListens = await context.UserSongHistories
                .Where(h => h.ListenedAt >= last30Days.First())
                .GroupBy(h => h.ListenedAt.Date)
                .Select(g => new { Date = g.Key, Count = g.Count() })
                .ToListAsync();

            // View'a gönderilecek etiketler (Örn: 01 Mar, 02 Mar...)
            ViewBag.MonthLabels = last30Days.Select(d => d.ToString("dd MMM")).ToList();
            // Veri olmayan günlere 0 ata
            ViewBag.MonthData = last30Days.Select(d => monthlyListens.FirstOrDefault(x => x.Date == d)?.Count ?? 0).ToList();

            // --- 1. Temel İstatistikler ---
            var maxClickValue = await context.Songs.MaxAsync(x => (int?)x.ClickCount) ?? 0;
            ViewBag.maxClick = maxClickValue.ToString("N0");
            ViewBag.albumCount = await context.Albums.CountAsync();
            ViewBag.songCount = await context.Songs.CountAsync();

            // En çok tıklanan 5 şarkı
            ViewBag.Songs = await context.Songs
                .OrderByDescending(x => x.ClickCount)
                .Take(5)
                .ToListAsync();

            // --- 2. ML.NET Tahminleme Motoru ---
            try
            {
                var mlContext = new MLContext();

                // Veritabanındaki verileri DTO'ya mapleyerek çekiyoruz
                var trainingDataList = await context.Songs.Select(s => new SongPredictionDto
                {
                    Genre = s.Genre ?? "Unknown",
                    Country = s.Country ?? "TR",
                    Level = (float)s.Level,
                    ArtistId = (float)s.ArtistId,
                    ClickCount = (float)s.ClickCount
                }).ToListAsync();

                if (trainingDataList.Count > 0)
                {
                    var trainingDataView = mlContext.Data.LoadFromEnumerable(trainingDataList);

                    // Pipeline: Stringleri encode et ve özellikleri birleştir
                    var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "ClickCount")
                        .Append(mlContext.Transforms.Categorical.OneHotEncoding("GenreEncoded", "Genre"))
                        .Append(mlContext.Transforms.Categorical.OneHotEncoding("CountryEncoded", "Country"))
                        .Append(mlContext.Transforms.Concatenate("Features", "GenreEncoded", "CountryEncoded", "Level", "ArtistId"))
                        .Append(mlContext.Regression.Trainers.FastTree());

                    // Modeli eğit
                    var model = pipeline.Fit(trainingDataView);

                    // Tahmin motorunu oluştur
                    var predictionEngine = mlContext.Model.CreatePredictionEngine<SongPredictionDto, SongPredictionResult>(model);

                    // ÖRNEK: "Pop" türünde, "TR" menşeli, 3. seviye bir şarkı tahminen kaç tık alır?
                    var sampleSong = new SongPredictionDto
                    {
                        Genre = "Pop",
                        Country = "TR",
                        Level = 3,
                        ArtistId = 1
                    };

                    var prediction = predictionEngine.Predict(sampleSong);
                    ViewBag.EstimatedSuccess = prediction.PredictedClickCount.ToString("N0");
                }
            }
            catch
            {
                // Veri yetersizse veya ML hata verirse dashboard çökmesin
                ViewBag.EstimatedSuccess = "Hesaplanamadı";
            }

            return View();
        }
    }
}