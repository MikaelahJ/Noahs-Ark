using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance { get; private set; }

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

    public static GameManager GetInstance() { return instance; }

    #endregion

    private LevelManager levelManager;
    private AudioManager audioManager;
    private EntityManager playerManager;
    private SceneChanger sceneChanger;

    public event Action FinishedLevelEvent;

    [SerializeField] private Canvas fadeCanvasPrefab;
    private FadeInOutScript fadeInOut;

    private int currentLevel = 0;

    public bool inGame;
    public bool finishedLevel;

    private void Start()
    {
        levelManager = LevelManager.GetInstance();
        audioManager = AudioManager.GetInstance();
        playerManager = EntityManager.GetInstance();

        sceneChanger = GetComponent<SceneChanger>();

        fadeInOut = Instantiate(fadeCanvasPrefab, transform).GetComponent<FadeInOutScript>();
        fadeInOut.FadeIn();

        StartLevel(); //REMOVE


    }

    public void ChangeScene(string scene)
    {
        sceneChanger.ChangeScene(scene);
    }

    public void StartLevel()
    {
        fadeInOut.FadeIn();
        inGame = true;
        levelManager.SetupLevel(currentLevel);

    }

    public void FinishedLevel()
    {
        FinishedLevelEvent?.Invoke();

        currentLevel++;
    }
}
