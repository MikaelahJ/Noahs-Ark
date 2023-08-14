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

    public Dictionary<string, RectTransform> animalsOnBoard = new Dictionary<string, RectTransform>();

    public void AddToBoard(GameObject animalToAdd)
    {
        string name = animalToAdd.name;
        Sprite image = animalToAdd.GetComponent<SpriteRenderer>().sprite;

        var animal = Instantiate(UIanimalPrefab, board);

        animal.GetComponentInChildren<TextMeshProUGUI>().text = name + " (0/2)";
        animal.GetComponentInChildren<Image>().sprite = image;

        animalsOnBoard.Add(name, animal);
    }

    public void UpdateBoard(string animalName, int amount)
    {
        string numString = " (" + amount + "/2)";

        animalsOnBoard[animalName].GetComponentInChildren<TextMeshProUGUI>().text = animalName + numString;
    }
}
