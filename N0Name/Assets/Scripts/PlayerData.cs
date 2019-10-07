using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public string[] mods;
    public string[] inventory;
    public int[] inventoryStacks;
    

    public PlayerData(Player player,PlayerMods _mods,GameManager gameManager){
        mods = new string[_mods.mods.Length];
        for(int i = 0;i<_mods.mods.Length;i++){
            mods[i] = _mods.mods[i].name;
        }
        inventory = new string[Inventory.items.Count];
        inventoryStacks = new int[inventory.Length];
        for(int i = 0;i<inventory.Length;i++){
            inventory[i] = Inventory.items[i].item.name;
            inventoryStacks[i] = (int)Inventory.items[i].stacks;

        }        
    }
    public void DisplayModsNames(){
        foreach(string mod in mods){
            Debug.Log(mod);
        }
    }
}
