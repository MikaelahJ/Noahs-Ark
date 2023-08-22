using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject creditsMenu;

    private void Start()
    {
        gameManager = GameManager.GetInstance();
    }

    public void OnContinue()
    {

    }

    public void OnNewGame()
    {
        gameManager.ChangeScene("Level0");
    }

    public void OnSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void OnBack()
    {
        settingsMenu.SetActive(false);
       // creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif

    }
}
