using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter
{
    public Joystick joystick;
    void Update()
    {   
        Vector2 direction = joystick.Direction;
        float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        if(direction != Vector2.zero){
           RotateTo(angle);
            if(timeToNextShot < 0){
                Shot();
                timeToNextShot = fireRate;
            }
        }
        timeToNextShot -= Time.deltaTime;
    }
}
