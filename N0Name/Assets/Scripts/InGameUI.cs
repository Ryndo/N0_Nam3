using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{

    Animator animator;
    string SceneToLoad;

    void Awake(){
        animator = GetComponent<Animator>();
    }
    public void LoadSceneOnFadeOutComplete(){
        SceneManager.LoadScene(SceneToLoad);
    }
    public void QuitGameToMenu(){
        GameManager.Instance.DestroyAllObject();
        SceneManager.LoadScene("LevelSelection");
    }

    public void DisplayStats(){
        PlayerStats.DisplayStats();
    }
    public void Save(){
        GameManager.Instance.SaveGame();
    }
    public void cheatFinishWorld(){
        LevelInfos.levelProgression = new bool[]{ true, true, true, true, true, true, true,true,true,true };
        Debug.Log(LevelInfos.levelProgression);
    }
    public void LoadPlayerData(){
        PlayerData data = SaveSystem.LoadPlayer();
        foreach(string modName in data.mods){
            foreach(Mod mod in DataBaseManager.Instance.itemsDatabase){
                if(mod.name == modName){
                    Equipement.Equip(mod);
                }
            }
        }
        for(int i = 0;i < data.inventory.Length;i++){
            foreach(Item item in DataBaseManager.Instance.itemsDatabase){
                if(item.name == data.inventory[i]){
                    Inventory.Add(item,data.inventoryStacks[i]);
                }
            }
        }     
    }
    public void LoadProgress(){
        ProgressionData data = SaveSystem.LoadProgression();
        if(data != null){                                                  //If there's something to load
            for(int i = 0;i < data.levelsCleared.Length ; i++){
                LevelInfos.levelProgression[i] = data.levelsCleared[i];
            }
        }
        else{
            LevelInfos.levelProgression = new bool[10];
        }
        
    }
    public void FadeOutToScene(string sceneName){
        SceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void LoadData(){
        LoadPlayerData();
        LoadProgress();
    }

}
