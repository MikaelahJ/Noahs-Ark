using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAnimalCounter : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerManager playerManager;

    public List<GameObject> AnimalsOnBoat = new List<GameObject>();

    void Start()
    {
        gameManager = GameManager.GetInstance();
        playerManager = PlayerManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickupable"))
        {
            if (playerManager.isHolding && AnimalsOnBoat.Contains(playerManager.animalHeld))
            {
                AnimalsOnBoat.Remove(playerManager.animalHeld);
                Debug.Log("remove");
            }
            else if(!AnimalsOnBoat.Contains(collision.gameObject))
            {
                AnimalsOnBoat.Add(collision.gameObject);
                Debug.Log("add");

            }
        }
    }



    /*TODO
     * list of all animals in boat
     * add and remove on the trigger collider DONE
     * update to GameManager 
     * update some sort of UI to show how many animals you have and how many are left on the island
     * if the list is full send signal to GameManager to start the boat and PlayerManager.canMove = false
     * 
     * BUG
     * can throw through walls
     */

}
