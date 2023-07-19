using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 dir;

    private float moveSpeed = 5f;

    private bool isHolding;
    private bool canMove;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       isHolding = GetComponent<PickUp>().isHolding;

    }

    void Update()
    {
        //if (!canMove)
        //    return;

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        dir.Normalize();

        
    }
    private void FixedUpdate()
    {
        rb.velocity = dir * moveSpeed;
    }
}
