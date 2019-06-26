using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 axisInput;
    Vector2 velocity;
    public float speed = 25;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update(){
        velocity = CalculateVelocity();
    }
    void FixedUpdate()
    {
        move(velocity);
    }
    Vector2 CalculateVelocity(){
        return axisInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));     
    }
    void move(Vector2 _velocity){
        rigid.AddForce(_velocity * speed);
    }
}
