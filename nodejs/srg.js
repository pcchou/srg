var querystring = require('querystring');
var http = require('http');
var fs = require('fs');
var crypto = require('crypto');

function getResult(options, callback) {
    options = options || {};
    
    var dlkbpsRandomizeRange = {max : 1, min : 0.8};
    var ulkbpsRandomizeRange = {max : 1, min : 0.8};
    var pingmsRandomizeRange = {max : 1.2, min : 0.8};
    
    var dlkbpsRange = {max : 1999999, min : 1};
    var ulkbpsRange = {max : 1999999, min : 1};
    var pingmsRange = {max : 65535, min : 0};
    
    
    var dlkbps = isPositive(options.download) ? Math.floor(options.download) : 200000;
    var ulkbps = isPositive(options.upload) ? Math.floor(options.upload) : 200000;
    var pingms = isPositive(options.ping) ? Math.floor(options.ping) : 40;
    var srv = isPositive(options.server) ? options.server : 5056;
    
    if (!options.noRandomize) {
        dlkbps = randomize(dlkbps, dlkbpsRandomizeRange);
        ulkbps = randomize(ulkbps, ulkbpsRandomizeRange);
        pingms = randomize(pingms, pingmsRandomizeRange);
    }
    
    dlkbps = fixRange(dlkbps, dlkbpsRange);
    ulkbps = fixRange(ulkbps, ulkbpsRange);
    pingms = fixRange(pingms, pingmsRange);
    
    function isPositive(val) {
        return typeof val === "number" && isFinite(val) && val >= 0;
    }
    
    function fixRange(val, limit) {
        if (val > limit.max) {
            return limit.max;
        }
        if (val < limit.min) {
            return limit.min;
        }
        return val;
    }
    
    function hash(parameters, algorithm, seperator) {
        seperator = seperator || "-";
        algorithm = algorithm || "md5"; 
        var str = parameters.join(seperator);
        var shasum = crypto.createHash(algorithm);
        shasum.update(encodeURIComponent(str));
        return shasum.digest('hex');
    }

    function randomize(number, range) {
        return Math.floor(number * (range.min + (range.max - range.min) * Math.random()));
    }
    
    function parse(res) {
        var i, tempArr, tempArr2, id, resObj;
        res = res.toString();
        tempArr = res.split('&');
        resObj = {};
        for (i = tempArr.length - 1; i >= 0; i--) {
            tempArr2 = tempArr[i].split("=");
            resObj[decodeURIComponent(tempArr2[0])] = decodeURIComponent(tempArr2[1]);
        }
        resObj.resultURL = "http://www.speedtest.net/my-result/" + resObj.resultid;
        resObj.resultImage = "http://www.speedtest.net/result/" + resObj.resultid + ".png";
        return resObj;
    }
    
    // Build the post string from an object
    var post_data = querystring.stringify({
        "download" : dlkbps,
        'ping' : pingms,
        'upload' : ulkbps,
        'promo' : "",
        'startmode' : 'pingselect',
        'recommendedserverid' : srv,
        'accuracy' : 1,
        'serverid' : srv,
        'hash' : hash([pingms, ulkbps, dlkbps, '297aae72'], "md5", "-")
    });


    // An object of options to indicate where to post to
    var post_options = {
        host: 'www.speedtest.net',
        port: '80',
        path: '/api/api.php',
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Referer' : "http://c.speedtest.net/flash/speedtest.swf",
            'Content-Length': post_data.length
        }
    };

    // Set up the request
    var post_req = http.request( post_options, function(res) {
        res.setEncoding('utf8');
        res.on('data', function (chunk) {
            callback(parse(chunk));
        });
    });


    // post the data
    post_req.write(post_data);
    post_req.end();
}/*
getResult({}, function(ob) {
    console.log(ob);
})*/

/**
    options [object]:
        downlaod [Number]
        upload [Number]
        ping [Number]
        server [Number]
        noRandomize [boolean]
    
*/

module.exports = {
    getResult : getResult,
    test : function (options) {
        getResult(options, function(ob) {
            console.log(ob);
        });
    }
}