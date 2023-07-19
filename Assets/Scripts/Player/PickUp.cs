using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI pickupText;

    private List<GameObject> pickupsInRadius = new List<GameObject>();
    private GameObject closestPickup;

    public bool isHolding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Pickupable"))
            return;

        pickupsInRadius.Add(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (closestPickup != null && Input.GetKeyDown(KeyCode.E))
            PickUpAnimal();

        if(isHolding) { }
        foreach (GameObject obj in pickupsInRadius)
        {
            Vector2 direction = obj.transform.position - transform.position;
            float distance = direction.magnitude;

            if (closestPickup == null)
                closestPickup = obj;

            if (distance < (closestPickup.transform.position - transform.position).magnitude)
            {
                pickupText.text = "Pickup " + obj.name + " [E]";
                closestPickup = obj;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (pickupsInRadius.Contains(collision.gameObject))
        {
            pickupsInRadius.Remove(collision.gameObject);

            if (pickupsInRadius.Count == 0)
                pickupText.text = "";
        }

        if (isHolding)
            pickupText.text = "Drop [E]";
    }

    private void PickUpAnimal()
    {
        pickupText.text = "Drop [E]";
        isHolding = true;

        closestPickup.GetComponent<AnimalMovement>().StopMoving();


    }
}
