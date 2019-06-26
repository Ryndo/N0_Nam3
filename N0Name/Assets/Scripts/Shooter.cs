using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            GameObject shot = ObjectPooler.SharedInstance.GetPooledObject("Shot");
            shot.transform.position = transform.position;
            shot.SetActive(true);
        }
    }
}
