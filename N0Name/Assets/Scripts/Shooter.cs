using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Vector2 offset;
    public float shotSpeed;
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            GameObject shot = ObjectPooler.SharedInstance.GetPooledObject("Shot");
            shot.transform.position = transform.position + (Vector3) offset;
            shot.GetComponent<Shot>().speed = shotSpeed;
            shot.SetActive(true);
        }
    }
}
