using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveData : MonoBehaviour
{
    

    void Start()
    {

        bool endless = ChooseLevel.GetMode();
        bool hard = ChooseLevel.GetDifficulty();
        int index = SceneManager.GetActiveScene().buildIndex;
        if (!hard && !endless)
        {
            if (PlayerPrefs.GetInt("NormalLevel") < index)
            {
                PlayerPrefs.SetInt("NormalLevel", index);
            }
        }
        else if (hard && !endless)
        {
            if (PlayerPrefs.GetInt("HardLevel") < index)
            {
                PlayerPrefs.SetInt("HardLevel", index);
            }
        }
    }

    void Update()
    {
        int highscore = EatFood.scoreValue;
        bool endless = ChooseLevel.GetMode();
        if (endless)
        {
            if (PlayerPrefs.HasKey("Highscore"))
            {
                if (EatFood.scoreValue > PlayerPrefs.GetInt("Highscore"))
                {
                    PlayerPrefs.SetInt("Highscore", EatFood.scoreValue);
                }
            }
            else
            {
                PlayerPrefs.SetInt("Highscore", EatFood.scoreValue);
            }
        }
    }
    

}

