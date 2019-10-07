using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float damage;
    public string shooter;
    
    public List<Dot> dots = new List<Dot>();
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D collider){
        if((collider.CompareTag("Enemy") || collider.CompareTag("Player")) && !collider.CompareTag(shooter)){
            Character hit = collider.GetComponent<Character>();
            hit.health -= damage;
            ApplyDots(hit);
            DisableShot();
            
        }    
    }

    void ApplyDots(Character target){
        foreach(Dot dot in dots){
            target.currentDots.Add(dot);
        }
    }

    void DisableShot(){
        dots = new List<Dot>();
        gameObject.SetActive(false);
    }
    
}


