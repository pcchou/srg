 <?php

if (isset($_GET["dlkbps"]) && isset($_GET["ulkbps"]) && isset($_GET["pingms"])) {
    $dlkbps = $_GET["dlkbps"];
    $ulkbps = $_GET["ulkbps"];
    $pingms = $_GET["pingms"];
    $srv = isset($_GET["srv"]) ? $_GET["srv"] : "2181" ;
    $accuracy = 1;
    $hash = md5($pingms . "-" . $ulkbps . "-" . $dlkbps . "-297aae72");
    $headers = Array(
            'POST /api/api.php HTTP/1.1',
            'Content-Type: application/x-www-form-urlencoded',
            'Referer: http://c.speedtest.net/flash/speedtest.swf',
    );
    $post = "download=". $dlkbps . "&ping=" . $pingms . "&upload=" . $ulkbps . "&promo=&startmode=pingselect&recommendedserverid=" . $srv . "&accuracy=1&serverid=" . $srv . "&hash=" . $hash;
    $ch = curl_init();
    curl_setopt($ch, CURLOPT_URL, 'http://www.speedtest.net/api/api.php');
    curl_setopt($ch, CURLOPT_ENCODING, "" );
    curl_setopt($ch, CURLOPT_POST, 1);
    curl_setopt($ch, CURLOPT_POSTFIELDS, $post);
    curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    curl_setopt($ch, CURLOPT_FRESH_CONNECT, 1);
    $data = curl_exec($ch);
    foreach (explode('&', $data) as $chunk) {
        $param = explode("=", $chunk);
        if (urldecode($param[0]) == "resultid"){
            $imgf = 'http://www.speedtest.net/result/' . urldecode($param[1]) . ".png";
        }
    }
    
    echo $imgf;
} else {
    trigger_error("This is madness!");
}
?> 
