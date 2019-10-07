using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ProgressionData 
{
    public bool[] levelsCleared = new bool[10];
    public int lastLevelCleared;

    public ProgressionData(){
        levelsCleared = LevelInfos.levelProgression;
    }
}
