using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private ParticleSystem throwTrail;

    private EntityManager playerManager;


    private void Start()
    {
        playerManager = EntityManager.GetInstance();
    }

    public void DropOrThrow(GameObject animal)
    {
        if (!playerManager.isMoving) { DropAnimal(animal);}
        else { ThrowAnimal(animal);}

        playerManager.animalHeld = null;
    }

    private void DropAnimal(GameObject animal)
    {
        RestoreValues(animal);
        animal.GetComponent<AnimalMovement>().StartMoving();
    }

    public void ThrowAnimal(GameObject animal)
    {
        RestoreValues(animal);

        Vector2 throwDirection = GetComponent<PlayerMovement>().dir;
        Rigidbody2D rb = animal.GetComponent<Rigidbody2D>();
        rb.drag = animal.GetComponent<AnimalMovement>().throwDrag;

        if (rb != null)
        {
            Vector3 throwForce = throwDirection * animal.GetComponent<AnimalMovement>().throwDistance;
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            animal.GetComponent<AnimalMovement>().StartMovingInvoke();

            SpawnTrailFX(animal, throwDirection);
        }
    }

    private void RestoreValues(GameObject animal)
    {
        GetComponent<PickUp>().closestPickup = null;

        animal.GetComponent<AnimalMovement>().currentState = AnimalState.Idle;

        Rigidbody2D rb = animal.GetComponent<Rigidbody2D>();
        rb.transform.SetParent(null);
        rb.isKinematic = false;
    }

    private void SpawnTrailFX(GameObject animal, Vector3 throwDirection)
    {
        var trail = Instantiate(throwTrail, animal.transform.position, Quaternion.identity, animal.transform);

        //Rotate system opposite to throwDirection
        float angle = Mathf.Atan2(throwDirection.y, -throwDirection.x) * Mathf.Rad2Deg;
        trail.transform.rotation = Quaternion.Euler(angle, 90f, 0f);

        Destroy(trail.gameObject, 3);
    }
}
