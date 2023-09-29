using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnderDeck : MonoBehaviour
{
    [SerializeField] GameObject deck;
    [SerializeField] GameObject innerWallColliders;

    private int playerLayer = 7;
    private int animalLayer = 8;
    private int underDeckLayer = 10;
    private int deckLayer = 12;

    private void Start()
    {
        
    }

    private void SetEntityUnderDeck(GameObject entity)
    {
        entity.layer = underDeckLayer;
        entity.GetComponent<SpriteRenderer>().sortingLayerName = "UnderDeck";
    }

    private void SetEntityOnDeck(GameObject entity)
    {
        entity.layer = deckLayer;
        entity.GetComponent<SpriteRenderer>().sortingLayerName = "TopDeck";
    }

    private void SetEntityDefault(GameObject entity)
    {
        if (entity.GetComponent<AnimalMovement>() != null)
            entity.layer = animalLayer;
        else
            entity.layer = playerLayer;

        entity.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
    }

    private void HideDeck()
    {
        deck.SetActive(false);
        innerWallColliders.SetActive(true);
    }

    private void ShowDeck()
    {
        deck.SetActive(true);
        innerWallColliders.SetActive(false);
    }

}
