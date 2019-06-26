using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0,3)]
    public float minRandomTimeBetweenSpawn; 
    [Range(0,3)]
    public float maxRandomTimeBetweenSpawn; 
    [SerializeField]
    EnemySpawn[] spawningList;
    int index = 0;
    float YSpawnPoint;
    Collider2D collid;
    float minX_SpawnPoint,maxX_SpawnPoint;
    

    void Start()
    {
        Invoke("spawnRandom",.5f);
        collid = GetComponent<Collider2D>();  
        minX_SpawnPoint = collid.bounds.min.x;
        maxX_SpawnPoint = collid.bounds.max.x;      
        YSpawnPoint = collid.bounds.center.y;
    }
    void spawnRandom(){
        float randomTime = Random.Range(minRandomTimeBetweenSpawn,maxRandomTimeBetweenSpawn);
        EnemySpawn itemToSpawn = spawningList[index];
        GameObject item = ObjectPooler.SharedInstance.GetPooledObject(itemToSpawn.enemyName);
        Vector2 randomPos = new Vector2(Random.Range(minX_SpawnPoint,maxX_SpawnPoint),YSpawnPoint);
        item.transform.position = randomPos;
        item.gameObject.SetActive(true);
        Invoke("spawnRandom",randomTime);
    }
}
[System.Serializable]
public class EnemySpawn
{
    public string enemyName;
    public float spawnTime;
    public float XRandSpawnPoint;

}
