using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private float speed = 5f;

    void Start()
    {

    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
