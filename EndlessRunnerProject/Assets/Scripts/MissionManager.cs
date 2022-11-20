using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionManager : MonoBehaviour
{
    [SerializeField] TMP_Text missionsText;
    [SerializeField] bool missionComplete;
    [SerializeField] bool missionComplete2;
    [SerializeField] bool missionComplete3;
    [SerializeField] bool missionComplete4;
    [SerializeField] bool missionComplete5;
    [SerializeField] bool missionComplete6;
    [SerializeField] bool missionComplete7;
    [SerializeField] bool missionComplete8;
    [SerializeField] bool missionComplete9;
    public float time;
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
        PlayerPrefs.GetInt("MissionRewards", 0);
    }

     public void Mission()
    {
        if (GameManager.inst.distance >= 5000)
        {
            if (missionComplete == false)
            {
                if (PlayerPrefs.GetInt("Mission1") == 1 || missionComplete == true)
                {
                    return;
                }
                PlayerPrefs.SetInt("Mission1", 1);
                Debug.Log("Mission 1 complete!");
                missionsText.text = ("Mission 1 complete!");
                time = 4;
                missionComplete = true;
            }
        }
      
        if (GameManager.inst.coinsInRun >= 100)
        {
            if (missionComplete2 == false)
            {
                if (PlayerPrefs.GetInt("Mission2") == 1 || missionComplete2 == true)
                {
                    return;
                }
                PlayerPrefs.SetInt("Mission2", 1);
                Debug.Log("Mission 2 Complete!");
                missionsText.text = ("Mission 2 complete!");
                time = 4;
                missionComplete2 = true;
            }
        }
        if (GameManager.inst.waterInRun >= 10)
        {
            if (missionComplete3 == false)
            {
                if (PlayerPrefs.GetInt("Mission3") == 1 || missionComplete3 == true)
                {
                    return;
                }
                PlayerPrefs.SetInt("Mission3", 1);
                Debug.Log("Mission 3 Complete!");
                missionsText.text = ("Mission 3 complete!");
                time = 4;
                missionComplete3 = true;
            }
        }

        if (PlayerPrefs.GetInt("Mission1") == 1 & PlayerPrefs.GetInt("Mission2") == 1 & PlayerPrefs.GetInt("Mission3") == 1)
        {
            if (GameManager.inst.distance >= PlayerPrefs.GetInt("HighScore",0 ))
            {
                if (missionComplete4 == false)
                {
                    if (PlayerPrefs.GetInt("Mission4") == 1 || missionComplete4 == true)
                    {
                        return;
                    }
                    PlayerPrefs.SetInt("Mission4", 1);
                    Debug.Log("Mission 4 Complete!");
                    missionsText.text = ("Mission 4 complete!");
                    time = 4;
                    missionComplete4 = true;
                }
            }

            if (GameManager.inst.coinsInRun <= 0 & GameManager.inst.distance >= 2500)
            {
                if (missionComplete5 == false)
                {
                    if (PlayerPrefs.GetInt("Mission5") == 1 || missionComplete5 == true)
                    {
                        return;
                    }
                    PlayerPrefs.SetInt("Mission5", 1);
                    Debug.Log("Mission 5 Complete!");
                    missionsText.text = ("Mission 5 complete!");
                    time = 4;
                    missionComplete5 = true;
                }
            }

            if (GameManager.inst.player.GetComponent<PlayerMovement>().jumpCounter <= 0  & GameManager.inst.distance >= 2000)
            {
                if (missionComplete6 == false)
                {
                    if (PlayerPrefs.GetInt("Mission6") == 1 || missionComplete6 == true)
                    {
                        return;
                    }
                    PlayerPrefs.SetInt("Mission6", 1);
                    Debug.Log("Mission 6 gehaaldd!");
                    missionsText.text = ("Mission 6 complete!");
                    time = 4;
                    missionComplete6 = true;
                }
            }
        }
        if (PlayerPrefs.GetInt("Mission4") == 1 & PlayerPrefs.GetInt("Mission5") == 1 & PlayerPrefs.GetInt("Mission6") == 1)
        {
            if (GameManager.inst.player.GetComponent<PlayerMovement>().jumpCounter >= 75)
            {
                if (missionComplete7 == false)
                {
                    if (PlayerPrefs.GetInt("Mission7") == 1 || missionComplete7 == true)
                    {
                        return;
                    }
                    PlayerPrefs.SetInt("Mission7", 1);
                    Debug.Log("Mission 7 gehaald!");
                    missionsText.text = ("Mission 7 complete!");
                    time = 4;
                    missionComplete7 = true;
                }
            }

            if (GameManager.inst.powerUpInRun >= 4)
            {
                if (missionComplete8 == false)
                {
                    if (PlayerPrefs.GetInt("Mission8") == 1 || missionComplete8 == true)
                    {
                        return;
                    }
                    PlayerPrefs.SetInt("Mission8", 1);
                    Debug.Log("Mission 8 gehaald!");
                    missionsText.text = ("Mission 8 complete!");
                    time = 4;
                    missionComplete8 = true;
                }
            }

            if (GameManager.inst.distance >= 8000)
            {
                if (missionComplete9 == false)
                {
                    if (PlayerPrefs.GetInt("Mission9") == 1 || missionComplete9 == true)
                    {
                        return;
                    }
                    PlayerPrefs.SetInt("Mission9", 1);
                    Debug.Log("Mission 9 gehaald!");
                    missionsText.text = ("Mission 9 complete!");
                    time = 4;
                    missionComplete9 = true;
                }
            }

        }
    }
     void Update()
     {
        //if (missionComplete == true)
        {
            time -= 1 * Time.deltaTime;
            if (time < 5)
            {
                missionsText.enabled = true;
            }
            if (time <= 0)
            {
                missionsText.enabled = false;
                time = 0;
            }
        }
     }
}
