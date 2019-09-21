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

Date.prototype.Format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1,               //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

