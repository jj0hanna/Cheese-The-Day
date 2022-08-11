using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using ScriptableObjects.Player.Scripts;
using UnityEngine;

public class SettingsInitializer : MonoBehaviour
{
    [SerializeField] private CameraScriptable cameraScriptable;
    
    private void Awake()
    {
        LoadVolumeSettings();
        LoadCameraSettings();
    }

    private void LoadVolumeSettings()
    {
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            AudioManager.masterVolume = PlayerPrefs.GetFloat("masterVolume");
        }

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            AudioManager.setTypeVolume(SoundType.Music, PlayerPrefs.GetFloat("musicVolume"));
        }
        
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            AudioManager.setTypeVolume(SoundType.SFX, PlayerPrefs.GetFloat("sfxVolume"));
        }
    }

    private void LoadCameraSettings()
    {
        if (PlayerPrefs.HasKey("cameraSensitivity"))
        {
            cameraScriptable.sensitivityMultiplier = PlayerPrefs.GetFloat("cameraSensitivity");
        }
        else
        {
            cameraScriptable.sensitivityMultiplier = 0.2f;
        }
    }
}
