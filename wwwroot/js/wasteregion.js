(function () {
  const data = [
      { region: 'NCR', count: 21737457.43 },
      { region: 'CAR', count: 1970268.68 },
      { region: '1', count: 5668429.30 },
      { region: '2', count: 3816330.98 },
      { region: '3', count: 15325011.32 },
      { region: '4A', count: 21816351.80 },
      { region: '4B', count: 3472803.31 },
      { region: '5', count: 6426122.97 },
      { region: '6', count: 9174827.40 },
      { region: '7', count: 9728398.99 },
      { region: '8', count: 4685141.14 },
      { region: '9', count: 4477857.47 },
      { region: '10', count: 6151248.74 },
      { region: '11', count: 7240156.60 },
      { region: '12', count: 6433043.14 },
      { region: '13', count: 3140063.95 },
      { region: 'BARMM', count: 3758440.73 },
  ];

  new Chart(
      document.getElementById("wasteregion"),
      {
          type: "bar",
          data: {
              labels: data.map(row => row.region),
              datasets: [
                  {
                      label: 'Projected waste (tons/year) by region',
                      data: data.map(row => row.count),
                  }
              ]
          }
      }
  );
})();