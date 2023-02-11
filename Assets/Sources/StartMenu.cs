using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject ChooseLevel;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject MainMenu;
    public Slider volumeSliderSFX;
    public Slider volumeSliderMusic;
    public AudioMixer mixer;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            volumeSliderMusic.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            volumeSliderSFX.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PauseMenu.GameIsPaused)
        {
            Time.timeScale = 1f;
            PauseMenu.GameIsPaused = false;
        }
        mixer.SetFloat("MusicVolume",volumeSliderMusic.value);
        mixer.SetFloat("SFXVolume",volumeSliderSFX.value);

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int resolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = resolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Play()
    {
        ChooseLevel.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }
    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume",volumeSliderSFX.value);
        PlayerPrefs.SetFloat("SFXVolume", volumeSliderSFX.value);
    }
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume",volumeSliderMusic.value);
        PlayerPrefs.SetFloat("MusicVolume", volumeSliderMusic.value);
    }
    public void settingsBack()
    {
        MainMenu.gameObject.SetActive(true);
        SettingsMenu.gameObject.SetActive(false);
    }
    public void OpenSettingsMenu()
    {
        SettingsMenu.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }
    public void ToggleFullscreen(bool isFulscreen)
    {
        Screen.fullScreen = isFulscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
