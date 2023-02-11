using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private static int playerHealth = 3;
    [SerializeField] private Image[] hearts;
    private static HealthController instance;
    public AudioClip soundEffectClip;
    private AudioSource soundEffectSource;
    




    private void Awake()
    {
        if (playerHealth == 0)
        {
            playerHealth = 3;
        }
        SetHealth();
        /*
        PlayerPrefs.DeleteKey("NormalLevel");
        PlayerPrefs.DeleteKey("HardLevel");
        PlayerPrefs.DeleteKey("Highscore");
        */
        if (!ChooseLevel.GetMode())
        {
            UpdateHealth();
        }
        AudioSource[] audioSources = GetComponents<AudioSource>();
        soundEffectSource = audioSources[2];
        soundEffectClip = soundEffectSource.clip;
        //reset the session if the number of lives goes to 0
    }
    private void Start()
    {
        //If the current level is not the one with endless mode
        
    }
    //Set the number of lives. If it's a new session set it to 3. Else get the number of lives from the player prefs.
    public void SetHealth()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (!PlayerPrefs.HasKey("SessionStarted"))
        {
            playerHealth = 3;
            PlayerPrefs.SetInt("PlayerHealth", playerHealth);
            PlayerPrefs.SetInt("SessionStarted", 1);
        }
        else
        {
            playerHealth = PlayerPrefs.GetInt("PlayerHealth");
        }
    }
    //Update the color of the hearts representing the lives of the player according to the playerHealth.
    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.gray;
            }
        }
    }
    //Decrement the playerHealth on collision and start the coroutine to wait 2 seconds so the level doesn't restart instantly.
    void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "Body" || collision.gameObject.tag == "Obstacle") && !ChooseLevel.GetMode())
        {
            playerHealth--;
            PlayerPrefs.SetInt("PlayerHealth", playerHealth);
            if (playerHealth > 0)
            {   
                StartCoroutine(WaitTwoSeconds());
            }
            else
            {
                StartCoroutine(LoadEndMenu());
            }
        }
        else if ((collision.gameObject.tag == "Body" || collision.gameObject.tag == "Obstacle") && ChooseLevel.GetMode())
        {
            StartCoroutine(LoadEndMenu());
        }
    }
    //Play the sound effect
    public void PlaySoundEffect()
    {
        soundEffectSource.PlayOneShot(soundEffectClip);
    }
    //stop the time for 2 seconds and the reload the current scene
    private IEnumerator WaitTwoSeconds()
    {
        PlaySoundEffect();
        Time.timeScale = 0;
        float pauseEndTime = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Same as the coroutine above but it loads the end menu scene
    private IEnumerator LoadEndMenu()
    {
        PlaySoundEffect();
        Time.timeScale = 0;
        float pauseEndTime = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(12);
    }
    public static int GetPlayerHealth()
    {
        return playerHealth;
    }
    
}
