var Layout = {
    init: function () {
        this.QuantityUpdate();
        this.CheckLogin();
        $('#myModal').modal('show');
    },
    QuantityUpdate: function () {
        var e = $('.cart-quantity');
        $.ajax({
            type: "POST",
            url: "/Cartt/UpdateQuantityItem",
            success: function (response) {
                e.text(response.quantity);
            },
            dataType: "json"
        });
    },
    Event: function () {
        $("a[href^='#']").click(function (e) {
            e.preventDefault();

            var position = $($(this).attr("href")).offset().top - 100;

            $("body, html").animate({
                scrollTop: position
            }, 500);
        });

        $(".txtSearch").focus(function () {
            $(this).autocomplete({
                minLength: 0,
                source: function (request, response) {
                    $.ajax({
                        url: "ProductCategory/ListName",
                        type: "POST",
                        dataType: "json",
                        data: {
                            term: request.term
                        },
                        success: function (res) {
                            response(res.data);
                        }
                    });
                },
                click: function (event, ui) {
                    $(this).val(ui.item.label);
                    return false;
                },
                select: function (event, ui) {
                    $(this).val(ui.item.label);
                    return false;
                }
            })
                .autocomplete("instance")._renderItem = function (ul, item) {
                    return $("<li>")
                        .append("<div>" + item.label + "</div>")
                        .appendTo(ul);
                };
        });
        $(".drop").off('click').on('click', function (e) {
            e.preventDefault();
            console.log('status');
            if ($(this).data('status') == 1) {
                $(this).data('status', 0);
                $(this).find('.fa').addClass('fa-caret-right').removeClass('fa-caret-down');
                $(this).parents().eq(0).find('.ListDrop').attr('style', 'display:none');
            }
            else {
                $(this).data('status', 1);
                $(this).find('.fa').removeClass('fa-caret-right').addClass('fa-caret-down');
                $(this).parents().eq(0).find('.ListDrop').attr('style', 'display:block');
            }

        });
        $("#log-out").click(function (e) {
            $.ajax({
                url: "Account/Logout",
                type: "POST",
                dataType: "json",
                success: function (res) {
                    window.location.href = "/trang-chu";
                }
            });

        });
    },
    animateAddCart: function (e) {
        var cart = $('.quantityMS');
        if (cart.is(':visible') == false) {
            cart = $('.quantityHeardMS');
        }
        var imgtodrag = e.parents().eq(2).find("img");
        if (imgtodrag) {
            var imgclone = imgtodrag.clone()
                .offset({
                    top: e.offset().top - 10,
                    left: e.offset().left
                })
                .css({
                    'opacity': '0.5',
                    'position': 'absolute',
                    'height': '150x',
                    'width': '120px',
                    'z-index': '100'
                })
                .appendTo($('body'))
                .animate({
                    'top': cart.offset().top + 10,
                    'left': cart.offset().left + 10,
                    'width': 75,
                    'height': 75
                }, 1000, 'easeInOutExpo');

            setTimeout(function () {
                cart.effect("shake", {
                    times: 2
                }, 150);
            }, 1500);
            console.log(imgclone);
            imgclone.animate({
                'width': 0,
                'height': 0
            }, function () {
                $(this).detach()
            });
        }
    },
    CheckLogin: function () {
        $.ajax({
            type: "POST",
            url: "/Account/CheckLogin",
            success: function (response) {
                if (response.isLogin) {
                    $('.account').remove();
                    $('.header-right ul')
                        .append('<li class="text-center border-right text-white class">' +
                            '<a href="#" class="text-white">Chào ' + response.name + ' !</a></li>')
                        .append('<li id="login" class="text-center border-right text-white">' +
                            '<a href="/trang-chu" id="log-out" class="text-white"><i class="fas fa-sign-out-alt mr-2"></i>Đăng xuất</a></li>');
                }
                else {
                    $('.account').remove();
                    $('.header-right ul')
                        .append('<li  class="text-center border-right text-white account"><a href="#" data-toggle="modal" data-target="#exampleModal" class="text-white" ><i class="fas fa-sign-in-alt mr-2"></i>Đăng Nhập</a></li>')
                        .append('<li class="text-center account"><a href="/tao-tai-khoan" class="text-white" >Tạo Tài Khoản</a></li>');
                }
                Layout.Event();
            },
            dataType: "json"
        });
    }
}
Layout.init();
