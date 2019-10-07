using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : Character
{
    
    Player player;
    public GameObject deathExplosion;
    
    void Start(){
        player = Player.instance;
    }
    public override void Update(){
        base.Update();
        if(IsDead()){
            gameObject.SetActive(false);
            GameObject deathParticles = ObjectPooler.SharedInstance.GetPooledObject("DeathParticle");
            deathParticles.transform.position = transform.position;
            deathParticles.SetActive(true);
            ResetValues();
        }
    }
    void OnDisable(){
        //ResetValues();
    }
    void ResetValues(){
        
        Enemy enemy = DataBaseManager.Instance.enemies.FirstOrDefault(x => x.GetType() == this.GetType());
        if(enemy){
            health = enemy.health;
        }
        
    }

}
