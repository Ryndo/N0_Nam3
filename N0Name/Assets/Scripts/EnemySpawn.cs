using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawn 
{
    public Enemy enemy;
    public Vector2 spawnPos;

    public EnemySpawn(Enemy _enemy, Vector2 _spawnPos){
        enemy = _enemy;
        spawnPos = _spawnPos;
    }
}
