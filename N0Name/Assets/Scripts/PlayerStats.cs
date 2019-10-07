using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats 
{
    public static float baseHealth;
    public static float baseSpeed;
    public static float baseFireRate;
    public static float baseShotSpeed;
    public static float baseShotDamage;
    public static float bonusHealth;
    public static float bonusSpeed;
    public static float bonusFireRate;
    public static float bonusShotSpeed;
    public static float bonusShotDamage;
    
    public static void DisplayStats(){
        Debug.Log("Health = " + baseHealth + " + " + bonusHealth);
        Debug.Log("Speed = " + baseSpeed + " + " + bonusSpeed);
        Debug.Log("Fire rate = " + baseFireRate + " + " + bonusFireRate);
        Debug.Log("Shot speed = " + baseShotSpeed + " + " + bonusShotSpeed);
        Debug.Log("Shot damage = " + baseShotDamage + " + " + bonusShotDamage);

    }
}
