using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private GameObject levelTitle;
    [SerializeField] private TMP_Text title;
    private string titleText;
    // Start is called before the first frame update
    void Awake()
    {
        levelTitle = GameObject.FindGameObjectWithTag("Title");
        title = levelTitle.GetComponent<TextMeshProUGUI>();
        SetTitleContent();
        StartCoroutine(TitleDissapear());
    }
    void Start()
    {
        if(GameIsPaused)
        {
            Resume();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    //Resumes the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    //Pause the game if it's not already paused (if it's not in the first 2 seconds after a scene is loaded)
    void Pause()
    {
        if (Time.timeScale > 0)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
    public void Restart()
    {
        if (!PlayerPrefs.HasKey("SessionStarted"))
        {
            PlayerPrefs.SetInt("SessionStarted", 1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    //Loads the Start menu
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    //Sets the text for the title at the start of a scene
    private void SetTitleContent()
    {
        if (ChooseLevel.GetMode())
        {
            title.text = "Endless";
        }
        else
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            titleText = "Level " + currentSceneIndex.ToString();
            title.text = titleText;
        }
    }
    //Pauses the scene for 2 seconds and then disables the title with the level Number of the current scene
    private IEnumerator TitleDissapear()
    {
        Time.timeScale = 0;
        float pauseEndTime = Time.realtimeSinceStartup + 1.5f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        levelTitle.SetActive(false);
        Time.timeScale = 1;
    }
}
