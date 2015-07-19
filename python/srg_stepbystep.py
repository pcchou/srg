#!/usr/bin/env python

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

# StepByStep Fork by BobbyHo
# http://bobbyrealms.info 
# StepByStep Version Only Support Python3

import sys
from hashlib import md5
from random import randrange
from math import floor
from urllib.request import urlopen
from urllib.request import Request
from urllib.parse import parse_qs


def main():
    global dlkbps
    global ulkbps
    unit = input('請選擇欲使用的單位，kbps或mbps:')
    if unit == 'kbps':
        pass
    elif unit == 'mbps':
        pass
    else:
        print ('單位錯誤！')
        sys.exit()

    mode = input('請選擇模式，normal或smart:')
    srv = input('請輸入伺服器ID，不指定請留白:')
    pingms = input('請輸入Ping值:')
    dlkbps = input('請輸入下載速度'+'('+unit+')'+':')
    ulkbps = input('請輸入上傳速度'+'('+unit+')'+':')

    if unit == 'kbps':
        pass
    else:
        dlkbps = int(dlkbps)*1000
        ulkbps = int(ulkbps)*1000

    if len(srv) > 0:
        pass
    else:
        srv = 2181

    if mode == "normal":
        pass    
    elif mode == "smart":

        dlkbps = floor(
            float(dlkbps) * float(randrange(9450000, 9750000)) / 10000000)
        ulkbps = floor(
            float(ulkbps) * float(randrange(9450000, 9750000)) / 10000000)
        ulkbps = floor(ulkbps * float(randrange(9350, 9650)) / 10000)
        if int(pingms) >= 4:
            pingms = int(pingms) + randrange(-3, 10)
        else:
            pass
    else:
        print("This is madness!")
        sys.exit()

    rawRequest = [
        'download=%s' % int(dlkbps),
        'ping=%s' % pingms,
        'upload=%s' % int(ulkbps),
        'promo=',
        'startmode=%s' % 'pingselect',
        'recommendedserverid=%s' % srv,
        'accuracy=%s' % 1,
        'serverid=%s' % srv,
        'hash=%s' % md5(('%s-%s-%s-%s' %
                         (pingms, int(ulkbps), int(dlkbps), '297aae72'))
                        .encode()).hexdigest()]

    req = Request('http://www.speedtest.net/api/api.php',
                  data='&'.join(rawRequest).encode())
    req.add_header('Referer', 'http://c.speedtest.net/flash/speedtest.swf')
    x = urlopen(req)
    req = x.read()
    code = x.code
    x.close()

    reqresult = parse_qs(req.decode())
    results = reqresult.get('resultid')

    print('Image: http://www.speedtest.net/result/%s.png' %
          results[0])
    print('In a webpage: http://www.speedtest.net/my-result/%s' % results[0])

if __name__ == "__main__":
    main()
