using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerManager playerManager;

    private Rigidbody2D rb;

    public Vector2 dir;

    private float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerManager = PlayerManager.GetInstance();
        playerManager.canMove = true;
    }

    void Update()
    {
        if (!playerManager.canMove)
            return;

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        dir.Normalize();

        if (dir == Vector2.zero)
            playerManager.isMoving = false;
        else
            playerManager.isMoving = true;
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * moveSpeed;
    }
}
