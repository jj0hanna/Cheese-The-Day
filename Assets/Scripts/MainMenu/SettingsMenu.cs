using System;
using System.Collections.Generic;
using Audio;
using ScriptableObjects.Player.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Dropdowns")]
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown fullscreenModeDropdown;
    [SerializeField] private TMP_Dropdown graphicsQualityDropdown;
    
    [Header("Sliders")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider cameraSensitivitySlider;
    
    [Header("Camera Variables")]
    [SerializeField] private CameraScriptable cameraSensScriptable;
    
    private Resolution[] resolutions;
    
    private void Awake()
    {
        SetupResolutions();
        SetupFullscreenMode();
        SetupGraphicsQuality(); 
    }

    private void OnEnable()
    {
        UpdateSliders();
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreenMode(int index)
    {
        Screen.fullScreenMode = (FullScreenMode) index;
    }

    public void SetGraphicsQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetMasterVolume(float value)
    {
        AudioManager.setMasterVolume(value);
        PlayerPrefs.SetFloat("masterVolume", value);
        PlayerPrefs.Save();
    }
    
    public void SetMusicVolume(float value)
    {
        AudioManager.setTypeVolume(SoundType.Music, value);
        PlayerPrefs.SetFloat("musicVolume", value);
        PlayerPrefs.Save();
    }
    
    public void SetSFXVolume(float value)
    {
        AudioManager.setTypeVolume(SoundType.SFX, value);
        PlayerPrefs.SetFloat("sfxVolume", value);
        PlayerPrefs.Save();
    }

    public void SetCameraSensitivity(float value)
    {
        cameraSensScriptable.sensitivityMultiplier = value;
        PlayerPrefs.SetFloat("cameraSensitivity", value);
        PlayerPrefs.Save();
    }
    
    private void SetupResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>(resolutions.Length);
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].ToString());
            
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void SetupFullscreenMode()
    {
        fullscreenModeDropdown.ClearOptions();

        List<string> options = new List<string>()
        {
            "Exclusive Fullscreen",
            "Windowed Fullscreen",
            "Windowed Maximized",
            "Windowed"
        };
        
        fullscreenModeDropdown.AddOptions(options);
        fullscreenModeDropdown.value = (int) Screen.fullScreenMode;
        resolutionDropdown.RefreshShownValue();
    }
 
    private void SetupGraphicsQuality()
    {
        graphicsQualityDropdown.value = QualitySettings.GetQualityLevel();
    }

    private void UpdateSliders()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            float value = PlayerPrefs.GetFloat("musicVolume");
            musicSlider.SetValueWithoutNotify(value);
        }
        
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            float value = PlayerPrefs.GetFloat("masterVolume");
            masterSlider.SetValueWithoutNotify(value);
        }
        
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            float value = PlayerPrefs.GetFloat("sfxVolume");
            sfxSlider.SetValueWithoutNotify(value);
        }

        if (PlayerPrefs.HasKey("cameraSensitivity"))
        {
            float value = PlayerPrefs.GetFloat("cameraSensitivity");
            cameraSensitivitySlider.SetValueWithoutNotify(value);
        }
    }
}
