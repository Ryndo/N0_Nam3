using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipementSlot : MonoBehaviour
{
    public Image icon;
    public Item mod;

    public void AddItem(Item newMod){
        mod = newMod;
        icon.sprite = mod.icon;
        icon.enabled = true; 
    }
    public void ClearSlot(){
        mod = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
