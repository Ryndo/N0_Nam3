using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMods : CharacterMods
{
    public Player player;

    public override void Start()
    {
        mods = Equipement.mods.ToArray();
        base.Start();
    }

    

}
