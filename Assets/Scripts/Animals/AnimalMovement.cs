using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public AnimalData animalData;

    private Rigidbody2D rb;

    public bool canMove;
    public bool isMoving;

    public float throwDistance;
    public float throwDrag;
    private float moveSpeed;

    private float minWaitTime = 1f;
    private float maxWaitTime = 5f;


    private Coroutine movementCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        throwDistance = animalData.throwDistance;
        throwDrag = animalData.throwDrag;
        moveSpeed = animalData.moveSpeed;

        StartMovingInvoke();
    }

    public void StartMovingInvoke()
    {
        Invoke(nameof(StartMoving), 3);
    }

    public void StartMoving()
    {
        rb.drag = 10f;
        if (gameObject.layer != LayerMask.NameToLayer("Animal"))
            gameObject.layer = LayerMask.NameToLayer("Animal");

        if (!canMove)
        {
            canMove = true;
            movementCoroutine = StartCoroutine(MoveToPos());
        }
    }

    public void StopMoving()
    {
        CancelInvoke();

        if (canMove)
        {
            canMove = false;
            if (movementCoroutine != null)
            {
                StopCoroutine(movementCoroutine);
                isMoving = false;
                rb.velocity = Vector3.zero;
            }
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
