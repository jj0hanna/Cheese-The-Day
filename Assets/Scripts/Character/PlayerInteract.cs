using System;
using System.Collections;
using System.Collections.Generic;
using Animation;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    
    public CheeseInventoryAnimation CheeseinventoryAnimation;

    [SerializeField] private LayerMask triggerLayerMask;

    private Vector3 boxSize = new Vector3(2,2,2);
    private player_controls_script _playerControls;

    private void Awake()
    {
        _playerControls = new player_controls_script();
        _playerControls.player_map.Buy.performed += Buy;
        _playerControls.player_map.ToggleInv.performed += ToggleInv;
        _playerControls.player_map.UnToggleInv.performed += UnToggleInv;
    }
    private void OnEnable()
    {
        _playerControls.player_map.Enable();
    }
    private void OnDisable()
    {
        _playerControls.player_map.Disable();
    }

    private void ToggleInv(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CheeseinventoryAnimation.ToggleInv();
        } 
    }
    private void UnToggleInv(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CheeseinventoryAnimation.ToggleInvRelease();
        }
    }

    private void Buy(InputAction.CallbackContext context)
    {
        CheckInteraction();
    }
    
    private void CheckInteraction()
    {
        Collider[] hits = Physics.OverlapBox(transform.position, boxSize, Quaternion.identity, triggerLayerMask);
        if (hits.Length != 0)
        {
            foreach (Collider rc in hits)
            {
                if (rc.transform.TryGetComponent(out Interactable component))
                {
                    component.Interact();
                }
                return;
            }
        }
    }
}
