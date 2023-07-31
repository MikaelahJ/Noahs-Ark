using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    public AnimalData animalData;
    private AnimalMovement movementScript;

    private float rotationSpeed;

    void Start()
    {
        movementScript = GetComponent<AnimalMovement>();

        rotationSpeed = animalData.rotationSpeed;
        GetComponent<Animator>().runtimeAnimatorController = animalData.animController;
        GetComponent<SpriteRenderer>().sprite = animalData.animalSprite;

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
