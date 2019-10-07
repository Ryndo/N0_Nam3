using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
public class Slot : MonoBehaviour , IDropHandler
{
    public Image icon;
    public Text stack;
    [SerializeField]
    public ItemStack itemStack;

 public GameObject item
 {
  get {
      
   if (transform.childCount > 0) {
    return transform.GetChild(0).gameObject;
   } 

   return null;
  }
 }

 #region IdropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
        if(DragAndDrop.origin.CompareTag("Inventory")){
            Inventory.Remove(DragAndDrop.itemMoved.item,1);
        }
        else{
            Equipement.Remove((Mod)DragAndDrop.itemMoved.item);
        }
        if(transform.parent.CompareTag("Inventory")){                                  //Si on met un item ou mod dans l'inventaire
            Inventory.Add(DragAndDrop.itemMoved.item,DragAndDrop.itemMoved.stacks);
        }
        else if(DragAndDrop.itemMoved.item is Mod){                             //Si seulement un mod est mis dans le stock de mod
            Equipement.Equip((Mod)DragAndDrop.itemMoved.item);
        }
        else{                                                                   //Si un item est mis dans le stock de mod
            Inventory.Add(DragAndDrop.itemMoved.item,DragAndDrop.itemMoved.stacks);
        }
    }
    #endregion

    
    public void AddItem(ItemStack newItem){
        itemStack = newItem;
        icon.sprite = newItem.item.icon;
        icon.enabled = true;
        stack.text = itemStack.stacks.ToString();
        if(newItem.stacks > 1){
            stack.enabled = true;
        }
        else{
            stack.enabled = false;
        }
        
    }
    public void ClearSlot(){
        itemStack = null;
        icon.sprite = null;
        icon.enabled = false;
        if(stack != null){
            stack.enabled = false;
        }
        
        
    }
}