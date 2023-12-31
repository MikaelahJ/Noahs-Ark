using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoatAnimalCounter : MonoBehaviour
{
    private GameManager gameManager;
    private EntityManager playerManager;

    private AnimalCanvasUI animalBoard;

    public List<GameObject> animalsOnBoat = new List<GameObject>();
    public Dictionary<string, int> animalBools = new Dictionary<string, int>();

    void Start()
    {
        gameManager = GameManager.GetInstance();
        playerManager = EntityManager.GetInstance();
        animalBoard = LevelManager.instance.animalCanvasScript;
    }

    public void addAnimalsToAnimalBools(List<string> animals)
    {
        foreach (var animal in animals)
        {
            animalBools.Add(animal, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickupable"))
        {
            if (playerManager.isHolding && animalsOnBoat.Contains(playerManager.animalHeld))
            {
                animalsOnBoat.Remove(playerManager.animalHeld);

                if (animalBools.ContainsKey(collision.gameObject.name))
                {
                    animalBools[collision.gameObject.name] -= 1;
                    Debug.Log("removed" + animalBools[collision.gameObject.name]);
                    animalBoard.UpdateBoard(collision.gameObject.name, animalBools[collision.gameObject.name]);
                }
            }
            else if (!animalsOnBoat.Contains(collision.gameObject))
            {
                animalsOnBoat.Add(collision.gameObject);

                if (animalBools.ContainsKey(collision.gameObject.name))
                {
                    animalBools[collision.gameObject.name] += 1;
                    Debug.Log("added to existing" + animalBools[collision.gameObject.name]);
                    animalBoard.UpdateBoard(collision.gameObject.name, animalBools[collision.gameObject.name]);
                }

                isBoatFull();
            }
        }
    }

    private void isBoatFull()
    {
        bool allBoolsTrue = animalBools.Values.All(value => value == 2);

        if (allBoolsTrue)
        {
            gameManager.FinishedLevel();

            //Add the animals and player as children so they follow when the boat moves
            FindObjectOfType<PlayerMovement>().transform.parent = this.transform.parent;
            foreach (GameObject animal in animalsOnBoat)
            {
                animal.transform.parent = this.transform.parent;
            }
        }
    }
}
