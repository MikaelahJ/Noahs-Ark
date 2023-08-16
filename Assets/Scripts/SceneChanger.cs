using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.GetInstance();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void ChangeScene(string sceneToLoad)
    {

        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == gameManager.sceneToLoad)
        {
            gameManager.StartLevel();
        }
    }
}
