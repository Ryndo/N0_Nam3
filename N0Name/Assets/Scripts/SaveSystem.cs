using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SavePlayer(Player player,PlayerMods mods, GameManager gameManager){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath,"player.ff");
        FileStream stream = new FileStream(path,FileMode.Create);
        PlayerData data = new PlayerData(player,mods, gameManager);
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static PlayerData LoadPlayer(){
        string path =  Path.Combine(Application.persistentDataPath,"player.ff");
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            PlayerData data = (PlayerData) formatter.Deserialize(stream);
            data.DisplayModsNames();
            stream.Close();
            return data;
        }   
        else{
            return null;
        }
    }
    public static void SaveProgression(){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath,"progression.ff");
        FileStream stream = new FileStream(path,FileMode.Create);
        ProgressionData progressionData = new ProgressionData();
        formatter.Serialize(stream,progressionData);
        stream.Close();
    }
    public static ProgressionData LoadProgression(){
        string path =  Path.Combine(Application.persistentDataPath,"progression.ff");
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            ProgressionData data = (ProgressionData) formatter.Deserialize(stream);
            stream.Close();
            return data;
        }   
        else{
            return null;
        }
    }
}
