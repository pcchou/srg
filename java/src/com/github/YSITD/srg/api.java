package com.github.YSITD.srg;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

/*
 * Author: ifTNT
 * License: Apache License
 */

public class api {
  public static void main(String[] args){
    String ResultId = getImage(100000,100000,1,0,true);
    System.out.println( (ResultId == null) ? "Something went wrong" :
                                             "Image: http://www.speedtest.net/result/"+ResultId+".png" );
  }
  public static String getImage(int DlSpeed, int UlSpeed, int ping, int ServerId, boolean SmartMode) { 
    try {
      ServerId = (ServerId <= 0) ? 2181 : ServerId;
      DlSpeed = (DlSpeed < 0) ? 0 : DlSpeed;
      UlSpeed = (UlSpeed < 0) ? 0 : UlSpeed;
      
      if(SmartMode){
        DlSpeed *= (0.975-(Math.random()*0.03));
        UlSpeed *= (0.975-(Math.random()*0.03));
        UlSpeed *= (0.965-(Math.random()*0.03));
      }
			  
      URL url = new URL("http://www.speedtest.net/api/api.php"); 
      HttpURLConnection URLConn = (HttpURLConnection) url.openConnection(); 
		 
      URLConn.setDoOutput(true);
      URLConn.setDoInput(true);
      ((HttpURLConnection) URLConn).setRequestMethod("POST");
      URLConn.setAllowUserInteraction(true);
      HttpURLConnection.setFollowRedirects(true);
      URLConn.setInstanceFollowRedirects(true);
		 
      URLConn.setRequestProperty("User-agent", "Python-urllib/2.7"); 
      URLConn.setRequestProperty("Referer", "http://c.speedtest.net/flash/speedtest.swf"); 
      URLConn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");
		        
      MessageDigest md = MessageDigest.getInstance("MD5");
      md.update((ping+"-"+UlSpeed+"-"+DlSpeed+"-297aae72").getBytes());
      String hash = toHexString(md.digest());
      String data = "download="+DlSpeed+"&"+
                    "ping="+ping+"&"+
                    "upload="+UlSpeed+"&"+
                    "promo=&"+
                    "startmode=pingselect&"+
                    "recommendedserverid=2181&"+
                    "accuracy=1&"+
                    "serverid="+ServerId+"&"+
                    "hash="+hash;
      DataOutputStream dos = new DataOutputStream(URLConn.getOutputStream());
      dos.writeBytes(data);
      dos.close();
		 
      BufferedReader rd = new BufferedReader(new InputStreamReader(URLConn.getInputStream())); 
      String line, content=""; 
      while ((line = rd.readLine()) != null) { 
        content += line; 
      }
      rd.close();
		        
      String[] Fields = content.split("&");
      String ResultId = "";
      for(String OneField:Fields){
        if(OneField.matches("resultid=\\d+")) ResultId=OneField.substring(9);
      }
		        
      return (ResultId=="0") ? null : ResultId ;
		        
    } catch (IOException e) { 
      e.printStackTrace();
      return null;
    } catch (NoSuchAlgorithmException e) {
      e.printStackTrace();
      return null;
    }
  }
	
  private static String toHexString(byte[] in) {
    StringBuilder hexString = new StringBuilder();
    for (int i = 0; i < in.length; i++){
      String hex = Integer.toHexString(0xFF & in[i]);
      if (hex.length() == 1){
        hexString.append('0');
      }
      hexString.append(hex);
    }
    return hexString.toString();
  }	
}
