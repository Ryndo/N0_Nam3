using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooter : Shooter
{
    void Update()
    {
        if(!player.IsDead() && active){
            Vector3 diff = Player.instance.transform.position - transform.position;
            diff.Normalize();
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            
            RotateTo(angle);
            if(timeToNextShot < 0){
                    Shot();
                    timeToNextShot = fireRate;
                }
            timeToNextShot -= Time.deltaTime;
        }
    }
}
