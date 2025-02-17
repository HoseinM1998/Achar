var tableMain = $("#data-table").DataTable({
    dom: "Bfrtip",
    lengthChange: true,
    buttons: [
        { extend: "copy", className: "btn btn-success" },
        { extend: "csv", className: "btn btn-success" },
        { extend: "excel", className: "btn btn-success" },
        {
            extend: 'pdf',
            className: "btn btn-success",
            customize: function (doc) {
                processFont(doc);

                doc.content[0]['text'] = doc.content[0]['text'].split(' ').reverse().join(' ');
                try {                    
                    for (var i = 0; i < doc.content[1].table.body.length; i++) {
                        for (var j = 0; j < doc.content[1].table.body[i].length; j++) {
                            doc.content[1].table.body[i][j]['text'] = doc.content[1].table.body[i][j]['text'].split(' ').reverse().join(' ');
                        }
                    }
                } catch (error) {
                    console.log("Unsupported content for PDF");
                }
            }
        }
    ],
    language: language,
    "columnDefs": [{
        "targets": [4],
        "orderable": false
    }],
    "aaSorting": []
});


function processFont(doc) {
    // https://products.aspose.app/font/base64/ttf
    pdfMake.fonts = {
        IranSans: {
            normal: 'IranSans.ttf',
            bold: 'IranSans.ttf',
            italics: 'IranSans.ttf',
            bolditalics: 'IranSans.ttf'
        }
    };
    doc.defaultStyle.font = "IranSans";
}

$(window).on( 'resize', function () {
    $('#data-table').css("width", "100%");
});