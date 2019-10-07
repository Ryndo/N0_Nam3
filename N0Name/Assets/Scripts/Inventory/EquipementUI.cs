using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class EquipementUI : MonoBehaviour
{
    public Transform equipementsParent;
    Slot[] slots;

    void Awake(){
        Equipement.OnModsChangedCallback += UpdateUI;
        slots = equipementsParent.GetComponentsInChildren<Slot>();
        UpdateUI();
    }

    void UpdateUI(){
        for(int i = 0; i < slots.Length; i++){
            if(i < Equipement.mods.Count){
                slots[i].AddItem(new ItemStack (Equipement.mods[i],1));
            }
            else{
                slots[i].ClearSlot();
            }
        }
    }

    void OnDisable(){
        Equipement.OnModsChangedCallback -= UpdateUI;
    }
}
