using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region singleton
    public static UIManager instance { get; private set; }

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

    public static UIManager GetInstance() { return instance; }

    #endregion

    [SerializeField] public RectTransform animalBoard;

    public void SetupBoard(List<GameObject> animalsInLevel)
    {

    }

}
