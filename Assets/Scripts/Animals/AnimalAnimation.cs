using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    private AnimalMovement movementScript;

    public float rotationSpeed = 3f;

    void Start()
    {
        movementScript = GetComponent<AnimalMovement>();
    }

    void Update()
    {
        if (movementScript.isMoving)
            BouncyWalk();
        else
            transform.rotation = Quaternion.identity;
    }

    private void BouncyWalk()//Lerp rotation back and forth
    {
        float t = Mathf.PingPong(Time.time * rotationSpeed, 1f);

        float targetRotation = Mathf.Lerp(10, -10, t);

        transform.rotation = Quaternion.Euler(0, 0, targetRotation);
    }
}
