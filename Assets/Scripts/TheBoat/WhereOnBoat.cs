using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereOnBoat : MonoBehaviour
{
    [SerializeField] SpriteRenderer deck;
    [SerializeField] SpriteRenderer wheel;

    [SerializeField] StairTriggers stairTriggers;
    [SerializeField] UnderDeckTriggers underDeckTriggers;

    private int playerLayer = 7;
    private int animalLayer = 8;
    private int underDeckLayer = 10;
    private int deckLayer = 12;

    private void OnEnable()
    {
        stairTriggers.GoingTopDeck += SetEntityTopDeck;
        underDeckTriggers.GoingUnderDeck += SetEntityUnderDeck;

        stairTriggers.GoingDefaultDeck += SetEntityDefaultDeck;
        underDeckTriggers.GoingDefaultDeck += SetEntityDefaultDeck;
    }

    private void OnDisable()
    {
        stairTriggers.GoingTopDeck -= SetEntityTopDeck;
        underDeckTriggers.GoingUnderDeck -= SetEntityUnderDeck;

        stairTriggers.GoingDefaultDeck -= SetEntityDefaultDeck;
        underDeckTriggers.GoingDefaultDeck -= SetEntityDefaultDeck;
    }

    private void SetEntityTopDeck(GameObject entity)
    {
        entity.layer = deckLayer;
        entity.GetComponent<SpriteRenderer>().sortingLayerName = "TopDeck";
    }

    private void SetEntityUnderDeck(GameObject entity, bool isPlayer)
    {
        if (isPlayer)
            HideDeck();

        entity.layer = underDeckLayer;
        entity.GetComponent<SpriteRenderer>().sortingLayerName = "UnderDeck";
    }

    private void SetEntityDefaultDeck(GameObject entity, bool isPlayer = false)
    {
        if (isPlayer)
        {
            ShowDeck();
            entity.layer = playerLayer;
        }
        else // isAnimal
            entity.layer = animalLayer;

        entity.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
    }

    private void HideDeck()
    {
        deck.enabled = false;
        wheel.enabled = false;
    }

    private void ShowDeck()
    {
        deck.enabled = true;
        wheel.enabled = true;
    }
}
