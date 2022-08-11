using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInteract : MonoBehaviour
{
    public float disableTime;
    public float forceOnPlayer;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.rigidbody.velocity *= -0.5f;
            other.rigidbody.AddForceAtPosition(-other.GetContact(0).normal * forceOnPlayer * 10, other.GetContact(0).point,ForceMode.Impulse);
            other.gameObject.GetComponent<player_movement>().DisableControls(disableTime);
        }
    }
}
  