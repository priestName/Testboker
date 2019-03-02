$(function () {
    $(".left").mouseenter(function () {
        $(".left").animate({ width: "120px" }, 500);
        $(".Content ").width("calc(100% - 120px)")
    })
    $(".left").mouseleave(function () {
        $(".left").animate({ width: "41px" }, 500);
        setTimeout(function () {
            $(".Content ").width("calc(100% - 41px)")
        }, 500)
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
        lantelCookie.set(name, "", -1);
    }
}