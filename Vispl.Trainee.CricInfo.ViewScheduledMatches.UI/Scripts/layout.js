document.addEventListener('DOMContentLoaded', function () {
       var syncfusionAd = document.querySelector('div[style*="position: fixed"][style*="top: 10px"][style*="left: 10px"][style*="right: 10px"][style*="z-index: 999999999"]');
    var syncfusionAd1 = document.querySelector('div[style*="position: fixed"][style*="width: 100%"][style*="height: 100%"][style*="z-index: 99999"]');
    var syncfusionAd2 = document.querySelector('div[style*="height: 455px"][style*="width: 840px"][style*="display: block"][style*="margin: 8% auto"][style*="border-radius: 20px"]');
    console.log(syncfusionAd1);
    if (syncfusionAd) {
        syncfusionAd.remove();
       }
    if (syncfusionAd2) {
        console.log(9);
    syncfusionAd2.remove();
       }
    if (syncfusionAd1) {
        console.log(9);
    syncfusionAd1.remove();
       }
   });