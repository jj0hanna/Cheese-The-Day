using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Obstacles.Scripts
{
    [CreateAssetMenu(fileName = "new Obstacle", menuName = "ScriptableObstacle")]
    public class ObstacleTemplate: ScriptableObject
    {
        public GameObject prefab;
        public float weight;
        public bool major;
    }
}
