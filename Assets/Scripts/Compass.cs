using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Timeline;

public class Compass : MonoBehaviour
{
    [Header("Marker")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform destinationTransform;
    [Header("Arrow")]
    [SerializeField] private Transform needleTransform;

    private Transform compassArrowTransform;
    private Vector2 destination;

    private void Awake()
    {
        compassArrowTransform = GetComponent<Transform>();
        CacheDestinationVector();
    }

    private void Update()
    {
        UpdateMarker();
        UpdateArrow();
    }

    private void UpdateMarker()
    {
        // Convert destination & player Vector3s into Vector2s
        Vector3 pos = cameraTransform.position;
        Vector2 playerPos = new Vector2(pos.x, pos.z);
        Vector3 forward = cameraTransform.forward;
        Vector2 playerForward = new Vector2(forward.x, forward.z);

        // Get the angle, inverted
        float angle = -Vector2.SignedAngle(destination - playerPos, playerForward);

        compassArrowTransform.localEulerAngles = new Vector3(0f, 0f, angle);
    }

    private void UpdateArrow()
    {
        Vector3 direction = new Vector3
        {
            z = cameraTransform.eulerAngles.y
        };
        needleTransform.localEulerAngles = direction;
    }

    private void CacheDestinationVector()
    {
        Vector3 destinationVector = destinationTransform.position;
        destination = new Vector2(destinationVector.x, destinationVector.z);
    }
}
