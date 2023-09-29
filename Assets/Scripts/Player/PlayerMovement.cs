using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private EntityManager entityManager;
    private Rigidbody2D rb;

    public Vector2 dir;
    public Vector2 finishedBoatPos;

    private float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        entityManager = EntityManager.GetInstance();
        entityManager.canMove = true;

        finishedBoatPos = FindObjectOfType<BoatMovement>().transform.position;
    }

    void Update()
    {
        if (!entityManager.canMove)
            dir = Vector2.MoveTowards(transform.position, finishedBoatPos, moveSpeed);

        else
        {
            dir.x = Input.GetAxisRaw("Horizontal");
            dir.y = Input.GetAxisRaw("Vertical");
            dir.Normalize();
        }

        if (dir == Vector2.zero)
            entityManager.isMoving = false;
        else
            entityManager.isMoving = true;
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * moveSpeed;
    }
}
