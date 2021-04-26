var Home = {
    init: function () {
        this.registerEvent();
    },
    registerEvent: function () {
        $(".btn-add-item-to-cart").off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            $.ajax({
                type: "POST",
                url: "/Cartt/AddCart",
                data: { IDBook: $(this).data('id'), quantity: $(this).data('quantity') },
                success: function (response) {
                    Layout.QuantityUpdate();
                    Layout.animateAddCart(btn);
                },
                dataType: "json"
            });
        });

    }
    
}
Home.init();
