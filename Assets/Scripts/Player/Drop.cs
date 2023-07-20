using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = PlayerManager.GetInstance();
    }

    public void DropOrThrow(GameObject animal)
    {
        if (!playerManager.isMoving) { DropAnimal(animal); Debug.Log("DROP"); }
        else { ThrowAnimal(animal);Debug.Log("THROW"); }
    }

    private void DropAnimal(GameObject animal)
    {
        Rigidbody2D rb = animal.GetComponent<Rigidbody2D>();
        rb.transform.SetParent(null);
        rb.isKinematic = false;
        animal.GetComponent<AnimalMovement>().StartMoving();

    }

    public void ThrowAnimal(GameObject animal)
    {
        Vector2 throwDirection = GetComponent<PlayerMovement>().dir;
        Rigidbody2D rb = animal.GetComponent<Rigidbody2D>();
        rb.transform.SetParent(null);
        rb.isKinematic = false;


        if (rb != null)
        {
            Vector3 throwForce = throwDirection * animal.GetComponent<AnimalMovement>().throwDistance;
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            animal.GetComponent<AnimalMovement>().StartMoving();
        }
    }
}
