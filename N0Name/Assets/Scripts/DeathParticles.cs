using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticles : MonoBehaviour
{

    void OnEnable()
    {
        Invoke("Deactivate",3f);
    }
    void Deactivate(){
        gameObject.SetActive(false);
    }

}
