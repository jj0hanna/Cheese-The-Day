using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerPauseMenu : MonoBehaviour
{
    public UnityEvent OnEscapePressed;
    
    private player_controls_script _playerControls;
    private void Awake()
    {
        _playerControls = new player_controls_script();
        _playerControls.player_map.Escape.performed += EscapePressed;
    }
    private void OnEnable()
    {
        _playerControls.player_map.Enable();
    }
    private void OnDisable()
    {
        _playerControls.player_map.Disable();
    }
    
    private void EscapePressed(InputAction.CallbackContext context)
    {
        OnEscapePressed?.Invoke();
    }

}
