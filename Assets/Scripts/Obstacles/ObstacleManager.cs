using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Obstacles.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleTemplate[] Obstacles;
    
    private List<Transform> majorPositions;
    // Start is called before the first frame update
    void Awake()
    {
        majorPositions = new List<Transform>();
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                majorPositions.Add(transform.GetChild(i));
            }
        }
        else
        {
            Debug.LogError("No Child positions found in manager!");
        }
    }

    private void Start()
    {
        if (majorPositions.Count > 0)
        {
            foreach (Transform position in majorPositions)
            {
                SpawnObstacle(position);
            }
        }
    }

    private void SpawnObstacle(Transform position)
    {
        ObstacleTemplate potentialObstacle = Obstacles[Random.Range(0, Obstacles.Length)];
        if (potentialObstacle.weight >= Random.Range(0, 100))
        {
            GameObject instantiated = Instantiate(potentialObstacle.prefab);
            instantiated.transform.position = position.position;
        }
        else
        {
            SpawnObstacle(position);
        }
    }
}
