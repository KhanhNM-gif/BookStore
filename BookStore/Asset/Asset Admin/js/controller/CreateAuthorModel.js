$(document).ready(function () {
    CKEDITOR.replace('Detail');
    $('#selectImage').click(function () {
        var ckFinder = new CKFinder();
        ckFinder.selectActionFunction = function (url) {
            $('#imageShow').removeClass('hide');
            $('#Image').val(url);
            $('#imageShow').attr('src', url);
           
        };
        ckFinder.popup();
    })
});
