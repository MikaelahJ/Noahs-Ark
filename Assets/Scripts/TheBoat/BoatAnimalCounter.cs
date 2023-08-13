using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoatAnimalCounter : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerManager playerManager;

    public List<GameObject> animalsOnBoat = new List<GameObject>();
    public Dictionary<string, int> animalBools = new Dictionary<string, int>();

    void Start()
    {
        gameManager = GameManager.GetInstance();
        playerManager = PlayerManager.GetInstance();
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
                }
            }
            else if (!animalsOnBoat.Contains(collision.gameObject))
            {
                animalsOnBoat.Add(collision.gameObject);

                if (animalBools.ContainsKey(collision.gameObject.name))
                {
                    animalBools[collision.gameObject.name] += 1;
                    Debug.Log("added to existing" + animalBools[collision.gameObject.name]);
                }
                UpdateUI();
                isBoatFull();
            }
        }
    }

    private void UpdateUI()
    {
        
    }

    private void isBoatFull()
    {
        bool allBoolsTrue = animalBools.Values.All(value => value == 2);

        if (allBoolsTrue)
            gameManager.FinishedLevel();
    }





}
