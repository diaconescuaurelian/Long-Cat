using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GetHighscore : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    private GameObject scoreObject;
    // Start is called before the first frame update
    void Start()
    {
         scoreObject = GameObject.FindGameObjectWithTag("Highscore");
         score = scoreObject.GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("Highscore"))
        {
            int highscore = PlayerPrefs.GetInt("Highscore");
            score.text = Convert.ToString(highscore);
        }
        else
        {
            score.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
