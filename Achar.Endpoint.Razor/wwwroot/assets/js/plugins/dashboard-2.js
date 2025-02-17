$(function () {
    "use strict";

    Morris.Area({
        element: 'revenue-chart',
        data: [{
            period: '1389',
            SiteA: 0,
            SiteB: 0,
            
        }, {
            period: '1388',
            SiteA: 130,
            SiteB: 100,
            
        }, {
            period: '1391',
            SiteA: 80,
            SiteB: 60,
            
        }, {
            period: '1393',
            SiteA: 70,
            SiteB: 200,
            
        }, {
            period: '1396',
            SiteA: 180,
            SiteB: 150,
            
        }, {
            period: '1394',
            SiteA: 105,
            SiteB: 90,
            
        },
         {
            period: '1395',
            SiteA: 250,
            SiteB: 150,
           
        }],
        xkey: 'period',
        ykeys: ['SiteA', 'SiteB'],
        labels: ['بازدید یک', 'بازدید دوم'],
        pointSize: 0,
        fillOpacity: 0.4,
        pointStrokeColors:['#b4becb', '#009efb'],
        behaveLikeLine: true,
        gridLineColor: '#e0e0e0',
        lineWidth: 0,
        smooth: false,
        hideHover: 'auto',
        lineColors: ['#b4becb', '#f45ca1'],
        resize: true
        
    });


}); 