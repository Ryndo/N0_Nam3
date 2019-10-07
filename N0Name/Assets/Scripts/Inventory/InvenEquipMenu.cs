using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InvenEquipMenu : MonoBehaviour
{
    public Transform itemsParent;
    public Slot[] slots;
    void Awake()
    {
        Inventory.OnInventoryChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<Slot>();
        UpdateUI();
    }

    void UpdateUI(){  
            List<ItemStack> modsInInventory = Inventory.items.Where(x => x.item.GetType().IsSubclassOf(typeof(Mod))).ToList();
            modsInInventory = modsInInventory.OrderBy(item => item.item.name).ToList();
        for(int i = 0; i < slots.Length; i++){
            if(i < modsInInventory.Count){
                slots[i].AddItem(modsInInventory[i]);
            }
            else{
                slots[i].ClearSlot();
            }
        }
        
    }
    void OnDisable(){
        Inventory.OnInventoryChangedCallback -= UpdateUI;
    }
}
