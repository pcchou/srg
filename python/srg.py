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

import sys
from urllib2 import urlopen, Request
from hashlib import md5
from urlparse import parse_qs
from random import randrange
from math import floor

try:
      sys.argv[5]
except IndexError:
    srv = 2181
else:
    srv = sys.argv[5]

if sys.argv[1] == "normal":
    pingms = sys.argv[4]
    dlkbps = sys.argv[2]
    ulkbps = sys.argv[3]
elif sys.argv[1] == "smart":
    dlkbps = floor( float(sys.argv[2]) * ( 0.95 + ( float(randrange(-25000,25000)) / 1000000 )) )
    ulkbps = floor( float(sys.argv[3]) * ( 0.95 + ( float(randrange(-25000,25000)) / 1000000 )) )
    ulkbps = floor( ulkbps * ( float(randrange(9350,9650)) / 10000 ) )
    if sys.argv[4] >= 4:
        pingms = int(sys.argv[4]) + randrange(-3,10)
    else:
        pingms = sys.argv[4]
else:
    print "This is madness!"
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
