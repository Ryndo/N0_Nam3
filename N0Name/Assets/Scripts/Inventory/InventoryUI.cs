using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryUI : MonoBehaviour
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
        Inventory.items = Inventory.items.OrderBy(item => item.item.name).ToList();
        for(int i = 0; i < slots.Length; i++){
            if(i < Inventory.items.Count){
                slots[i].AddItem(Inventory.items[i]);
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
