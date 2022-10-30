using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject newHighScoreScreen;
    public Button keepPlayingButton;
    public int keepPlayPrice;



   public void OnEnable()
    {
        if (GameManager.inst.newHighScore == true)
        {
            Invoke("HighScoreScreen", 0.5f);
        }

        if (keepPlayPrice > PlayerPrefs.GetInt("BubbleWater", GameManager.inst.bubbleWater))
        {
            keepPlayingButton.interactable = false;
        }
    }
   
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void KeepPlaying()
    {
        if (keepPlayPrice <= PlayerPrefs.GetInt("BubbleWater", GameManager.inst.bubbleWater))
        {
            GameManager.inst.bubbleWater -= keepPlayPrice;
            PlayerPrefs.SetInt("BubbleWater", GameManager.inst.bubbleWater);
            gameOverScreen.SetActive(false);
            GameManager.inst.player.GetComponent<PlayerMovement>().alive = true;
            GameManager.inst.player.GetComponent<CapsuleCollider>().isTrigger = true;
            GameManager.inst.player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

            keepPlayingButton.interactable = false;
            Cursor.lockState = CursorLockMode.Locked;
     
            GameManager.inst.player.GetComponent<PlayerMovement>().speed -= 2;

            GameManager.inst.currentTime = 8;
            GameManager.inst.timerOn = true;

            Invoke("CanDieAgain", 8);
        }
    }

    public void CanDieAgain()
    {
        GameManager.inst.player.GetComponent<CapsuleCollider>().isTrigger = false;
        GameManager.inst.player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GameManager.inst.player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void HighScoreScreen()
    {
        newHighScoreScreen.SetActive(true);
        newHighScoreScreen.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

}
