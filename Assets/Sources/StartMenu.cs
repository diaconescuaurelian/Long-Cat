using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject ChooseLevel;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject MainMenu;
    public Slider volumeSlider;
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        
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
    public void SetVolume(float volume)
    {
        //mixer.SetFloat("volume",volumeSlider.value);
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
}
