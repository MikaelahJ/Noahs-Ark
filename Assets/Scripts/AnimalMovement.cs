using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public bool isMoving;

    private float moveSpeed = 3f;
    private float minWaitTime = 1f;
    private float maxWaitTime = 5f;

    void Start()
    {
        StartMoving();
    }

    public void StartMoving() { StartCoroutine(MoveToPos()); }
    public void StopMoving() { StopCoroutine(MoveToPos()); }

    private IEnumerator MoveToPos()
    {
        while (true)
        {
            Vector2 randomPoint = Random.insideUnitCircle * 5;
            Vector3 targetPos = new Vector3(randomPoint.x, randomPoint.y, transform.position.z);
            float distance = Vector3.Distance(transform.position, targetPos);

            //checks if Sign between the points is negative or positive and flips accordingly
            GetComponent<SpriteRenderer>().flipX = Mathf.Sign(randomPoint.x - transform.position.x) < 0;

            while (distance > 0.1f)
            {
                isMoving = true;

                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                distance = Vector3.Distance(transform.position, targetPos);

                yield return null;
            }

            isMoving = false;

            float idleTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(idleTime);
        }
    }

}
