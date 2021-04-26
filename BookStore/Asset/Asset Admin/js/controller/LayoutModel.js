var Layout = {
    showArlet: function (message, type) {
        $("#alertBox").removeAttr('style');
        $("#alertBox").addClass(type);
        $("#alertBox").text(message);
        $("#alertBox").removeClass('hide');
    }
};