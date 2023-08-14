using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    [SerializeField] private Canvas fadeCanvasPrefab;
    private FadeInOutScript fadeInOut;

    private int currentLevel = 0;

    public string sceneToLoad;

    private void Start()
    {
        levelManager = LevelManager.GetInstance();
        audioManager = AudioManager.GetInstance();
        playerManager = PlayerManager.GetInstance();

        fadeInOut = Instantiate(fadeCanvasPrefab, transform).GetComponent<FadeInOutScript>();
        
        StartLevel(0);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
    public void StartLevel(int levelToPlay)
    {
        fadeInOut.FadeIn();
        levelManager.SetupLevel(levelToPlay);
    }

    public void FinishedLevel()
    {
        Debug.Log("done");

        currentLevel++;

    }




}
