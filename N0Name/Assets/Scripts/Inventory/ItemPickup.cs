using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            Inventory.Add(item,1);
            Destroy(gameObject);
        }
    }


}
