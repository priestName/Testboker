$(function () {
    $(".ContentMain").height($(".ContentMain").height() - 3)
    var bannerIonhtml = "";
    var bannerIonLenght = $(".banner_Image div").length;
    for (var i = 1; i <= bannerIonLenght; i++) {
        bannerIonhtml += "<div br='" + i + "'></div>";
    }
    $(".bannerIon").html(bannerIonhtml);
    $(".banner_Image").css("width", bannerIonLenght + "00%");
    var bannerWidth = $(".banner_Image").width() / bannerIonLenght
    $(".banner_Image div").css("width", bannerWidth + "px");
    $(".bannerIon").css("margin-left", "-" + ($(".bannerIon").width()/2) + "px")
    $(".bannerIon div").click(function () {
        var bannerid = $(this).attr("br");
        $(".banner_Images").animate({ scrollLeft: (bannerWidth * (Number(bannerid) - 1)) + "px" }, 500);
    })
    var timeOff=setInterval(zidgd, 3000)
    function zidgd() {
        if ($(".banner_Images").scrollLeft() >= bannerWidth * (bannerIonLenght - 1)) {
            $(".banner_Images").animate({ scrollLeft: 0 }, 500);
        }
        else {
            $(".banner_Images").animate({ scrollLeft: "+=" + bannerWidth + "px" }, 500);
        } 
    }

    //$(".banner").hover(function () {
    //    clearInterval(timeOff)
    //}, function () {
    //    timeOff = setInterval(zidgd, 3000)
    //});
    
    var startX;
    //手指落下事件
    $(".banner_Image div").on("touchstart", function (e) {
        e.preventDefault();
        startX = e.originalEvent.changedTouches[0].pageX;
        clearInterval(timeOff)
    })
    //手指离开事件
    $(".banner_Image div").on("touchend", function (e) {
        e.preventDefault();
        moveEndX = e.originalEvent.changedTouches[0].pageX;
        if (moveEndX > startX) {
            $(".banner_Images").animate({ scrollLeft: "-=" + bannerWidth + "px" }, 500);
        } else if (moveEndX < startX) {
            $(".banner_Images").animate({ scrollLeft: "+=" + bannerWidth + "px" }, 500);
        }
        timeOff = setInterval(zidgd, 3000)
    })
    //$(".nav div").width(($(".nav").width() / $(".nav div").length) - 1)
    $(".nav div").css("line-height", ($(".nav").height() +15)+"px")

    $(".nav div").click(function () {

    })
})