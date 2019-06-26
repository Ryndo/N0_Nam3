using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenChecker : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collider){
        collider.gameObject.SetActive(false);
    }
}
