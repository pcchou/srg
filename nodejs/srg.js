var querystring = require('querystring');
var http = require('http');
var fs = require('fs');
var crypto = require('crypto');

function getResult(options, callback) {
    options = options || {};
    
    var dlkbps = options.download || Math.floor(180000 + 40000 * Math.random());
    var pingms = options.ping ||  Math.floor(30 + 20 * Math.random());;
    var ulkbps = options.upload || Math.floor(180000 + 40000 * Math.random());
    var srv = options.server || 5056;

    function hash(parameters, algorithm, seperator) {
        seperator = seperator || "-";
        algorithm = algorithm || "md5"; 
        var str = parameters.join(seperator);
        var shasum = crypto.createHash(algorithm);
        shasum.update(encodeURIComponent(str));
        return shasum.digest('hex');
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
    
*/

module.exports = {
    getResult : getResult,
    test : function (options) {
        getResult(options, function(ob) {
            console.log(ob);
        });
    }
}