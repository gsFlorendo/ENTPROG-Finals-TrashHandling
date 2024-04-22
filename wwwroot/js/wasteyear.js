(function () {
    const data = {
      labels: ['2020', '2021', '2022', '2023', '2024', '2025'],
      datasets: [
        {
          label: 'Projected Waste (tons/year)',
          data: [21425395.63, 21843798.09, 22271691.06, 22709320.54, 23156939.68, 23614808.97],
          fill: false,
          tension: 0.1,
          pointStyle: 'circle',
          pointRadius: 5,
          pointHoverRadius: 10
        }
      ]
    };
  
    const config = {
      type: 'line',
      data: data,
      options: {
        responsive: true,
        plugins: {
          title: {
            display: true,
            text: ''
          },
          legend: {
            display: true
          }
        }
      }
    };
  
    new Chart(
      document.getElementById('wasteyear'),
      config
    );
  })();
  