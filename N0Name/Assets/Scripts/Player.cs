using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Vector2 axisInput;
    public Joystick joystick;
    public static Player instance;

    public override void Awake(){
        base.Awake();
        if(instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Update(){
        base.Update();
        velocity = CalculateVelocity();
        
    }
    void FixedUpdate()
    {
        move(velocity);
    }
    Vector2 CalculateVelocity(){
        return joystick.Direction * speed;  
    }
    void move(Vector2 _velocity){
        rb.AddForce(_velocity);
    }
}
