using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class ChooseLevel : MonoBehaviour
{
    [SerializeField] private Button hardButton;
    [SerializeField] private Button normalButton;
    [SerializeField] private Color newColor;
    [SerializeField] private Color defaultColor;
    [SerializeField] private static bool hard = false;
    [SerializeField] private static bool endless = false;
    [SerializeField] Image normalButtonInage;
    [SerializeField] Image hardButtonInage;
    [SerializeField] int normalLevel = 1;
    [SerializeField] int hardLevel = 1;
    [SerializeField] private Button[] normalLevels;
    [SerializeField] private Button[] levelsLocked;
    [SerializeField] private Button[] hardLevels;
    [SerializeField] private GameObject ChooseLevelObject;
    [SerializeField] private GameObject MainMenu;
    void Awake()
    {
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        endless = false;
        hard = false;
        normalButtonInage = normalButton.GetComponent<Image>();
        hardButtonInage = hardButton.GetComponent<Image>();
        SetUnlockedLevels();
        if (hard)
        {
            hardButtonInage.color = newColor;
            normalButtonInage.color = defaultColor;
        }
        else
        {
            normalButtonInage.color = newColor;
            hardButtonInage.color = defaultColor;
        }
        for (int i = 0; i < normalLevel; i++)
        {
            int a = i;
            normalLevels[i].gameObject.SetActive(true);
            normalLevels[i].GetComponent<Button>().onClick.AddListener(() => { LoadLevel(a); });
        }
        for (int i = normalLevel; i < normalLevels.Length; i++)
        {
            normalLevels[i].gameObject.SetActive(false);
            levelsLocked[i].gameObject.SetActive(true);
        }
    }
    //Sets the variables used to enable the buttons for the unlocked levels according to the player prefs
    public void SetUnlockedLevels()
    {
        if (PlayerPrefs.HasKey("NormalLevel"))
        {
            if (normalLevel < PlayerPrefs.GetInt("NormalLevel"))
            {
                normalLevel = PlayerPrefs.GetInt("NormalLevel");
            }
        }
        if (PlayerPrefs.HasKey("HardLevel"))
        {
            if (hardLevel < PlayerPrefs.GetInt("HardLevel"))
            {
                hardLevel = PlayerPrefs.GetInt("HardLevel");
            }
        }
    }

    //Method that is called when the "Normal" button is pressed
    //It enables the buttons coresponding to the unlocked normal levels, and disables the buttons for the hard levels
    public void SelectNormal()
    {
        hard = false;
        endless = false;
        normalButtonInage.color = newColor;
        hardButtonInage.color = defaultColor;
        for (int i = 0; i < normalLevel; i++)
        {
            int a = i;
            normalLevels[i].gameObject.SetActive(true);
            normalLevels[i].GetComponent<Button>().onClick.AddListener(() => { LoadLevel(a); });
            levelsLocked[i].gameObject.SetActive(false);
        }
        for (int j = normalLevel; j < normalLevels.Length; j++)
        {
            normalLevels[j].gameObject.SetActive(false);
            levelsLocked[j].gameObject.SetActive(true);
        }
        for (int k = 0; k < hardLevels.Length; k++)
        {
            hardLevels[k].gameObject.SetActive(false);
        }
    }
    //Method that is called when the "Hard" button is pressed
    //It enables the buttons coresponding to the unlocked hard levels, and disables the buttons for the normal levels
    public void SelectHard()
    {
        hard = true;
        endless = false;
        hardButtonInage.color = newColor;
        normalButtonInage.color = defaultColor;
        for (int i = 0; i < hardLevel; i++)
        {
            int a = i; //this is the variable that will be checked to see whick case will be taken in LoadLevel
            hardLevels[i].gameObject.SetActive(true);
            hardLevels[i].GetComponent<Button>().onClick.AddListener(() => { LoadLevel(a); });
            levelsLocked[i].gameObject.SetActive(false);
        }
        for (int j = hardLevel; j < hardLevels.Length; j++)
        {
            hardLevels[j].gameObject.SetActive(false);
            levelsLocked[j].gameObject.SetActive(true);
        }
        for (int k = 0; k < hardLevels.Length; k++)
        {
            normalLevels[k].gameObject.SetActive(false);
        }
    }

    //Loads the scene where the player is playing to get a gighscore, not to get to the next level
    public void SelectEndless()
    {
        endless = true;
        SceneManager.LoadScene(11);
    }
    
    public static bool GetDifficulty()
    {
        return hard;
    }

    public static bool GetMode()
    {
        return endless;
    }
    //Loads a scene according to the variable "a" asigned to each button
    public void LoadLevel(int a)
    {
        switch(a)
        {
            case 0:   
                SceneManager.LoadScene(1);
                break;
            case 1:   
                SceneManager.LoadScene(2);
                break;
            case 2:   
                SceneManager.LoadScene(3);
                break;
            case 3:   
                SceneManager.LoadScene(4);
                break;
            case 4:   
                SceneManager.LoadScene(5);
                break;
            case 5:   
                SceneManager.LoadScene(6);
                break;
            case 6:   
                SceneManager.LoadScene(7);
                break;
            case 7:   
                SceneManager.LoadScene(8);
                break;
            case 8:   
                SceneManager.LoadScene(9);
                break;
            case 9:   
                SceneManager.LoadScene(10);
                break;
        }
    }
    public void CloseChooseLevelMenu()
    {
        MainMenu.gameObject.SetActive(true);
        ChooseLevelObject.gameObject.SetActive(false);
    }

}
