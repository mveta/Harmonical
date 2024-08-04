using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenuManager : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown graphicsDropdown;
    [SerializeField]
    Slider volumeSlider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");

    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    public void GraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }
    

    
}//class
