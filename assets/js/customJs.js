

   $(function(){
    'use strict'

    $('.az-sidebar .with-sub').on('click', function(e){
      e.preventDefault();
      $(this).parent().toggleClass('show');
      $(this).parent().siblings().removeClass('show');
    });

    $(document).on('click touchstart', function(e){
      e.stopPropagation();

          // closing of sidebar menu when clicking outside of it
          if(!$(e.target).closest('.az-header-menu-icon').length) {
            var sidebarTarg = $(e.target).closest('.az-sidebar').length;
            if(!sidebarTarg) {
              $('body').removeClass('az-sidebar-show');
            }
          }
        });


    $('#azSidebarToggle').on('click', function(e){
      e.preventDefault();

      if(window.matchMedia('(min-width: 992px)').matches) {
        $('.az-sidebar').toggle();
      } else {
        $('body').toggleClass('az-sidebar-show');
      }
    });


    /* ----------------------------------- */
    /* Dashboard content */

 var ctx6 = document.getElementById('chartStacked1');
    new Chart(ctx6, {
      type: 'bar',
      data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
        datasets: [{
          data: [10, 24, 20, 25, 35, 50, 20, 30, 28, 33, 45, 65],
          backgroundColor: '#6610f2',
          borderWidth: 1,
          fill: true
        },{
          data: [20, 30, 28, 33, 45, 65, 25, 35, 50, 20, 30, 28],
          backgroundColor: '#00cccc',
          borderWidth: 1,
          fill: true
        }]
      },
      options: {
        maintainAspectRatio: false,
        legend: {
          display: false,
          labels: {
            display: false
          }
        },
        scales: {
          yAxes: [{
            ticks: {
              beginAtZero:true,
              fontSize: 11
            }
          }],
          xAxes: [{
            barPercentage: 0.4,
            ticks: {
              fontSize: 11
            }
          }]
        }
      }
    });


    

    $.plot('#flotChart1', [{
      data: flotSampleData5,
      color: '#8039f4'
    }], {
      series: {
        shadowSize: 0,
        lines: {
          show: true,
          lineWidth: 2,
          fill: true,
          fillColor: { colors: [ { opacity: 0 }, { opacity: 0.12 } ] }
        }
      },
      grid: {
        borderWidth: 0,
        labelMargin: 10,
        markings: [{ color: '#70737c', lineWidth: 1, font: {color: '#000'}, xaxis: { from: 75, to: 75} }]
      },
      yaxis: { show: false },
      xaxis: {
        show: true,
        position: 'top',
        color: 'rgba(102,16,242,.1)',
        reserveSpace: false,
        ticks: [[15,'1h'],[35,'1d'],[55,'1w'],[75,'1m'],[95,'3m'], [115,'1y']],
        font: {
          size: 10,
          weight: '500',
          family: 'Roboto, sans-serif',
          color: '#999'
        }
      }
    });

    $.plot('#flotChart2', [{
      data: flotSampleData2,
      color: '#007bff'
    }], {
      series: {
        shadowSize: 0,
        lines: {
          show: true,
          lineWidth: 2,
          fill: true,
          fillColor: { colors: [ { opacity: 0 }, { opacity: 0.5 } ] }
        }
      },
      grid: {
        borderWidth: 0,
        labelMargin: 10,
        markings: [{ color: '#70737c', lineWidth: 1, font: {color: '#000'}, xaxis: { from: 75, to: 75} }]
      },
      yaxis: { show: false },
      xaxis: {
        show: true,
        position: 'top',
        color: 'rgba(102,16,242,.1)',
        reserveSpace: false,
        ticks: [[15,'1h'],[35,'1d'],[55,'1w'],[75,'1m'],[95,'3m'], [115,'1y']],
        font: {
          size: 10,
          weight: '500',
          family: 'Roboto, sans-serif',
          color: '#999'
        }
      }
    });

      $.plot('#flotChart3', [{
      data: flotSampleData5,
      color: '#00cccc'
    }], {
      series: {
        shadowSize: 0,
        lines: {
          show: true,
          lineWidth: 2,
          fill: true,
          fillColor: { colors: [ { opacity: 0.2 }, { opacity: 0.5 } ] }
        }
      },
      grid: {
        borderWidth: 0,
        labelMargin: 10,
        markings: [{ color: '#70737c', lineWidth: 1, font: {color: '#000'}, xaxis: { from: 75, to: 75} }]
      },
      yaxis: { show: false },
      xaxis: {
        show: true,
        position: 'top',
        color: 'rgba(102,16,242,.1)',
        reserveSpace: false,
        ticks: [[15,'1h'],[35,'1d'],[55,'1w'],[75,'1m'],[95,'3m'], [115,'1y']],
        font: {
          size: 10,
          weight: '500',
          family: 'Roboto, sans-serif',
          color: '#999'
        }
      }
    });

 $.plot('#flotChart4', [{
      data: flotSampleData5,
      color: '#fc0'
    }], {
      series: {
        shadowSize: 0,
        lines: {
          show: true,
          lineWidth: 2,
          fill: true,
          fillColor: { colors: [ { opacity: 0 }, { opacity: 0.12 } ] }
        }
      },
      grid: {
        borderWidth: 0,
        labelMargin: 10,
        markings: [{ color: '#70737c', lineWidth: 1, font: {color: '#000'}, xaxis: { from: 75, to: 75} }]
      },
      yaxis: { show: false },
      xaxis: {
        show: true,
        position: 'top',
        color: 'rgba(102,16,242,.1)',
        reserveSpace: false,
        ticks: [[15,'1h'],[35,'1d'],[55,'1w'],[75,'1m'],[95,'3m'], [115,'1y']],
        font: {
          size: 10,
          weight: '500',
          family: 'Roboto, sans-serif',
          color: '#999'
        }
      }
    });



    $.plot('#flotPie', [
      { label: 'Very Satisfied', data: [[1,25]], color: '#6f42c1'},
      { label: 'Satisfied', data: [[1,38]], color: '#007bff'},
      { label: 'Not Satisfied', data: [[1,20]], color: '#00cccc'},
      { label: 'Very Unsatisfied', data: [[1,15]], color: '#969dab'}
      ], {
        series: {
          pie: {
            show: true,
            radius: 1,
            innerRadius: 0.5,
            label: {
              show: true,
              radius: 3/4,
              formatter: labelFormatter
            }
          }
        },
        legend: { show: false }
      });

    function labelFormatter(label, series) {
      return '<div style="font-size:11px; font-weight:500; text-align:center; padding:2px; color:white;">' + Math.round(series.percent) + '%</div>';
    }

   
  });


 