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
    private PlayerManager playerManager;
    private SceneChanger sceneChanger;

    [SerializeField] private Canvas fadeCanvasPrefab;
    private FadeInOutScript fadeInOut;

    private int currentLevel = 0;

    private void Start()
    {
        levelManager = LevelManager.GetInstance();
        audioManager = AudioManager.GetInstance();
        playerManager = PlayerManager.GetInstance();

        sceneChanger = GetComponent<SceneChanger>();

        fadeInOut = Instantiate(fadeCanvasPrefab, transform).GetComponent<FadeInOutScript>();
        fadeInOut.FadeIn();
    }

    public void ChangeScene(string scene)
    {
        sceneChanger.ChangeScene(scene);
    }

    public void StartLevel()
    {
        fadeInOut.FadeIn();
        levelManager.SetupLevel(currentLevel);
    }

    public void FinishedLevel()
    {
        Debug.Log("done");

        currentLevel++;

    }
}
