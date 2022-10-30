using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        PlayerPrefs.GetInt("Mission1", 0);
        PlayerPrefs.GetInt("Mission2", 0);
        PlayerPrefs.GetInt("Mission3", 0);
        PlayerPrefs.GetInt("Mission4", 0);
        PlayerPrefs.GetInt("Mission5", 0);
        PlayerPrefs.GetInt("Mission6", 0);
        PlayerPrefs.GetInt("Mission7", 0);
        PlayerPrefs.GetInt("Mission8", 0);
        PlayerPrefs.GetInt("Mission9", 0);
        InvokeRepeating("Mission", 2.0f, 2.0f);
    }

     public void Mission()
    {
        if (GameManager.inst.distance >= 5000)
        {
            PlayerPrefs.SetInt("Mission1", 1);
            Debug.Log("Mission 1 complete!");
        }
      
        if (GameManager.inst.coinsInRun >= 100)
        {
            PlayerPrefs.SetInt("Mission2", 1);
            Debug.Log("Mission 2 Complete!");
        }
        if (GameManager.inst.waterInRun >= 10)
        {
            PlayerPrefs.SetInt("Mission3", 1);
            Debug.Log("Mission 3 Complete!");
        }

        if (PlayerPrefs.GetInt("Mission1") == 1 & PlayerPrefs.GetInt("Mission2") == 1 & PlayerPrefs.GetInt("Mission3") == 1)
        {
            if (GameManager.inst.distance >= PlayerPrefs.GetInt("HighScore",0 ))
            {
                PlayerPrefs.SetInt("Mission4", 1);
                Debug.Log("Mission 4 Complete!");
            }

            if (GameManager.inst.coinsInRun <= 0 & GameManager.inst.distance >= 2500)
            {
                PlayerPrefs.SetInt("Mission5", 1);
                Debug.Log("Mission 5 Complete!");
            }

            if (GameManager.inst.player.GetComponent<PlayerMovement>().jumpCounter <= 0  & GameManager.inst.distance >= 2000)
            {
                PlayerPrefs.SetInt("Mission6", 1);
                Debug.Log("Mission 6 gehaaldd!");
            }
        }
        if (PlayerPrefs.GetInt("Mission4") == 1 & PlayerPrefs.GetInt("Mission5") == 1 & PlayerPrefs.GetInt("Mission6") == 1)
        {
            if (GameManager.inst.player.GetComponent<PlayerMovement>().jumpCounter >= 75)
            {
                PlayerPrefs.SetInt("Mission7", 1);
                Debug.Log("Mission 7 gehaald!");
            }

            if (GameManager.inst.powerUpInRun >= 4)
            {
                PlayerPrefs.SetInt("Mission8", 1);
                Debug.Log("Mission 8 gehaald!");
            }

            if (GameManager.inst.distance >= 8000)
            {
                PlayerPrefs.SetInt("Mission9", 1);
                Debug.Log("Mission 9 gehaald!");
            }
        }
    }
}
