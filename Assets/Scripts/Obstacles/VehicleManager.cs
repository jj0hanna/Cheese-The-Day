using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Obstacles.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class VehicleManager : MonoBehaviour
{
    
    public VehicleTemplate[] Obstacles;
    public float vehicleCooldown;
    [RangeAttribute(0, 2)]public float vehicleRandomness;
    
   // private List<GameObject> Vehicles; potential use in preventing too many vehicles
    private float _timeSinceSpawn;
    // Start is called before the first frame update
    void Awake()
    {
        //Vehicles = new List<GameObject>();
        //Vehicles.Add(transform.GetChild(i));
    }
 
    private void Update()
    {
        if (_timeSinceSpawn > vehicleCooldown)
        {
            SpawnVehicle(transform);
            _timeSinceSpawn = Random.Range(-vehicleRandomness, vehicleRandomness) * vehicleCooldown;
        }
        else
        {
            _timeSinceSpawn += Time.deltaTime;
        }
    }
    private void SpawnVehicle(Transform position)
    {
        VehicleTemplate potentialVehicle = Obstacles[Random.Range(0, Obstacles.Length)];
        if (potentialVehicle.weight >= Random.Range(0, 100))
        {
            GameObject instantiated = Instantiate(potentialVehicle.prefab, transform, true);
            instantiated.transform.position = position.position + Vector3.forward * Random.Range(-2,2);
            instantiated.transform.rotation = position.rotation;
            instantiated.transform.Rotate(new Vector3(0,90,0));
            //Vehicles.Add(instantiated);
        }
        else
        { 
            SpawnVehicle(position);
        }
    }
    public void RemoveVehicle(GameObject vehicle)
    {
        //Vehicles.Remove(vehicle);
        Destroy(vehicle);
    }
}
