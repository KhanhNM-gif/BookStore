var Cart = {

    init: function () {
        this.registerEvent();

    },
    registerEvent: function () {
        $(".btn-update").off('click').on('click', function (e) {
            e.preventDefault();
            var ListQuantity = $(".input-number");
            var ListItem = [];
            $.each(ListQuantity, function (i, item) {
                ListItem.push({
                    Book: {
                        ID: $(item).data('id')
                    },
                    Quantity: $(item).val()
                })
            })
            $.ajax({
                type: "POST",
                url: "/Cartt/Update",
                data: { cartModel: JSON.stringify(ListItem) },
                success: function (response) {
                    window.location.href = "/gio-hang";
                },
                dataType: "json"
            });

        });
        $(".btn-update").off('click').on('click', function (e) {
            e.preventDefault();
            var ListQuantity = $(".input-number");
            var ListItem = [];
            $.each(ListQuantity, function (i, item) {
                ListItem.push({
                    Book: {
                        ID: $(item).data('id')
                    },
                    Quantity: $(item).val()
                })
            })
            $.ajax({
                type: "POST",
                url: "/Cartt/Update",
                data: { cartModel: JSON.stringify(ListItem) },
                success: function (response) {
                    window.location.href = "/gio-hang";
                },
                dataType: "json"
            });

        });
        $("#btn-pay").off('click').on('click', function (e) {
            e.preventDefault();
            $("#form-pay").removeClass('hideMySet');
        });
        $(".btn-removeAllItemCart").off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                type: "POST",
                url: "/Cartt/RemoveAllItemCart",
                success: function (response) {
                    Layout.QuantityUpdate();
                    window.location.href = "/gio-hang";
                },
                dataType: "json"
            });
            

        });

        $(".btn-remove-item").off('click').on('click', function (e) {
            event.preventDefault();
            if (confirm("You comfirm delete ?")) {
                var ID = $(this).data('id');
            
                $.ajax({
                    type: "POST",
                    url: "/Cartt/RemoveItem",
                    data: { id: ID },
                    success: function (response) {
                        if (response.IsCartNull) {
                            window.location.href = "/gio-hang";
                        }
                        else {
                            $('#row_' + ID).remove();
                        }
                    },
                    dataType: "json"
                });
                Layout.QuantityUpdate();

            }

        });

        $('.btn-number').click(function (e) {
            e.preventDefault();

            fieldName = $(this).attr('data-field');
            type = $(this).attr('data-type');
            var input = $("input[name='" + fieldName + "']");
            var currentVal = parseInt(input.val());
            if (!isNaN(currentVal)) {
                if (type == 'minus') {

                    if (currentVal > input.attr('min')) {
                        input.val(currentVal - 1).change();
                    }
                    if (parseInt(input.val()) == input.attr('min')) {
                        $(this).attr('disabled', true);
                    }

                } else if (type == 'plus') {

                    if (currentVal < input.attr('max')) {
                        input.val(currentVal + 1).change();
                    }
                    if (parseInt(input.val()) == input.attr('max')) {
                        $(this).attr('disabled', true);
                    }

                }
            } else {
                input.val(0);
            }
        });

        $('.input-number').focusin(function () {
            $(this).data('oldValue', $(this).val());
        });
        $('.input-number').change(function () {

            minValue = parseInt($(this).attr('min'));
            maxValue = parseInt($(this).attr('max'));
            valueCurrent = parseInt($(this).val());

            name = $(this).attr('name');
            if (valueCurrent >= minValue) {
                $(".btn-number[data-type='minus'][data-field='" + name + "']").removeAttr('disabled')
            } else {
                alert('Sorry, the minimum value was reached');
                $(this).val($(this).data('oldValue'));
            }
            if (valueCurrent <= maxValue) {
                $(".btn-number[data-type='plus'][data-field='" + name + "']").removeAttr('disabled')
            } else {
                alert('Sorry, the maximum value was reached');
                $(this).val($(this).data('oldValue'));
            }


        });
        $(".input-number").keydown(function (e) {
            // Allow: backspace, delete, tab, escape, enter and .
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 ||
                // Allow: Ctrl+A
                (e.keyCode == 65 && e.ctrlKey === true) ||
                // Allow: home, end, left, right
                (e.keyCode >= 35 && e.keyCode <= 39)) {
                // let it happen, don't do anything
                return;
            }
            // Ensure that it is a number and stop the keypress
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        });
    }
}
Cart.init();
