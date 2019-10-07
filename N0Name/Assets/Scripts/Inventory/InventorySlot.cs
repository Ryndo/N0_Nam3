using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text stack;
    [SerializeField]
    public ItemStack item;

    public void AddItem(ItemStack newItem){
        item = newItem;
        icon.sprite = newItem.item.icon;
        icon.enabled = true;
        stack.text = item.stacks.ToString();
        stack.enabled = true;
    }
    public void ClearSlot(){
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        stack.enabled = false;
    }
}
