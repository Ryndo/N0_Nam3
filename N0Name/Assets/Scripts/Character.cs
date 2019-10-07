using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Vector2 velocity;
    public int level;
    public float speed;
    public float health;
    public List<Dot> currentDots = new List<Dot>();

    public virtual void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Update(){
        UpdateDots();
    }

    public bool IsDead(){
        return health <= 0;
    }

    void UpdateDots(){
        List<Dot> DotEnded = new List<Dot>();
        foreach(Dot dot in currentDots){
            if(dot.currentTickTime <= 0){
                health -= dot.tickDamage;
                dot.currentTickTime = dot.tickSpacing;
            }
            else{
                dot.currentTickTime -= Time.deltaTime;
            }
            dot.duration -= Time.deltaTime;
            if(dot.duration <= 0){
                DotEnded.Add(dot);
            }
        }
        foreach(Dot dot in DotEnded){
            currentDots.Remove(dot);
 
        }
    }
}
