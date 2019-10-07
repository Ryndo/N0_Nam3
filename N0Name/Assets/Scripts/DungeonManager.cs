using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DungeonManager : MonoBehaviour
{
    public Room[] rooms;
    GameObject currentRoomGO;
    Room currentRoom;
    Player player;
    public static DungeonManager instance;
    public Collider2D spawningArea;
    GameManager gameManager;
    DataBaseManager dataBase;
    public InGameUI UIManager;
    public bool[] roomsState = new bool[9];
    public EnemyLevels[] enemyLevels;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    IEnumerator Start(){
        player = Player.instance;
        gameManager = GameManager.Instance;   
        dataBase = DataBaseManager.Instance;  
        yield return new WaitUntil(() => rooms.Length != 0);        //wait till the game manager send the rooms to "rooms"
        GenerateEnnemysSpawns();
        LoadRoom("Room00",Door.Direction.none);
    
}
    public void RoomTriggerEnter(Door door){
        gameManager.FadeOutToRoom("Room"+door.XHeadingTo.ToString()+door.YHeadingTo.ToString(),door.direction);
        //LoadRoom("Room"+door.XHeadingTo.ToString()+door.YHeadingTo.ToString(),door.direction);
    }

    public void LoadRoom(string room, Door.Direction direction){
            if(currentRoomGO != null){                                 //not first room loaded
            Vector2 playerPos = player.transform.position;
            if(direction == Door.Direction.bottom || direction == Door.Direction.top){
                playerPos.y *= -.8f;
            }
            else{
                playerPos.x *= -.8f;
            }
            player.transform.position = playerPos;
            if(currentRoom.hasBeenCleared){
                roomsState[System.Array.IndexOf(rooms,currentRoom)] = true;
            }
            currentRoomGO.SetActive(false);
        }
        currentRoomGO = ObjectPooler.SharedInstance.GetPooledObject(room);
        currentRoom = currentRoomGO.GetComponent<Room>();
        if(room != "Room00" || AllRoomEmpty()){           //Dont want to fill spawn room
            currentRoom.fillRoom();
        }
        currentRoomGO.SetActive(true); 
    }
    void GenerateEnnemysSpawns(){
        for(int i = 0; i < gameManager.rooms.Count; i++){
            foreach(int level in enemyLevels[i].levels){
                Enemy[] enemyOfLevel = dataBase.enemies.ToList().Where(x => x.level == level).ToArray();
                Vector2 randomPos = new Vector2(Random.Range(spawningArea.bounds.min.x,spawningArea.bounds.max.x),Random.Range(spawningArea.bounds.min.y,spawningArea.bounds.max.y));
                Enemy RandomEnemy = enemyOfLevel[Random.Range(0,enemyOfLevel.Length)];
                EnemySpawn randomSpawn = new EnemySpawn(RandomEnemy,randomPos);
                rooms[i].enemiesToSpawn.Add(randomSpawn);
            }
        }
    }
    
    public bool AllRoomEmpty(){
        for(int i = 0; i < rooms.Length; i++){
            if(!rooms[i].isEmpty){
                return false;
            }
        }
        return true;
    }
    public bool AllRoomBeenCleared(){
        if(currentRoom != null && currentRoom.hasBeenCleared){
                roomsState[System.Array.IndexOf(rooms,currentRoom)] = true;
        }
        foreach(bool isClear in roomsState){
            if(!isClear){
                return false;
            }
        }
        return true;
    }
}


[System.Serializable]
public class EnemyLevels{
    public int[] levels;
}
