var Category = {
    init: function () {
        this.registerEvent();
        this.ShowAlert();
    },
    registerEvent: function () {
        $(".btn_active").off('click').on('click', function (e) {
            e.preventDefault();
            var ID = $(this).data('id');
            var btn = $(this);
            $.ajax({
                type: "POST",
                url: "/Category/ChangeStatus",
                data: { id: ID },
                success: function (response) {
                    console.log(response);
                    if (response.status) {
                        btn.text("Active");
                    }
                    else btn.text("Block");
                },
                dataType: "json"
            });

        });
        $(".btn_delete").click(function (event) {
            event.preventDefault();
            if (confirm("You comfirm delete ?")) {
                var ID = $(this).data('id');
                
                $.ajax({
                    type: "POST",
                    url: "/Category/Delete",
                    data: { id: ID },
                    success: function (response) {
                        console.log(response);
                        Layout.showArlet(response.message, response.type);
                        if (response.isDelete) {
                            $('#row_' + ID).remove();
                        }
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
Category.init();