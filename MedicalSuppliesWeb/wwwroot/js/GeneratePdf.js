document.getElementById('generatePdf').addEventListener('click', function () {
    var htmlContent = document.getElementById('pdfContent').innerHTML;
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/Home/GeneratePDF", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.responseType = 'blob';

    xhr.onload = function (event) {
        if (xhr.status === 200) {
            var blob = xhr.response;
            var link = document.createElement('a');
            link.href = window.URL.createObjectURL(blob);
            link.download = 'output.pdf';
            link.click();
        } else {
            console.log("Failed to generate PDF: " + xhr.status + " " + xhr.statusText);
        }
    };

    xhr.send("htmlContent=" + encodeURIComponent(htmlContent));
});