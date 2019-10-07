using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName ="New Mod",menuName ="Inventory/Mod/FireSpreadShot")]
public class FireSpreadShot : Mod
{
    public float spreadAmount;
    public float spreadDamage;
    public float spreadSpeed;

    public override void ApplyMod(Character character, Shooter shooter){
        
    }
}
