using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableObjects.Obstacles.Scripts
{
    [CreateAssetMenu(fileName = "new Vehicle", menuName = "ScriptableVehicle")]
    public class VehicleTemplate: ScriptableObject
    {
        public GameObject prefab;
        public float weight;
    }
}

