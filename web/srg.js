function sub() {
    var err = 0;
    if (!isNaN($("#dlkbps").val())) {
        var dlkbps = $("#dlkbps").val();
        if (dlkbps == "") {
            dlkbps = 1000;
        }
        if (dlkbps < 0 && err != 1) {
            alert("下載速度不可為負值");
            err = 1;
        }
    } else if (err != 1) {
        alert("下載速度只可為數值");
        err = 1;
    }
    if (!isNaN($("#ulkbps").val())) {
        var ulkbps = $("#ulkbps").val();
        if (ulkbps == "") {
            ulkbps = 1000;
        }
        if (ulkbps < 0 && err != 1) {
            alert("上傳速度不可為負值");
            err = 1;
        }
    } else if (err != 1) {
        alert("上傳速度只可為數值");
        err = 1;
    }
    if (!isNaN($("#pingms").val())) {
        var pingms = $("#pingms").val();
        if (pingms == "") {
            pingms = 20;
        }
        if (pingms < 0 && err != 1) {
            alert("Ping值不可為負值");
            err = 1;
        }
    } else if (err != 1) {
        alert("Ping值只可為數值");
        err = 1;
    }
    if (!($("input[name=mode]:checked").val() == undefined)) {
        var mode = $("input[name=mode]:checked").val();
    }
    if (err != 1) {
        var dir = "./";
        var page = "srg.php";
        var path = dir + page + "?mode=" + mode + "&dlkbps=" + dlkbps + "&ulkbps=" + ulkbps + "&pingms=" + pingms;
        console.log(path);
  		$.get(path, function(result){
  			$('#res').removeClass('hide');
    		$('#img').attr('src',result);
            $('#link').attr('href',result);
            $('#link').html(result);
            var $body = (window.opera) ? (document.compatMode == "CSS1Compat" ? $('html') : $('body')) : $('html,body');
            $body.animate({
                scrollTop: 700
            }, 1000);
            console.log(result);
  		});
    }
}