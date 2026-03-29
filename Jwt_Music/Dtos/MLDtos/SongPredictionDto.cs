using Microsoft.ML.Data;

namespace Jwt_Music_Api.Dtos.MLDtos
{
    public class SongPredictionDto
    {
        // Giriş Parametreleri (Features)
        public string Genre { get; set; }
        public string Country { get; set; }
        public float Level { get; set; }
        public float ArtistId { get; set; }

        // Tahmin Etmek İstediğimiz Değer (Label)
        public float ClickCount { get; set; }
    }

    public class SongPredictionResult
    {
        [ColumnName("Score")]
        public float PredictedClickCount { get; set; }
    }
}
