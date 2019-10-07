using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName ="New Mod",menuName ="Inventory/Mod/FireShot")]
public class FireShotMod : Mod
{
        public float tickDamage;
        public float tickSpacing;
        public float duration;
       

        public override void ApplyMod(Character character, Shooter shooter){
            shooter.dots.Add(new Dot(name, tickDamage,tickSpacing,duration));
        }
}
