using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Timer
    public float currentTime;
    public float startingTime;
    public bool timerOn;
    [SerializeField] Text countDownText;

    public int coins;
    public int bubbleWater;
    public static GameManager inst;
    public GameObject player;
    public bool newHighScore;

    public int distance;
    public Text highScore;
    public Text coinText;
    public Text uiDistance;
    public Text bubbleWaterText;
    public int scoreMultiplier = 1;
    public int coinMultiplier = 1;
    public int bubbleWaterMultiplier = 1;

    public int coinsInRun;
    public int waterInRun;
    public int powerUpInRun;
    public Text powerUpText;
    public Text doubleScoreText;

    public int currentCharacterIndex = 0;

    [SerializeField] PlayerMovement playerMovement;

    public void AddScore()
    {
        coins += coinMultiplier;
        coinsInRun++;
    }

    public void AddBubbleWater()
    {
        bubbleWater += bubbleWaterMultiplier;
        waterInRun++;
    }

    public void MoveSpeedIncrease()
    {
        //increase playerspeed
        player.GetComponent<PlayerMovement>().speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake()
    {
        inst = this;
    }

    public void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        player = GameObject.FindGameObjectWithTag("CharacterHolder").GetComponent<CharacterSelector>().characters[currentCharacterIndex];
        Cursor.lockState = CursorLockMode.Locked;
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        coins = PlayerPrefs.GetInt("Coins", coins);
        bubbleWater = PlayerPrefs.GetInt("BubbleWater", bubbleWater);
    }

    public void Update()
    {
        PlayerPrefs.SetInt("BubbleWater", bubbleWater);
        bubbleWaterText.text = "Water: " + bubbleWater;
        coinText.text = "Coins: " + coins;
        PlayerPrefs.SetInt("Coins", coins);
        distance = Mathf.RoundToInt(player.transform.position.z) * scoreMultiplier;
        uiDistance.text = distance.ToString() + "m ";
        HighScore();

        if (timerOn == true)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");
            if (currentTime < 0)
            {
                countDownText.text = "";
                timerOn = false;
            }
        }
    }

    public void HighScore()
    {
        if (distance > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", distance);
            highScore.text = "HighScore: " + distance.ToString();

            if (!newHighScore)
            {
                newHighScore = true;
            }
        }
    }

    public void EndOfDoublePoint()
    {
        GameManager.inst.scoreMultiplier = 1;
    }

    public void EndOfDoubleCoins()
    {
        GameManager.inst.coinMultiplier = 1;
        powerUpText.text = ("");
    }

    public void EndOfDoubleWater()
    {
        GameManager.inst.bubbleWaterMultiplier = 1;
        powerUpText.text = ("");
    }
}
