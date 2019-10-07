using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager Instance;
    
    public Enemy[] enemies;
    public Item[] itemsDatabase;
        void Awake() {
        if (Instance == null){ 
            Instance = this;  
        }
        else { 
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject);

     }
}
