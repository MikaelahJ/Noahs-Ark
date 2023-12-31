using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalState
{
    Idle,
    Moving,
    Held,
    Panic
}

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] AnimalData animalData;
    public AnimalState currentState;

    private Rigidbody2D rb;

    public bool canMove;

    public float throwDistance;
    public float throwDrag;
    public float moveRadius;
    public float moveSpeed;
    public float minWaitTime;
    public float maxWaitTime;

    private float maxStuckTime = 2f;

    private Coroutine movementCoroutine;

    void Start()
    {
        currentState = AnimalState.Idle;

        rb = GetComponent<Rigidbody2D>();

        throwDistance = animalData.throwDistance;
        throwDrag = animalData.throwDrag;
        moveRadius = animalData.moveRadius;
        moveSpeed = animalData.moveSpeed;
        minWaitTime = animalData.minWaitTime;
        maxWaitTime = animalData.maxWaitTime;

        StartMovingInvoke();
    }

    public void StartMovingInvoke()
    {
        Invoke(nameof(StartMoving), 3);
    }

    public void StartMoving()
    {
        rb.drag = throwDrag;
        if (gameObject.layer != LayerMask.NameToLayer("Animal"))
            gameObject.layer = LayerMask.NameToLayer("Animal");

        if (!canMove)
        {
            canMove = true;
            currentState = AnimalState.Moving;
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
                currentState = AnimalState.Held;
                rb.velocity = Vector3.zero;
            }
        }
    }

    private IEnumerator MoveToPos()
    {
        while (true)
        {
            if (currentState == AnimalState.Moving)
            {
                Vector2 randomOffset = Random.insideUnitCircle * moveRadius;
                Vector2 randomPoint = (Vector2)transform.position + randomOffset;
                Vector3 targetPos = new Vector3(randomPoint.x, randomPoint.y, transform.position.z);
                float distance = Vector3.Distance(transform.position, targetPos);

                //checks if Sign between the points is negative or positive and flips sprite accordingly
                GetComponent<SpriteRenderer>().flipX = Mathf.Sign(randomPoint.x - transform.position.x) < 0;

                float stuckTime = 0f;
                Vector3 prevPos = transform.position;

                while (distance > 0.1f)
                {
                    currentState = AnimalState.Moving;

                    Vector3 direction = (targetPos - transform.position).normalized;
                    rb.velocity = direction * moveSpeed;

                    if (Vector3.Distance(transform.position, prevPos) < 0.3f)
                    {
                        stuckTime += Time.deltaTime;

                        if (stuckTime > maxStuckTime)
                        {
                            break;
                        }
                    }
                    else
                    {
                        stuckTime = 0f;
                    }
                    prevPos = transform.position;

                    yield return null;
                    distance = Vector3.Distance(transform.position, targetPos);
                }

                currentState = AnimalState.Idle;
                rb.velocity = Vector3.zero;

                float idleTime = Random.Range(minWaitTime, maxWaitTime);
                yield return new WaitForSeconds(idleTime);
                currentState = AnimalState.Moving;
            }
            else
            {
                rb.velocity = Vector3.zero;
                yield return null;
            }
        }
    }
}
