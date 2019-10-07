using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    public Text world;
    public Image[] levelSprites;
    public Sprite levelLocked,levelUnlocked,levelCleared;
    GameObject currentWorld;
    public int worldNumber;
    int worldProgress = 0;
    int levelProgress;
    public Animator animator;
    public InGameUI UIManager;
    
    void Start(){
        animator = GetComponent<Animator>();
        ProgressionData data = SaveSystem.LoadProgression();
        LevelInfos.levelProgression = data.levelsCleared;
        worldNumber = 0;
        UpdateLevelProgressionUI();
    }

    void SetupLevelSelectionUI(){
        levelSprites = transform.GetChild(0).gameObject.GetComponentsInChildren<Image>();
        levelProgress = LevelInfos.levelProgression.Where(x => x == true).ToArray().Length;
        worldProgress = LevelInfos.WorldProgression.Where(x => x == true).ToArray().Length;
        world.text = "World " + (worldNumber+1).ToString();
        if(worldNumber < worldProgress){
            foreach(Image sprite in levelSprites){
                sprite.sprite = levelCleared;
            }
        }
        else{
            foreach(Image sprite in levelSprites){
                sprite.sprite = levelLocked;
            }
            if(worldNumber == worldProgress){
                for(int i = 0; i < levelProgress; i++){
                    levelSprites[i].sprite = levelCleared;
                }
                levelSprites[levelProgress].sprite = levelUnlocked;
            }
        }
    }

    void UpdateLevelProgressionUI(){
        levelSprites = transform.GetChild(0).gameObject.GetComponentsInChildren<Image>();
        levelProgress = LevelInfos.levelProgression.Where(x => x == true).ToArray().Length;
        worldProgress = LevelInfos.WorldProgression.Where(x => x == true).ToArray().Length;
        world.text = "World " + (worldNumber+1).ToString();
        if(worldNumber < worldProgress){
            foreach(Image sprite in levelSprites){
                sprite.sprite = levelCleared;
            }
        }
        else{
            foreach(Image sprite in levelSprites){
                sprite.sprite = levelLocked;
            }
            if(worldNumber == worldProgress){
                for(int i = 0; i < levelProgress; i++){
                    levelSprites[i].sprite = levelCleared;
                }
                levelSprites[levelProgress].sprite = levelUnlocked;
            }
        }
        FadeIn();    
    }
    public void ChangeWorld(int direction){
        if(direction == 1 && worldNumber + 1 < LevelInfos.WorldProgression.Length){     //right button 
            worldNumber += 1;
        } 
        else if(worldNumber > 0 && direction == -1){
            worldNumber -= 1;   
        }
        FadeOut();
    }
    void FadeOut(){
        animator.SetTrigger("FadeOut");  
    }
    void FadeIn(){
        animator.SetTrigger("FadeIn");
    }
    public void LoadLevel(int levelNumber){
        if(worldNumber <= worldProgress){
            if(levelNumber <= levelProgress +1){    //we want to have access to the level already cleared and the next one
                //SceneManager.LoadScene("world"+(worldNumber+1).ToString()+"_Level" + levelNumber.ToString());
                UIManager.FadeOutToScene("world"+(worldNumber+1).ToString()+"_Level" + levelNumber.ToString());
            }
        }
    }
}
