#!/bin/bash
#
# Author: Denny Huang <denny0223@gmail.com>
# License: Apache License

pingms=$3
dlkbps=$1
ulkbps=$2
srv=${4:-2181}
hash=$(echo -n $pingms-$ulkbps-$dlkbps-297aae72 | md5sum | awk '{print $1}')

resultid=$(curl -s -d "download=$dlkbps&ping=$pingms&upload=$ulkbps&promo=&startmode=pingselect&recommendedserverid=2181&accuracy=1&serverid=$srv&hash=$hash" -e http://c.speedtest.net/flash/speedtest.swf http://www.speedtest.net/api/api.php | awk -F=\|\& '{print $2}')

echo "Image: http://www.speedtest.net/result/$resultid.png"
echo "In a webpage: http://www.speedtest.net/my-result/$resultid"
