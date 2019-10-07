using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    public delegate void OnInventoryChanged();
    public static OnInventoryChanged OnInventoryChangedCallback;
    public static List<ItemStack> items = new List<ItemStack>();
    
    public static void Add(Item item,float stack){
        ItemStack tempItem = items.Find(x => x.item == item);
        if(tempItem != null){
            for(int i = 0; i < items.Count ; i++){
                if(items[i].item == item){
                    items[i].stacks += stack;
                }
            }
        }
        else{
            items.Add(new ItemStack(item,stack));
        }
        if(OnInventoryChangedCallback != null){
            OnInventoryChangedCallback.Invoke();
        }
    }
    public static void AddAtIndex(Item item,int index){
        ItemStack tempItem = items.Find(x => x.item == item);
        if(tempItem != null){
            for(int i = 0; i < items.Count ; i++){
                if(items[i].item == item){
                    items[i].stacks += 1;
                }
            }
        }
        else{
            items.Insert(index, new ItemStack(item,1));
        }
        if(OnInventoryChangedCallback != null){
            OnInventoryChangedCallback.Invoke();
        }
    }
    public static void Remove(Item item,float stack){
        ItemStack tempItem = items.Find(x => x.item == item);
        items.Remove(tempItem);
        if(tempItem.stacks > stack){
            tempItem.stacks -= stack;
            items.Add(tempItem);
        }
        if(OnInventoryChangedCallback != null){
            OnInventoryChangedCallback.Invoke();
        }
    }
    
}
