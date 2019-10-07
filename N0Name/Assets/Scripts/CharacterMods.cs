using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMods : MonoBehaviour
{
    public Mod[] mods;
    Shooter shooter;
    Character character;

    public virtual void Start(){
        shooter = GetComponent<Shooter>();
        character = GetComponent<Character>();
        ApplyMod();
    }



    void ApplyMod(){
        foreach(Mod mod in mods){
            mod.ApplyMod(character,shooter);
        }
    }



}
