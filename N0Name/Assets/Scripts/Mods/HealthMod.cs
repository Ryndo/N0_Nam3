using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName ="New Mod",menuName ="Inventory/Mod/Health")]
public class HealthMod : Mod
{
    public float healthBonus;
    public override void ApplyMod(Character character,Shooter shooter){
        character.health += healthBonus;
    }
}
