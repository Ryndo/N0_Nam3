using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Collider2D colider2D;
    Room room;
    public int XHeadingTo,YHeadingTo;
    SpriteRenderer doorSprite;
    public Sprite doorOpen,closeDoor;
    
    public enum Direction{
        top,bottom,right,left,none
    }
    public Direction direction;

    void Awake(){
        colider2D = GetComponent<Collider2D>();
        room = GetComponentInParent<Room>();
        doorSprite = GetComponent<SpriteRenderer>();
        CalculatePos();
    }

    public void OpenDoor(){
        doorSprite.sprite = doorOpen;
        colider2D.enabled = true;
    }
    public void CloseDoor(){
        doorSprite.sprite = closeDoor;
        colider2D.enabled = false;
    }



    void CalculatePos(){
        if(direction is Direction.top){
            XHeadingTo = room.x;
            YHeadingTo = room.y - 1;
        }
        else if(direction is Direction.bottom){
            XHeadingTo = room.x;
            YHeadingTo = room.y + 1;
        }
        else if(direction is Direction.left){
            XHeadingTo = room.x - 1;
            YHeadingTo = room.y;
        }
        else if(direction is Direction.right){
            XHeadingTo = room.x + 1;
            YHeadingTo = room.y;
        }
    }
        void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            DungeonManager.instance.RoomTriggerEnter(this);
        }
    }
}
