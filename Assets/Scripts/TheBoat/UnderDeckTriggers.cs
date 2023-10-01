using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderDeckTriggers : MonoBehaviour
{
    public event Action<GameObject, bool> GoingUnderDeck;
    public event Action<GameObject, bool> GoingDefaultDeck;

    private bool isPlayer = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            isPlayer = true;
        else 
            isPlayer = false;

        GoingUnderDeck?.Invoke(other.gameObject, isPlayer);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayer = true;
        else
            isPlayer = false;

        GoingDefaultDeck?.Invoke(other.gameObject, isPlayer);
    }
}
