using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    #region singleton
    public static EntityManager instance { get; private set; }

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

    public static EntityManager GetInstance() { return instance; }

    #endregion

    public GameObject animalHeld;

    public bool isHolding;
    public bool isMoving;
    public bool canMove;

    private void Start()
    {
        GameManager.instance.FinishedLevelEvent += OnFinishedLevel;
    }

    private void OnFinishedLevel()
    {
        canMove = false;
    }
}
