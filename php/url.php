 <?php

# Licensed under the Apache License, Version 2.0 (the "License"); you may
# not use this file except in compliance with the License. You may obtain
# a copy of the License at
#
# http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
# WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
# License for the specific language governing permissions and limitations
# under the License.

# by Pcchou at #ysitd at Freenode IRC
# http://about.me/pcchou

$dlkbps = $_GET["dlkbps"];
$ulkbps = $_GET["ulkbps"];
$pingms = $_GET["pingms"];
$srv = isset($_GET["srv"]) ? $_GET["srv"] : "2181" ;
$accuracy = 1;
$hash = md5($pingms . "-" . $ulkbps . "-" . $dlkbps . "-297aae72");
$headers = array(
        'POST /api/api.php HTTP/1.1',
        'Content-Type: application/x-www-form-urlencoded',
        'Referer: http://c.speedtest.net/flash/speedtest.swf',
);
$post = "download=". $dlkbps . "&ping=" . $pingms . "&upload=" . $ulkbps . "&promo=&startmode=pingselect&recommendedserverid=" . $srv . "&accuracy=1&serverid=" . $srv . "&hash=" . $hash;
$curl = curl_init();
curl_setopt($curl, CURLOPT_URL, 'http://www.speedtest.net/api/api.php');
curl_setopt($curl, CURLOPT_ENCODING, "" );
curl_setopt($curl, CURLOPT_POST, 1);
curl_setopt($curl, CURLOPT_POSTFIELDS, $post);
curl_setopt($curl, CURLOPT_HTTPHEADER, $headers);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
curl_setopt($curl, CURLOPT_FRESH_CONNECT, 1);
$results = curl_exec($curl);
foreach (explode('&', $results) as $result) {
    $data = explode("=", $result);
    if (urldecode($data[0]) == "resultid"){
        $imgf = 'http://www.speedtest.net/result/' . urldecode($data[1]) . ".png";
    }
}

echo $imgf;
?>
