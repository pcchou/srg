#!/bin/bash
#
# Author: Denny Huang <denny0223@gmail.com>
# License: Apache License
# Added smart mode by pcchou http://about.me/pcchou

function rand(){
    echo $(awk 'BEGIN{srand();print int(rand()*(('$2')-('$1')))+('$1') }')
}

if [ $1 == "normal" ]; then
    pingms=$4
    dlkbps=$2
    ulkbps=$3
elif [ $1 == "smart" ]; then
    dlkbps=$(( $2 * ( 950000 + $(rand -30000 20000) ) / 1000000 ))
    ulkbps=$(( ( $dlkbps * $(rand 9250 9750) ) / 10000 ))
    if [ $4 -ge 4 ]; then
        pingms=$(( $4 + $(rand -3 10)))
    else
        pingms=$4
    fi
else
    echo "This is madness!"
    exit
fi
srv=${5:-2181}

hash=$(echo -n $pingms-$ulkbps-$dlkbps-297aae72 | md5sum | awk '{print $1}')
resultid=$(curl -s -d "download=$dlkbps&ping=$pingms&upload=$ulkbps&promo=&startmode=pingselect&recommendedserverid=2181&accuracy=1&serverid=$srv&hash=$hash" -e http://c.speedtest.net/flash/speedtest.swf http://www.speedtest.net/api/api.php | awk -F=\|\& '{print $2}')

echo "Image: http://www.speedtest.net/result/$resultid.png"
echo "In a webpage: http://www.speedtest.net/my-result/$resultid"
