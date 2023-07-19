using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool canMove;
    public bool isMoving;

    public float throwDistance = 10f;
    public float moveSpeed = 3f;

    private float minWaitTime = 1f;
    private float maxWaitTime = 5f;


    private Coroutine movementCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartMoving();
    }

    public void StartMoving()
    {
        if (!canMove)
        {
            canMove = true;
            movementCoroutine = StartCoroutine(MoveToPos());
        }
    }

    public void StopMoving()
    {
        if (canMove)
        {
            canMove = false;
            StopCoroutine(MoveToPos());
        }
    }

    private IEnumerator MoveToPos()
    {
        while (true)
        {
            if (canMove)
            {
                Vector2 randomPoint = Random.insideUnitCircle * 5;
                Vector3 targetPos = new Vector3(randomPoint.x, randomPoint.y, transform.position.z);
                float distance = Vector3.Distance(transform.position, targetPos);

                //checks if Sign between the points is negative or positive and flips sprite accordingly
                GetComponent<SpriteRenderer>().flipX = Mathf.Sign(randomPoint.x - transform.position.x) < 0;

                while (distance > 0.1f)
                {
                    isMoving = true;

                    Vector3 direction = (targetPos - transform.position).normalized;
                    rb.velocity = direction * moveSpeed;

                    //transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

                    yield return null;
                    distance = Vector3.Distance(transform.position, targetPos);
                }
                isMoving = false;
                rb.velocity = Vector3.zero;

                float idleTime = Random.Range(minWaitTime, maxWaitTime);
                yield return new WaitForSeconds(idleTime);
            }
            else
            {
                rb.velocity = Vector3.zero;
                yield return null;
            }
        }
    }
}
