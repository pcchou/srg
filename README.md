speedtest-result-generator
===============

各種惡搞 Speedtest.net的工具 XDDDD

Python版本：srg.py
------------------

* 作者：[Pc Chou](http://about.me/pcchou)
* 環境：Python 2
* 呼叫方法： `python srg.py 參數`
* 參數說明：
  * 下載頻寬(kbps)
  * 上傳頻寬(kbps)
  * Ping值(ms)
  * (Optional)[伺服編號](http://paste.ubuntu.com/8410453/) （[完整版本](http://www.speedtest.net/speedtest-servers-static.php)）
* 例如：`python srg.py 314150 926530 58979` 會產生出 （網址）

![真相](http://www.speedtest.net/result/3781272742.png)

Bash版本：srg.sh
------------------

* 作者：[Denny Huang](https://github.com/denny0223)
* 環境：Bash
* 呼叫方法: `./srg.sh 參數`
* 參數說明：
  * 下載頻寬(kbps)
  * 上傳頻寬(kbps)
  * Ping值(ms)
  * (Optional)[伺服編號](http://paste.ubuntu.com/8410453/) （[完整版本](http://www.speedtest.net/speedtest-servers-static.php)）
* 例如：`./srg.sh 314150 926530 58979` 會產生出 （網址）

![真相](http://www.speedtest.net/result/3782546990.png)

PHP版本：php/func.php與url.php
------------------

* 作者：[Pc Chou](http://about.me/pcchou)
* 環境：PHP
* 呼叫方法：
  * func.php
    * 請先include本檔案，再用 `getImage(參數)` 函式呼叫。
  * url.php
    * 直接使用該檔案，用GET參數呼叫。
* 參數說明（url.php請使用後面括號作為參數名稱）：
  * 下載頻寬(kbps) (dlkbps)
  * 上傳頻寬(kbps) (ulkbps)
  * Ping值(ms) (pingms)
  * (Optional)[伺服編號](http://paste.ubuntu.com/8410453/) （[完整版本](http://www.speedtest.net/speedtest-servers-static.php)）(srv)
* 例如：`http://yourdomain.org/url.php?dlkbps=314150&ulkbps=926530&pingms=58979` 會產生出（網址）

![真相](http://www.speedtest.net/result/3782546990.png)
* func.php範例code: [用func.php寫的url.php](http://pastebin.com/mDsC9yHm)
* 註：url.php沒有調用func.php，兩者分開，請安心使用。

VB.net版本：VB.net/*
------------------

* 作者：[海豹](http://about.me/seadog007)
* 環境：VB.net 2012
* 呼叫方法：安裝 Framework 4.5 並執行 (GUI)
