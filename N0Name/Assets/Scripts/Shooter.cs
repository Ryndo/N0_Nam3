using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Vector2 offset;
    public float shotSpeed;
    public float shotDamage;
    public List<Dot> dots = new List<Dot>();
    
    public float t;
    public float fireRate = 1f;
    public float minimumFireRate = .1f;
    protected float timeToNextShot;
    Rigidbody2D rb;
    public Character player;
    public Transform shotSpawnPoint;
    public float spriteAngleOffset;
    protected bool active;
    public float timeBeforeActive;

    protected IEnumerator Start(){
        rb = GetComponent<Rigidbody2D>();
        player = GetComponentInParent<Character>();
        yield return new WaitForSeconds(timeBeforeActive);
        active = true;
        timeToNextShot = 0;
    }
    protected void Shot(){
        GameObject shotGO = ObjectPooler.SharedInstance.GetPooledObject("Shot");
        Shot shot = shotGO.GetComponent<Shot>();
        shotGO.transform.position = shotSpawnPoint.position;
        shotGO.transform.rotation = transform.rotation;
        shot.speed = shotSpeed;
        shot.damage = shotDamage;
        shot.shooter = player.tag;
        AddDotsToShot(shot);
        shotGO.SetActive(true);
    }

    protected void RotateTo(float angle){
         transform.rotation = Quaternion.Lerp(Quaternion.AngleAxis(angle - spriteAngleOffset, Vector3.forward),transform.rotation,t * Time.deltaTime);
    }

    void AddDotsToShot(Shot shot){
        foreach(Dot dot in dots){
            shot.dots.Add(dot.Clone());
        }
    }
}
