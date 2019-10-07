using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class  Equipement
{
    public delegate void OnModsChanged();
    public static OnModsChanged OnModsChangedCallback;
    public static List<Mod> mods = new List<Mod>();


    public static void Equip(Mod mod){
        mods.Add(mod);
        if(OnModsChangedCallback != null){
            OnModsChangedCallback.Invoke();
        }
    }
    public static void Remove(Mod mod){
        mods.Remove(mod);
        if(OnModsChangedCallback != null){
            OnModsChangedCallback.Invoke();
        }
    }
}
