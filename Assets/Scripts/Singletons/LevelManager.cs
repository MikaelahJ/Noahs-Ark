using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region singleton
    public static LevelManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public static LevelManager GetInstance() { return instance; }

    #endregion

    [SerializeField] private Canvas animalCanvasPrefab;
    public AnimalCanvasUI animalCanvasUI;

    private string levelDataPath = "Assets/ScriptableObjects/Levels";
    public List<LevelConfig> levelDataList = new List<LevelConfig>();

    public List<GameObject> allAnimalTypes = new List<GameObject>();
    public List<string> animalTypesInLevel = new List<string>();
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
    }

    public void SetupLevel(int levelIndex)
    {
        var canvas = Instantiate(animalCanvasPrefab);
        animalCanvasUI = canvas.GetComponent<AnimalCanvasUI>();

        spawnAnimal.GetSpawnBoundry();

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
                animalTypesInLevel.Add(animalType);

                GameObject animal = allAnimalTypes.Find(obj => obj.name == field.Name);

                //add animal to animalCounter UI
                animalCanvasUI.AddToBoard(animal);

                for (int i = 0; i < 2; i++)//spawn 2 of each animal
                {
                    spawnAnimal.SpawnObject(animal);
                }
            }
        }

        GameObject.Find("Boat").GetComponentInChildren<BoatAnimalCounter>().addAnimalsToAnimalBools(animalTypesInLevel);
    }
}
