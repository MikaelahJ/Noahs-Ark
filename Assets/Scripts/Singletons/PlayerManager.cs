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
    #endregion

    public bool isHolding;
    public bool isMoving;
    public bool canMove;

    public static PlayerManager GetInstance() { return instance; }

    void Start()
    {

    }

    void Update()
    {

    }
}
