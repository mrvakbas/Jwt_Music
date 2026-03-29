
// --- 1. GENEL AYARLAR VE VERİ HAZIRLIĞI ---
const songLabels = [];
const songData = [];
const bgColors = [];
const borderColors = [];

// 1.1. Popüler Şarkılar Verisi (Bar Chart)
@if (ViewBag.Songs != null) {
    foreach(var sarki in ViewBag.Songs)
    {
        <text>
            songLabels.push("@Html.Raw(sarki.Title)");
            songData.push(@sarki.ClickCount);
            bgColors.push('rgba(78, 115, 223, 0.5)'); // Mavi
            borderColors.push('rgba(78, 115, 223, 1)');
        </text>
    }
}

// 1.2. ML Tahminini Ekleme
@if (ViewBag.EstimatedSuccess != null && ViewBag.EstimatedSuccess != "Hesaplanamadı") {
    <text>
        songLabels.push("🤖 ML Tahmini (Yeni Şarkı)");
        let tahminSayisi = parseInt("@ViewBag.EstimatedSuccess".replace(/\./g, ''));
        songData.push(tahminSayisi);
        bgColors.push('rgba(153, 102, 255, 0.8)'); // Mor
        borderColors.push('rgba(153, 102, 255, 1)');
    </text>
}

// --- 2. GRAFİKLERİN ÇİZİLMESİ ---

// GRAFİK A: En Popüler Şarkılar (Bar Chart)
const ctxBar = document.getElementById('mySongsChart').getContext('2d');
const myBarChart = new Chart(ctxBar, {
    type: 'bar',
    data: {
        labels: songLabels,
        datasets: [{
            label: 'Tıklanma Sayısı',
            data: songData,
            backgroundColor: bgColors,
            borderColor: borderColors,
            borderWidth: 1
        }]
    },
    plugins: [ChartDataLabels],
    options: {
        maintainAspectRatio: false,
        scales: {
            y: {
                beginAtZero: true,
                grace: '15%',
                ticks: { callback: value => value.toLocaleString('tr-TR') }
            }
        },
        plugins: {
            legend: { display: false },
            datalabels: {
                anchor: 'end',
                align: 'top',
                color: '#5a5c69',
                font: { weight: 'bold', size: 11 },
                formatter: value => value.toLocaleString('tr-TR')
            }
        }
    }
});

const monthCtx = document.getElementById('monthTrendChart').getContext('2d');
new Chart(monthCtx, {
    type: 'line',
    data: {
        labels: @Html.Raw(Json.Serialize(ViewBag.MonthLabels)),
        datasets: [{
            label: 'Günlük Dinleme Sayısı',
            data: @Html.Raw(Json.Serialize(ViewBag.MonthData)),
            borderColor: '#4e73df',
            backgroundColor: 'rgba(78, 115, 223, 0.05)',
            fill: true,
            tension: 0.4,
            pointRadius: 2, // 30 gün olduğu için noktaları küçülttük
            pointHoverRadius: 5
        }]
    },
    plugins: [ChartDataLabels],
    options: {
        maintainAspectRatio: false,
        scales: {
            x: {
                grid: { display: false },
                ticks: {
                    // Kalabalık olmaması için her 3-4 günde bir tarih göster
                    maxRotation: 45,
                    autoSkip: true,
                    maxTicksLimit: 10
                }
            },
            y: { beginAtZero: true }
        },
        plugins: {
            datalabels: {
                // Sadece verisi olan (0'dan büyük) günlerde sayıları göster
                display: function (context) {
                    return context.dataset.data[context.dataIndex] > 0;
                },
                align: 'top',
                font: { size: 10 }
            }
        }
    }
});