using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName ="New Mod",menuName ="Inventory/Mod/FireRate")]
public class FireRateMod : Mod
{
    public float fireRateBonus;

    public override void ApplyMod(Character character,Shooter shooter){
        shooter.fireRate -= fireRateBonus;
    }
}
