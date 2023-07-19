using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (rb.velocity.magnitude > 0)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);


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
