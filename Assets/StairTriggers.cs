using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTriggers : MonoBehaviour
{
    public event Action<GameObject> GoingTopDeck;
    public event Action<GameObject> GoingDefaultDeck;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoingTopDeck?.Invoke(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GoingDefaultDeck?.Invoke(collision.gameObject);
    }
}
