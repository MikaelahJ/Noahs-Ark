using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerManager playerManager;

    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        playerManager = PlayerManager.GetInstance();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.magnitude > 0)
            animator.SetBool("IsMoving", true);
        else
            animator.SetBool("IsMoving", false);

        if (playerManager.isHolding)
            animator.SetBool("IsHolding", true);
        else
            animator.SetBool("IsHolding", false);


        if (Input.GetAxisRaw("Horizontal") > 0)
            FlipSprite(false);

        else if (Input.GetAxisRaw("Horizontal") < 0)
            FlipSprite(true);
    }

    private void FlipSprite(bool flip)
    {
        GetComponent<SpriteRenderer>().flipX = flip;
    }
}
