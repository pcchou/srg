speedtest-result-generator
===============

各種惡搞 Speedtest.net的工具 XDDDD

Python版本：
------------------

* 作者：[Pc Chou](http://about.me/pcchou)
* 環境：Python 2
* 呼叫方法： `python srg.py 參數`
* 參數說明（請依照順序）：
  * normal或smart (smart會自動為您隨機輸出，給你最近似實際情況的數值)
  * 下載頻寬(kbps)
  * 上傳頻寬(kbps)
  * Ping值(ms)
  * (可選)[伺服編號](http://paste.ubuntu.com/8410453/) （[完整版本](http://www.speedtest.net/speedtest-servers-static.php)）
* 例如：`python srg.py normal 314150 926530 58979` 會產生出 （網址）

![真相](http://www.speedtest.net/result/3781272742.png)

* `python srg.py smart 100000 40000 6` 會產生出 （網址）

![真相](http://www.speedtest.net/result/3783836539.png)

Bash版本：
------------------

* 作者：[Denny Huang](https://github.com/denny0223) 、 [Pc Chou](http://about.me/pcchou)
* 環境：Bash
* 呼叫方法: `./srg.sh 參數`
* 參數說明（請依照順序）：
  * normal或smart (smart會自動為您隨機輸出，給你最近似實際情況的數值)
  * 下載頻寬(kbps)
  * 上傳頻寬(kbps)
  * Ping值(ms)
  * (可選)[伺服編號](http://paste.ubuntu.com/8410453/) （[完整版本](http://www.speedtest.net/speedtest-servers-static.php)）
* 例如：`./srg.sh normal 314150 926530 58979` 會產生出 （網址）

![真相](http://www.speedtest.net/result/3782546990.png)

* `./srg.sh smart 100000 40000 6` 會產生出 （網址）

![真相](http://www.speedtest.net/result/3783838355.png)

PHP版本：
------------------

* 作者：[Pc Chou](http://about.me/pcchou)
* 環境：PHP
* 呼叫方法：
  * func.php
    * 請先include本檔案，再用 `getImage(參數)` 函式呼叫。
  * srg.php
    * 直接使用該檔案，用GET參數呼叫。
* srg.php參數說明：
  * {mode} normal或smart (smart會自動為您隨機輸出，給你最近似實際情況的數值) (若為normal可不填此項)
  * {dlkbps} 下載頻寬(kbps)
  * {ulkbps} 上傳頻寬(kbps)
  * {pingms} Ping值(ms)
  * {srv} (可選)[伺服編號](http://paste.ubuntu.com/8410453/) （[完整版本](http://www.speedtest.net/speedtest-servers-static.php)
* 例如：`http://yourdomain.org/url.php?dlkbps=314150&ulkbps=926530&pingms=58979` 會產生出（網址）

![真相](http://www.speedtest.net/result/3782546990.png)

* `http://yourdomain.org/url.php?dlkbps=100000&ulkbps=40000&pingms=6&mode=smart`

![真相](http://www.speedtest.net/result/3783848922.png)

* func.php範例code: [點窩](http://pastebin.com/FUnA0G0F)
* 註：srg.php沒有調用func.php，兩者分開，請安心使用。

VB.net版本：
------------------

* 作者：[21](http://home.gamer.com.tw/X21999125X)
* 環境：Framework 2.0
* 呼叫方法：安裝 Framework 2.0 並把Server-List和執行檔放在同個資料夾下方可執行 (GUI)

Java版本：
------------------

* 作者：[ifTNT](http://home.gamer.com.tw/homeindex.php?owner=happyjohn369)
* 環境：Java 7
* 呼叫方法： `com.github.YSITD.srg.api.getImage(參數)`
* 參數說明（請依照順序）：
  * 下載頻寬(kbps)
  * 上傳頻寬(kbps)
  * Ping值(ms)
  * (填0或負值會使用預設值)[伺服編號](http://paste.ubuntu.com/8410453/) （[完整版本](http://www.speedtest.net/speedtest-servers-static.php)）
* 例如com.github.YSITD.srg.api.getImage(65536,32768,1,0);會產出

![真相](http://www.speedtest.net/result/3783897856.png)

HTML + JavaScript UI：
------------------
* 作者：[海豹](http://about.me/seadog007)、[鄭仁翔](https://github.com/james58899)
* 環境：HTML, JavaScript
* 呼叫方法：將web下的檔案跟php底下的檔案放在一起即可

Bukkit Plugin 版本：
------------------
* 作者：[ifTNT](http://home.gamer.com.tw/homeindex.php?owner=happyjohn369)
* 環境：Java7 for Bukkit 1.4+
* 呼叫方法：Minecraft Server中用指令呼叫
