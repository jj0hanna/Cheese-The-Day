using System;
using System.Collections;
using UnityEngine;
//TODO: Use Rigidbody, Use physicsmaterial with high bounce. Give more player feedback
public class VehicleMovement : MonoBehaviour
{
    public float speed;
    private VehicleManager _manager;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _manager = transform.parent.GetComponent<VehicleManager>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.forward * speed; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarExit"))
        { 
            _manager.RemoveVehicle(gameObject);
        }
    }
}
