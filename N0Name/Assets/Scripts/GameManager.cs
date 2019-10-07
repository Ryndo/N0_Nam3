using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level,world;
    public GameObject[] ObjectsToDestroyAtEnd;
    public List<Room> rooms = new List<Room>();
    public static GameManager Instance { get; private set; } // static singleton
    public Player player;
    public PlayerMods mods;
    public DungeonManager dungeonManager;
    DataBaseManager dataBase;
    string roomToLoad;
    Door.Direction loadDirection;
    public Animator animator;
    void Awake() {
        if (Instance == null){ 
            Instance = this;  
        }
        else { 
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject);
        rooms = ((Room[])Object.FindObjectsOfType(typeof(Room))).ToList();   
        dungeonManager = GetComponent<DungeonManager>(); 
        animator = GetComponent<Animator>();
     }
     void Start(){
         FindRooms();
         dungeonManager.rooms = rooms.ToArray();
         dataBase = DataBaseManager.Instance;
     }

     void Update(){
         if(dungeonManager.AllRoomBeenCleared()){
            LevelFinished();
            ExitToMenu();
         }
         
     }
     public void DestroyAllObject(){
         foreach(GameObject GO in ObjectsToDestroyAtEnd){
             Destroy(GO);
         }
         Destroy(gameObject);
     }
     void FindRooms(){
         foreach(GameObject roomGO in ObjectPooler.SharedInstance.pooledObjects){
             Room room;
             if(room = roomGO.GetComponent<Room>()){
                 rooms.Add(room);
             }
         }
     }

     public void SaveGame(){
         SaveSystem.SavePlayer(player,mods,Instance);
         SaveSystem.SaveProgression();
     }

     void ExitToMenu(){
        GameManager.Instance.DestroyAllObject();
        SaveGame();
        SceneManager.LoadScene("Accueil");
     }
     void LevelFinished(){
         
         if(!LevelInfos.levelProgression.Contains(false)){
             LevelInfos.WorldProgression[world - 1] = true;
             LevelInfos.levelProgression = new bool[10];
         }
         else{
             LevelInfos.levelProgression[level - 1] = true;
         }

     }
    public void FadeOutToRoom(string roomName,Door.Direction direciton){
        roomToLoad = roomName;
        loadDirection = direciton;
        animator.SetTrigger("FadeOut");
    }
    void OnFadeCompleteRoom(){
        dungeonManager.LoadRoom(roomToLoad,loadDirection);
    }
}
