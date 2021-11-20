


$(document).ready(function () {
    captureimage.init();
    $('#capture').click(
        function () {
            captureimage.initcam();
        }
    );

    $('#takesnap').click(function () {
        captureimage.take_snapshot();
    });

    $('#Upload').click(function () {
        captureimage.uploadimage();
    });
});

var captureimage = (function () {

    var init = function () {
        Webcam.set({
            width: 320,
            height: 190,
            image_format: 'jpeg',
            jpeg_quality: 90
        });
    };

    var initcam = function () {
        Webcam.attach('#my_camera');
    }
    var take_snapshot=function () {

        // take snapshot and get image data
        Webcam.snap(function (data_uri) {
            // display results in page
            //document.getElementById('PhotoPathimg').innerHTML =
            //    '<img id="uploadedimage" class="uploadedimage" src="' + data_uri + '"/>';
            $('#uploadedimage').attr('src', data_uri);
        });

    }
    var uploadimage = function () {
        var data_uri = $('#uploadedimage').attr('src');
        Webcam.upload(data_uri, '/Application/Capture', function (data, code) {
            $('#PhotoPath').val(code);
        });
    }
    return {
        init: init,
        take_snapshot: take_snapshot,
        initcam: initcam,
        uploadimage: uploadimage
    }
})();