using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionChecker : MonoBehaviour
{
    public Canvas missionScreen;
    public Canvas missionScreen2;
    public Canvas missionScreen3;
    public bool firstMissionsDone;
    public bool missions456Done;
   
    public void Start()
    {
        MissionCompleted();
    }

    public void MissionCompleted()
    {
        if (PlayerPrefs.GetInt ("Mission1") == 1)
        {
            Debug.Log("Mission 1 gehaald jwz");
            missionScreen.transform.GetChild(5).GetComponent<TMP_Text>().color = Color.green;
            missionScreen.transform.GetChild(1).GetComponent<RawImage>().color = Color.gray;
        }

        if (PlayerPrefs.GetInt ("Mission2") == 1)
        {
            Debug.Log("Mission 2 gehaalddd!");
            missionScreen.transform.GetChild(6).GetComponent<TMP_Text>().color = Color.green;
            missionScreen.transform.GetChild(2).GetComponent<RawImage>().color = Color.gray;
        }

        if (PlayerPrefs.GetInt("Mission3") == 1)
        {
            Debug.Log("Mission 3 Gehaaaldldd");
            missionScreen.transform.GetChild(7).GetComponent<TMP_Text>().color = Color.green;
            missionScreen.transform.GetChild(3).GetComponent<RawImage>().color = Color.gray;
        }

        if (PlayerPrefs.GetInt("Mission1") == 1 & PlayerPrefs.GetInt("Mission2") == 1 & PlayerPrefs.GetInt("Mission3") == 1)
        {
            //next page of missions will unlock
            firstMissionsDone = true;
            Debug.Log("first 3 Missions achieved");
            missionScreen.transform.GetChild(9).GetComponent<Button>().interactable = true;

            if (PlayerPrefs.GetInt("Mission4") == 1 & firstMissionsDone == true)
            {
                Debug.Log("Mission 4 gehaaldd");
                missionScreen2.transform.GetChild(5).GetComponent<TMP_Text>().color = Color.green;
                missionScreen2.transform.GetChild(1).GetComponent<RawImage>().color = Color.gray;
            }

            if (PlayerPrefs.GetInt("Mission5") == 1)
            {
                Debug.Log("Mission 5 gehaald!");
                missionScreen2.transform.GetChild(6).GetComponent<TMP_Text>().color = Color.green;
                missionScreen2.transform.GetChild(2).GetComponent<RawImage>().color = Color.gray;
            }

            if (PlayerPrefs.GetInt("Mission6") == 1)
            {
                Debug.Log("Mission 6 gehaald!");
                missionScreen2.transform.GetChild(7).GetComponent<TMP_Text>().color = Color.green;
                missionScreen2.transform.GetChild(3).GetComponent<RawImage>().color = Color.gray;
            }
        } 
        if (PlayerPrefs.GetInt("Mission4") == 1 & PlayerPrefs.GetInt("Mission5") == 1 & PlayerPrefs.GetInt("Mission6") == 1)
        {
            Debug.Log("Missions 4,5,6 achieved!");
            missions456Done = true;

            missionScreen2.transform.GetChild(9).GetComponent<Button>().interactable = true;

            if (PlayerPrefs.GetInt("Mission7") == 1)
            {
                Debug.Log("Mission7 achieved");
                missionScreen3.transform.GetChild(5).GetComponent<TMP_Text>().color = Color.green;
                missionScreen3.transform.GetChild(1).GetComponent<RawImage>().color = Color.gray;
            }

            if (PlayerPrefs.GetInt("Mission8") == 1)
            {
                Debug.Log("Mission8 achieved!");
                missionScreen3.transform.GetChild(6).GetComponent<TMP_Text>().color = Color.green;
                missionScreen3.transform.GetChild(2).GetComponent<RawImage>().color = Color.gray;
            }

            if (PlayerPrefs.GetInt("Mission9") == 1 & missions456Done)
            {
                Debug.Log("Mission9 achieved!");
                missionScreen3.transform.GetChild(7).GetComponent<TMP_Text>().color = Color.green;
                missionScreen3.transform.GetChild(3).GetComponent<RawImage>().color = Color.gray;
            }
        }
    }
}
