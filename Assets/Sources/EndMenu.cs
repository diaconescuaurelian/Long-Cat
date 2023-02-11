using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text youWin;
    [SerializeField] private TMP_Text youLost;
    [SerializeField] private TMP_Text gameOver;
    [SerializeField] private TMP_Text highscore;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text highscoreValue;
    // Start is called before the first frame update
    void Start()
    {
        
        if (HealthController.GetPlayerHealth() > 0 && !ChooseLevel.GetMode())
        {
            PlayerPrefs.DeleteKey("SessionStarted");
            youWin.gameObject.SetActive(true);
            youLost.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(false);
            highscore.gameObject.SetActive(false);
            score.gameObject.SetActive(false);
            highscoreValue.gameObject.SetActive(false);
        }
        else if (HealthController.GetPlayerHealth() == 0 && !ChooseLevel.GetMode())
        {
            PlayerPrefs.DeleteKey("SessionStarted");
            youLost.gameObject.SetActive(true);
            youWin.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(false);
            highscore.gameObject.SetActive(false);
            score.gameObject.SetActive(false);
            highscoreValue.gameObject.SetActive(false);
        }
        else if (ChooseLevel.GetMode())
        {
            gameOver.gameObject.SetActive(true);
            youLost.gameObject.SetActive(false);
            youWin.gameObject.SetActive(false);
            if (EatFood.scoreValue < PlayerPrefs.GetInt("Highscore"))
            {  
                score.gameObject.SetActive(true);
                highscore.gameObject.SetActive(false);
                highscoreValue.gameObject.SetActive(true);
                highscoreValue.text = Convert.ToString(EatFood.scoreValue);
            }
            else 
            {  
                highscore.gameObject.SetActive(true);
                score.gameObject.SetActive(false);
                highscoreValue.gameObject.SetActive(true);
                highscoreValue.text = Convert.ToString(PlayerPrefs.GetInt("Highscore"));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
