using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dot{
    public string name;
    public float tickDamage;
    public float tickSpacing;
    public float duration;
    public float currentTickTime;
    public Dot(string _name,float _tickDamage,float _tickSpacing,float _duration){
        name = _name;
        tickDamage = _tickDamage;
        tickSpacing = _tickSpacing;
        duration = _duration;

        
    }
    public Dot Clone(){
            return new Dot(name,tickDamage,tickSpacing,duration);
        }
}
