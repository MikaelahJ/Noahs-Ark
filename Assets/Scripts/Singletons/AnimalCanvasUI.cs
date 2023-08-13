using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalCanvasUI : MonoBehaviour
{
    #region singleton
    public static AnimalCanvasUI instance { get; private set; }

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

    public static AnimalCanvasUI GetInstance() { return instance; }

    #endregion

    [SerializeField] public RectTransform board;
    [SerializeField] public RectTransform UIanimalPrefab;


    public void AddToBoard(GameObject animalToAdd)
    {
        string name = animalToAdd.name;
        Sprite image = animalToAdd.GetComponent<SpriteRenderer>().sprite;

        var animal = Instantiate(UIanimalPrefab, board);

        animal.GetComponentInChildren<TextMeshProUGUI>().text = name + " (0/0)";
        animal.GetComponentInChildren<Image>().sprite = image;
    }
}
