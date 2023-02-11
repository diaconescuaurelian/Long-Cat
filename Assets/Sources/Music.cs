using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        
        Play();
    }
    public void Play()
    {
        musicSource = gameObject.GetComponent<AudioSource>();
        musicSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            musicSource.pitch *= 0.5f;
        }
        else
        {
            musicSource.pitch = 1f;
        }
        if (EatFood.CheckScore())
        {
            musicSource.Pause();
        }
    }
}
