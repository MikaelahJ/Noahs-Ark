using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private GameManager gameManager;

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

    }

    public void OnCredits()
    {

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
