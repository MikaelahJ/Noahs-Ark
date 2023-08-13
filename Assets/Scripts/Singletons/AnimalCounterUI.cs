using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalCounterUI : MonoBehaviour
{
    #region singleton
    public static AnimalCounterUI instance { get; private set; }

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

    public static AnimalCounterUI GetInstance() { return instance; }

    #endregion

    [SerializeField] public RectTransform board;
    [SerializeField] public RectTransform UIanimalPrefab;


    public void AddToBoard(GameObject animalToAdd)
    {
        string name = animalToAdd.name;
        Sprite image = animalToAdd.GetComponent<SpriteRenderer>().sprite;

        var animal = Instantiate(UIanimalPrefab, board);

        animal.GetComponentInChildren<TextMeshProUGUI>().text = name;
        animal.GetComponentInChildren<SpriteRenderer>().sprite = image;
    }
}
