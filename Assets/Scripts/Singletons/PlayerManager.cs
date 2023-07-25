using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region singleton
    public static PlayerManager instance { get; private set; }

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
    
    public static PlayerManager GetInstance() { return instance; }

    #endregion

    public GameObject animalHeld;

    public bool isHolding;
    public bool isMoving;
    public bool canMove;


    void Start()
    {

    }

    void Update()
    {

    }
}
