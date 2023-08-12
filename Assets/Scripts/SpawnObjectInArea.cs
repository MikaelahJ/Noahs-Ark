using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpawnObjectInArea : MonoBehaviour
{
    public GameObject spawnAreaObject;
    public int maxAttemts = 100;
    public float minDistanceBetweenSpawns = 2f;

    private List<Vector2> spawnedPositions = new List<Vector2>();

    public void SpawnObject(GameObject obj)
    {
        Vector2 randomPoint = GenerateRandomPoint();
        if (IsFarEnoughFromOthers(randomPoint))
        {
            GameObject newObj = Instantiate(obj, randomPoint, Quaternion.identity);
            spawnedPositions.Add(randomPoint);
        }
    }

    private Vector2 GenerateRandomPoint()
    {
        Bounds spawnBounds = CalculateSpawnBounds();

        for (int i = 0; i < maxAttemts; i++)
        {
            Vector2 randomPoint = new Vector2(
                UnityEngine.Random.Range(spawnBounds.min.x, spawnBounds.max.x),
                UnityEngine.Random.Range(spawnBounds.min.y, spawnBounds.max.y)
            );

            if (IsPointWithinSpawnArea(randomPoint))
                return randomPoint;
        }

        Debug.LogWarning("Could not find valid spawnpoint");
        return Vector2.zero;
    }

    private Bounds CalculateSpawnBounds()
    {
        //calculate overall area of polygon colliders
        Bounds spawnBounds = new Bounds(spawnAreaObject.transform.position, Vector3.zero);

        foreach (PolygonCollider2D collider in spawnAreaObject.GetComponents<PolygonCollider2D>())
            spawnBounds.Encapsulate(collider.bounds);

        return spawnBounds;
    }

    private bool IsPointWithinSpawnArea(Vector2 point)
    {
        foreach(PolygonCollider2D collider in spawnAreaObject.GetComponents<PolygonCollider2D>())
        {
            if(collider.OverlapPoint(point)) 
                return true;
        }

        return false;
    }

    private bool IsFarEnoughFromOthers(Vector2 point)
    {
        foreach (Vector2 existingPosition in spawnedPositions)
        {
            if(Vector2.Distance(point, existingPosition) < minDistanceBetweenSpawns) 
                return false; //too close to another spawned object
        }

        return true;
    }
}
