$(function () {
    $(".left").mouseenter(function () {
        $(".left").stop(true, false).animate({ width: "120px" }, 500);
        $(".Content").stop(true, false).animate({ width: ($(window).width() - 120) + "px" }, 400);
    })
    $(".left").mouseleave(function () {
        $(".left").stop(true, false).animate({ width: "41px" }, 500);
        $(".Content").stop(true, false).animate({ width: ($(window).width() - 41) + "px" }, 600);
    })
    $(".Nav a").click(function () {
        $(".Default").attr("src", $(this).attr("Url"))
    })
})
var Cookie = {
    set: function (name, value, seconds) {
        seconds = seconds || 2592000;
        var expires = "";
        if (seconds != 0) {
            var date = new Date();
            date.setTime(date.getTime() + (seconds * 1000));
            expires = ";expires=" + date.toGMTString();
        }
        document.cookie = name + "=" + escape(value) + expires + ";path=/";
    },
    get: function (name) {
        var values = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
        if (values != null)
            return unescape(values[2]);
        return "";
    },
    remove: function (name) {
        Cookie.set(name, "", -1);
    }
}