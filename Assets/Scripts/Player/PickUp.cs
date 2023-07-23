using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    private PlayerManager playerManager;

    [SerializeField] private TextMeshProUGUI pickupText;
    [SerializeField] private Transform holdingPos;

    private List<GameObject> pickupsInRadius = new List<GameObject>();

    public GameObject closestPickup;

    private void Start()
    {
        playerManager = PlayerManager.GetInstance();
    }

    private void Update()
    {
        if (closestPickup != null && Input.GetKeyDown(KeyCode.E))
        {
            if (playerManager.isHolding)
            {
                GetComponent<Drop>().DropOrThrow(closestPickup);
                playerManager.isHolding = false;
                pickupText.text = "";
            }
            else 
                PickUpAnimal();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Pickupable") || playerManager.isHolding)
            return;

        pickupsInRadius.Add(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
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

        if (playerManager.isHolding)
            pickupText.text = "Drop [E]";
    }

    private void PickUpAnimal()
    {
        pickupText.text = "Drop [E]";
        playerManager.isHolding = true;

        closestPickup.layer = 6;
        closestPickup.GetComponent<AnimalMovement>().StopMoving();
        closestPickup.transform.SetParent(holdingPos);
        closestPickup.transform.position = holdingPos.position;
        closestPickup.GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
