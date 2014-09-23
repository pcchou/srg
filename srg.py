#!/usr/bin/env python

# by Pcchou at #ysitd at Freenode IRC
# http://about.me/pcchou

import sys
from urllib2 import urlopen, Request
from hashlib import md5
from urlparse import parse_qs

pingms = sys.argv[3]
dlkbps = sys.argv[1]
ulkbps = sys.argv[2]
try:
      sys.argv[4]
except IndexError:
    srv = 2181
else:
    srv = sys.argv[4]

rawRequest = [
    'download=%s' % dlkbps,
    'ping=%s' % pingms,
    'upload=%s' % ulkbps,
    'promo=',
    'startmode=%s' % 'pingselect',
    'recommendedserverid=%s' % srv,
    'accuracy=%s' % 1,
    'serverid=%s' % srv,
    'hash=%s' % md5(('%s-%s-%s-%s' %
                     (pingms, ulkbps, dlkbps, '297aae72'))
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
