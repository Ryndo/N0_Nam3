using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStack
{
        public Item item;
    public float stacks;

    public ItemStack(Item _item,float _stacks){
        item = _item;
        stacks = _stacks;
    }
}
