package com.github.YSITD.srg;

import org.bukkit.ChatColor;
import org.bukkit.command.Command;
import org.bukkit.command.CommandSender;
import org.bukkit.plugin.java.JavaPlugin;

/*
 * Author: ifTNT
 * License: Apache License
 */

public class BukkitPlugin extends JavaPlugin{
  @Override
  public boolean onCommand(CommandSender sender, Command cmd, String CmdLabel,String[] args){
    if(CmdLabel.equals("srg") && (args.length == 3 || args.length == 4)){
      int DlSpeed = Integer.parseInt(args[0]);
      int UlSpeed = Integer.parseInt(args[1]);
      int Ping = Integer.parseInt(args[2]);
      int ServerId = ((args.length == 4) ? Integer.parseInt(args[3]) : 0);
      String ResultId = api.getImage(DlSpeed, UlSpeed, Ping, ServerId, true);
      if(ResultId == null){
        sender.sendMessage(ChatColor.RED + "Something went worng!");
      }else{
        sender.sendMessage(ChatColor.GOLD + "Result: http://www.speedtest.net/my-result/"+ResultId);
        sender.sendMessage(ChatColor.GOLD + "Image: http://www.speedtest.net/result/"+ResultId+".png");
      }
    }else{
      sender.sendMessage(ChatColor.RED + "usage: /srg <Download speed(kbps)> <Upload speed(kbps)> <Ping> [Server id]");
    }
    return true;
  }
}
