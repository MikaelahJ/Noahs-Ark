using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    public AnimalData animalData;

    private AnimalMovement movementScript;
    private Animator animator;
    private AnimatorOverrideController animatorOverride;

    void Start()
    {
        movementScript = GetComponent<AnimalMovement>();
        animator = GetComponent<Animator>();

        GetComponent<SpriteRenderer>().sprite = animalData.animalSprite;

        SetIdleAnimClip();
    }

    private void SetIdleAnimClip()
    {
        animatorOverride = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverride;
        animatorOverride["AnimalIdle"] = animalData.idleAnimClip;
    }

    void Update()
    {
        if (movementScript.currentState == AnimalState.Moving)
            BouncyWalk();
        else if (movementScript.currentState == AnimalState.Held)
        {
            IsHeldWiggle();
        }
        else if (movementScript.currentState == AnimalState.Panic)
        {

        }
        else
            transform.rotation = Quaternion.identity;
    }

    private void BouncyWalk()//Lerp rotation back and forth
    {
        float t = Mathf.PingPong(Time.time * animalData.rotationSpeed, 1f);

        float targetRotation = Mathf.Lerp(10, -10, t);

        transform.rotation = Quaternion.Euler(0, 0, targetRotation);
    }

    private void IsHeldWiggle()
    {
        float t = Mathf.PingPong(Time.time * animalData.rotationSpeed * 3, 1f);

        float targetRotation = Mathf.Lerp(10, -10, t);

        transform.rotation = Quaternion.Euler(0, 0, targetRotation);
    }
}
