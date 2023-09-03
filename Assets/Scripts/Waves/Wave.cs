using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Wave : MonoBehaviour
{
    [SerializeField] Tilemap waveTilemap;
    [SerializeField] RuleTile waterTile;

    private float speed = 5f;

    Vector3Int intPos;
    void Start()
    {

    }

    void Update()
    {
        intPos = Vector3Int.FloorToInt(transform.position);
        if (!waveTilemap.HasTile(intPos))
        {
            for (int i = -5; i < 5; i++)
            {
                Debug.Log(intPos.x + i);
                waveTilemap.SetTile(new Vector3Int(intPos.x + i, intPos.y, intPos.z), waterTile);
            }

        }
        transform.position += transform.up * speed * Time.deltaTime;
    }


}
