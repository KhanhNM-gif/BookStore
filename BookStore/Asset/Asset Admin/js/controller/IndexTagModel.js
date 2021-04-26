var Tag = {
    init: function () {
        this.registerEvent();
        this.ShowAlert();
    },
    registerEvent: function () {
        $(".btn_delete").click(function (event) {
            event.preventDefault();
            if (confirm("You comfirm delete ?")) {
                var ID = $(this).data('id');
                $.ajax({
                    type: "POST",
                    url: "/Tag/Delete",
                    data: { id: ID },
                    success: function (response) {
                        Layout.showArlet(response.message, response.type);
                        $('#row_' + ID).remove();
                    },
                    dataType: "json"
                });
            }

        });
    },
    ShowAlert: function () {
        $.ajax({
            type: "POST",
            url: "/BaseControl/ShowAlert",
            success: function (response) {
                console.log(response);
                if (response.isShow == true) {
                    Layout.showArlet(response.message, response.type);
                }
            },
            dataType: "json"
        });
    }
}
Tag.init();