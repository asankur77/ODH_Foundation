









window.addEventListener('load', provideLoadFun);


function provideLoadFun() {
   
    var elmPrintLink = document.getElementById('printTheContent');
    elmPrintLink.onclick = function (event) {
        debugger;
        event.preventDefault();
        var getHtmlToPrintElm = document.getElementById('mainBodyContent').cloneNode(true);
        var gChildNodes = getHtmlToPrintElm.childNodes;
        //alert(getHtmlToPrintElm.childNodes.length);
        //for (var El in gChildNodes) {

        //    var elm = gChildNodes[El];
        //    if (elm.nodeType == 1) {
        //        var gTagName = elm.tagName.toString().toLowerCase();
        //        if (gTagName == 'form' || gTagName == 'header') {
        //            elm.style.display = 'none';
        //        }
        //    }
        //}
        //alert(getHtmlToPrintElm.childNodes.length);
        var getHtmlToPrint = getHtmlToPrintElm.innerHTML;
        var openNewWindowForPrinting = window.open('', '', '');
        var hh = '<html><head><title>PrintThis</title><link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />' +
            '<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />' +
            '<style type="text/css"></style>'+
            '</head>';
        getHtmlToPrint = getHtmlToPrint.replace('<form', '<form style="display:none;"').replace('<header', '<header style="display:none;"');
        openNewWindowForPrinting.document.write(getHtmlToPrint);
    };
}












