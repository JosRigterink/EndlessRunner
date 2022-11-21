using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text highscoreText;
    [SerializeField] TMP_Text coinText;
    
    void Start()
    {
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        coinText.text = "Coins: " + PlayerPrefs.GetInt("Coins").ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("EndlessRunner");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void LoadCharacterScene()
    {
        SceneManager.LoadScene("CharacterSelectionScene");
    }
}
