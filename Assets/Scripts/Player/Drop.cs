using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public void ThrowAnimal(GameObject animal)
    {
        Vector2 throwDirection = GetComponent<PlayerMovement>().dir;
        Rigidbody2D rb = animal.GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            Vector3 throwForce = throwDirection * animal.GetComponent<AnimalMovement>().throwDistance;
            rb.AddForce(throwForce, ForceMode2D.Impulse);
        }
    }
}
