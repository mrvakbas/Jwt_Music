/* ── app.js ── */

// ── Sidebar toggle (desktop: collapse/expand, mobile: slide in/out) ──
const sidebar = document.getElementById('sidebar');
const overlay = document.getElementById('sidebarOverlay');
const toggleBtn = document.getElementById('sidebarToggle');
const hamburgerBtn = document.getElementById('hamburger');
const MOBILE_BP = 768;

function isMobile() {
  return window.innerWidth <= MOBILE_BP;
}

// Desktop collapse/expand
if (toggleBtn) {
  toggleBtn.addEventListener('click', () => {
    if (isMobile()) return;
    sidebar.classList.toggle('collapsed');
    updateToggleIcon();
  });
}

// Mobile hamburger open
if (hamburgerBtn) {
  hamburgerBtn.addEventListener('click', () => {
    sidebar.classList.add('mobile-open');
    overlay.classList.add('visible');
  });
}

// Overlay close
if (overlay) {
  overlay.addEventListener('click', closeMobileSidebar);
}

function closeMobileSidebar() {
  sidebar.classList.remove('mobile-open');
  overlay.classList.remove('visible');
}

function updateToggleIcon() {
  const icon = toggleBtn.querySelector('svg');
  if (!icon) return;
  if (sidebar.classList.contains('collapsed')) {
    icon.innerHTML = '<line x1="3" y1="6" x2="13" y2="6"/><line x1="3" y1="11" x2="13" y2="11"/>';
  } else {
    icon.innerHTML = '<line x1="3" y1="6" x2="13" y2="6"/><line x1="3" y1="11" x2="9" y2="11"/><polyline points="7,9 9,11 7,13"/>';
  }
}

// Reset sidebar state on resize
window.addEventListener('resize', () => {
  if (!isMobile()) {
    sidebar.classList.remove('mobile-open');
    overlay.classList.remove('visible');
  }
});

// ── Nav active state ──
document.querySelectorAll('.nav-item').forEach(item => {
  item.addEventListener('click', () => {
    document.querySelectorAll('.nav-item').forEach(i => i.classList.remove('active'));
    item.classList.add('active');
    if (isMobile()) closeMobileSidebar();
  });
});

// ── Tab switch ──
window.switchTab = function(el, view) {
  document.querySelectorAll('.tab').forEach(t => t.classList.remove('active'));
  el.classList.add('active');
  document.getElementById('view-bar').style.display = view === 'bar' ? 'block' : 'none';
  document.getElementById('view-progress').style.display = view === 'progress' ? 'flex' : 'none';
};

// ── Charts ──
const MONTHS = ['Eki', 'Kas', 'Ara', 'Oca', 'Şub', 'Mar'];

// Sparklines
const sparkData = [
  [52, 58, 55, 62, 70, 74, 78, 84],
  [9, 10, 10, 11, 11, 12, 12, 13],
  [44, 42, 41, 40, 39, 38, 38, 38],
  [230, 240, 245, 255, 260, 265, 270, 277]
];
const sparkColors = ['#378ADD', '#1D9E75', '#BA7517', '#534AB7'];

sparkData.forEach((d, i) => {
  const canvas = document.getElementById('spark' + (i + 1));
  if (!canvas) return;
  new Chart(canvas, {
    type: 'line',
    data: {
      labels: d.map((_, j) => j),
      datasets: [{
        data: d,
        borderColor: sparkColors[i],
        backgroundColor: 'transparent',
        tension: 0.4, pointRadius: 0, borderWidth: 1.8
      }]
    },
    options: {
      responsive: true, maintainAspectRatio: false,
      plugins: { legend: { display: false }, tooltip: { enabled: false } },
      scales: { x: { display: false }, y: { display: false } },
      animation: { duration: 900 }
    }
  });
});

// Line Chart
const lineCtx = document.getElementById('lineChart');
if (lineCtx) {
  new Chart(lineCtx, {
    type: 'line',
    data: {
      labels: MONTHS,
      datasets: [
        {
          label: 'Bu yıl',
          data: [52000, 58000, 61000, 67000, 74000, 84320],
          borderColor: '#378ADD',
          backgroundColor: 'rgba(55,138,221,0.07)',
          tension: 0.4, fill: true,
          pointRadius: 4, pointBackgroundColor: '#378ADD', borderWidth: 2
        },
        {
          label: 'Geçen yıl',
          data: [44000, 49000, 53000, 57000, 62000, 71000],
          borderColor: '#B5D4F4',
          backgroundColor: 'transparent',
          tension: 0.4, fill: false,
          pointRadius: 3, pointBackgroundColor: '#B5D4F4',
          borderWidth: 1.5, borderDash: [5, 3]
        }
      ]
    },
    options: {
      responsive: true, maintainAspectRatio: false,
      plugins: { legend: { display: false } },
      scales: {
        x: {
          grid: { display: false },
          ticks: { font: { size: 11, family: 'DM Mono' }, color: '#A8A5A2' }
        },
        y: {
          grid: { color: 'rgba(0,0,0,0.04)' },
          ticks: {
            font: { size: 11, family: 'DM Mono' }, color: '#A8A5A2',
            callback: v => (v / 1000).toFixed(0) + 'B'
          }
        }
      }
    }
  });
}

// Donut Chart
const donutCtx = document.getElementById('doughnutChart');
if (donutCtx) {
  new Chart(donutCtx, {
    type: 'doughnut',
    data: {
      labels: ['Organik', 'Direkt', 'Sosyal', 'Reklam'],
      datasets: [{
        data: [42, 27, 18, 13],
        backgroundColor: ['#378ADD', '#85B7EB', '#B5D4F4', '#D8E9F8'],
        borderWidth: 0, hoverOffset: 4
      }]
    },
    options: {
      responsive: true, maintainAspectRatio: false, cutout: '70%',
      plugins: {
        legend: { display: false },
        tooltip: { callbacks: { label: ctx => ' ' + ctx.label + ': %' + ctx.parsed } }
      }
    }
  });
}

// Bar Chart
const barCtx = document.getElementById('barChart');
if (barCtx) {
  new Chart(barCtx, {
    type: 'bar',
    data: {
      labels: MONTHS,
      datasets: [
        { label: 'Masaüstü', data: [55, 53, 52, 51, 50, 49], backgroundColor: '#378ADD', borderRadius: 3, borderSkipped: false },
        { label: 'Mobil', data: [33, 34, 35, 37, 38, 39], backgroundColor: '#85B7EB', borderRadius: 3, borderSkipped: false },
        { label: 'Tablet', data: [12, 13, 13, 12, 12, 12], backgroundColor: '#B5D4F4', borderRadius: 3, borderSkipped: false }
      ]
    },
    options: {
      responsive: true, maintainAspectRatio: false,
      plugins: { legend: { display: false } },
      scales: {
        x: { stacked: true, grid: { display: false }, ticks: { font: { size: 10, family: 'DM Mono' }, color: '#A8A5A2' } },
        y: {
          stacked: true,
          grid: { color: 'rgba(0,0,0,0.04)' },
          ticks: { font: { size: 10, family: 'DM Mono' }, color: '#A8A5A2', callback: v => v + '%' },
          max: 100
        }
      }
    }
  });
}


// Tüm kısıtlamaları kaldırıp sayfayı "düz bir kağıt" haline getirir
const style = document.createElement('style');
style.innerHTML = `
  html, body, .layout { 
    height: auto !important; 
    overflow: visible !important; 
    display: block !important; 
  }
  .main { 
    height: auto !important; 
    //overflow: visible !important; 
  }
  .sidebar { 
    position: relative !important; 
    height: ${document.querySelector('.main').scrollHeight}px !important; 
    float: left !important;
    display: block !important;
    max-height: 100% !important;
  }
  .sidebar-toggle, .sidebar-overlay { display: none !important; }
`;
document.head.appendChild(style);
console.log("Sistem kandırıldı. Şimdi eklentiyle çekebilirsin.");