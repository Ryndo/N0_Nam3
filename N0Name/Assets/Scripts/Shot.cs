using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        rb.velocity = new Vector2(0,speed);
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Enemy")){
            collider.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
