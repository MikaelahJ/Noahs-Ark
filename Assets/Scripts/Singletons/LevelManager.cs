using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<LevelConfig> levels = new List<LevelConfig>();
    public int requiredPoints;

    public void StartLevel(int levelIndex)
    {
        if(levelIndex < levels.Count)
        {
            LevelConfig currentLevel = levels[levelIndex];

            requiredPoints = currentLevel.requiredPoints;

            SpawnAnimals(currentLevel);
        }
    }

    public void SpawnAnimals(LevelConfig currentLevel)
    {
        

    }
}
