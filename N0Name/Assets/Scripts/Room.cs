using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<Door> doors = new List<Door>();
    public List<EnemySpawn> enemiesToSpawn = new List<EnemySpawn>();
    public List<GameObject> enemiesInRoom = new List<GameObject>();
    public int x,y;
    public bool hasBeenCleared,isEmpty;

    void Start(){
        foreach(Transform child in transform){
            doors.Add(child.GetComponent<Door>());
        }
    }

    public bool Equals(int _x,int _y){
        if(x == _x && y == _y){
            return true;
        }
        return false;
    }
    public void fillRoom(){

        foreach(EnemySpawn spawn in enemiesToSpawn){
            GameObject enemy = ObjectPooler.SharedInstance.GetPooledObjectByName(spawn.enemy.name);
            enemy.transform.position = spawn.spawnPos;
            enemiesInRoom.Add(enemy);
            enemy.SetActive(true);
        }
        if(enemiesToSpawn.Count != 0){
            CloseDoors();
        }
        else{
            hasBeenCleared = true;
        }
        enemiesToSpawn.Clear();         //we dont want to respawn the enemies we'll kill
    }
    void Update(){
        if(AllEnemiesDead()){
            OpenDoors();

        }
    }
    bool AllEnemiesDead(){
        foreach(GameObject enemy in enemiesInRoom){
            if(enemy.activeInHierarchy){
                hasBeenCleared = false;
                isEmpty = false;
                return false;
            }
        }

        hasBeenCleared = enemiesToSpawn.Count == 0;
        isEmpty = true;
        return true;
    }
    void OpenDoors(){
        foreach(Door door in doors){
            door.OpenDoor();
        }
    }
    void CloseDoors(){
        foreach(Door door in doors){
            door.CloseDoor();
        }
    }
}
