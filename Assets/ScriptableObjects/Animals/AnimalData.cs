using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class AnimalData : ScriptableObject
{
    public Sprite animalSprite;
    public RuntimeAnimatorController animController;

    public string animalType;

    public float rotationSpeed = 3f; //for animation

    public float throwDistance = 10f; //for movement
    public float throwDrag = 3f;
    public float moveRadius = 5f;
    public float moveSpeed = 3f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 5f;
}
