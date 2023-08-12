using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void FinishedLevel()
    {
        Debug.Log("done");
    }



    /*TODO
     * 
     * if the level is done set PlayerManager.canMove = false and animal.canmove = false
     * play some sort of cinematic
     * start a new level
     * 
     */
}
