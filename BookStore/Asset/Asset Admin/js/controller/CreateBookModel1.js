var UpdateBook = {
    init: function () {
        CKEDITOR.replace('Detail');
        this.registerEvent();
        this.SetListCategories($('#IDRootCategory').val(),$('#IDCategorys').val(),true);
    },
    registerEvent: function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $(".dropdown-menu li").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
        $('#selectImage').click(function () {
            var ckFinder = new CKFinder();
            ckFinder.selectActionFunction = function (url) {
                $('#imageShow').removeClass('hide');
                $('#Image').val(url);
                $('#imageShow').attr('src', url);
            };
            ckFinder.popup();
        });
        $("#dropdown-categoryChildren").on('click', function (event) {
            event.stopPropagation();
        });
        $('.check_box').change(function () {
            var stringView = $("#ViewCategorys").val();
            var stringViewTg = $(this).data('text');
            var stringID = $("#IDCategorys").val();
            var stringIDTg = $(this).data('id');
            if ($(this).is(":checked")==false) {
                var reView1 = new RegExp('^' + stringViewTg + ',|,' + stringViewTg + '$|^' + stringViewTg + '$');
                var reView2 = new RegExp(',' + stringViewTg + ',');
                $("#ViewCategorys").val(stringView.replace(reView1, "").replace(reView2, ","));
                var reID1 = new RegExp('^' + stringIDTg + ',|,' + stringIDTg + '$|^' + stringIDTg + '$');
                var reID2 = new RegExp(',' + stringIDTg + ',');
                $("#IDCategorys").val(stringID.replace(reID1, "").replace(reID2, ","));
            }
            else {
                if (stringID.length > 0) {
                    $("#ViewCategorys").val(stringView + ',' + stringViewTg);
                    $("#IDCategorys").val(stringID + ',' + stringIDTg);
                }
                else {
                    $("#ViewCategorys").val(stringViewTg);
                    $("#IDCategorys").val(stringIDTg);
                }
                
            }
        }),
        $("#IDRootCategory").change(function () {
                $("#ViewCategorys").val(null);
                var stringID = $("#IDCategorys").val(null);
                UpdateBook.SetListCategories($('#IDRootCategory').val(), "NaN",false);
        });
    },
    SetTextCategory: function () {
        var list = $('.check_box');
        var string = "";
        
        $.each(list, function (key, value) {
            if ($(this).is(':checked')) {
                if (string == "") {
                    string = $(this).data('text');
                }
                else {
                    string += ',' + $(this).data('text');
                }
            }
        });
        $("#ViewCategorys").val(string);
    },
    SetListCategories: function (idParent, idChilrenCategories,isSetText) {
        $.ajax({
            type: "POST",
            url: "/Book/ChildrenCategories",
            data: { IDParent: idParent, IDChilrenCategories:idChilrenCategories },
            success: function (response) {
                var list = JSON.parse(response.list);
                var e = $('#dropdown-categoryChildren');              
                $('.item-DropDown').remove();
                $.each(list, function (i, item) {
                    e.append('<li class="item-DropDown"><a href="#">' + item.Text + '<input type="checkbox" class="check_box pull-right"' + (item.isSelect == true ? " checked " : " ") + 'data-text="' + item.Text + '" data-id='+item.ID+'></a></li>');
                })
                UpdateBook.registerEvent();
                if (isSetText) UpdateBook.SetTextCategory();
            },
            dataType: "json"
           
        });
    }
};

UpdateBook.init();


