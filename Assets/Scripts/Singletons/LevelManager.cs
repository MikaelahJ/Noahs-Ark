using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private string levelDataPath = "Assets/ScriptableObjects/Levels";
    public List<LevelConfig> levelDataList = new List<LevelConfig>();

    public List<GameObject> animalTypesInLevel = new List<GameObject>();
    public int requiredPoints;

    private SpawnObjectInArea spawnAnimal;

    private void Start()
    {
        spawnAnimal = GetComponent<SpawnObjectInArea>();
        LoadLevelData();
    }

    public void LoadLevelData()
    {
        levelDataList.Clear();
        //get all levelConfigs in folder from path
        string[] assetGuids = AssetDatabase.FindAssets("t:LevelConfig", new[] { levelDataPath });

        foreach (string assetGuid in assetGuids)
        {
            //get the specific levelConfig at path and add to list
            string assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
            LevelConfig levelConfig = AssetDatabase.LoadAssetAtPath<LevelConfig>(assetPath);

            if (levelConfig != null)
            {
                levelDataList.Add(levelConfig);
            }
        }

        StartLevel(0);
    }

    public void StartLevel(int levelIndex)
    {
        if (levelIndex < levelDataList.Count)
        {
            LevelConfig currentLevel = levelDataList[levelIndex];

            requiredPoints = currentLevel.requiredPoints;
 
            GetAnimals(currentLevel);
        }
    }

    public void GetAnimals(LevelConfig currentLevel)
    {
        var fields = typeof(LevelConfig).GetFields();

        foreach (var field in fields)
        {
            if (field.FieldType == typeof(bool) && (bool)field.GetValue(currentLevel))
            {
                string animalType = field.Name;
                GameObject animal = animalTypesInLevel.Find(obj => obj.name == field.Name);

                for (int i = 0; i < 2; i++)//spawn 2 of each animal
                {
                    spawnAnimal.SpawnObject(animal);
                }
            }
        }
    }
}
