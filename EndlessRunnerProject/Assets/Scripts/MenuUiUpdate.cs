using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUiUpdate : MonoBehaviour
{
    public int highscore;
    public Text highscoreText;
    // Start is called before the first frame update
    public void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", highscore);
        highscoreText.text = ("HighScore: " + highscore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
