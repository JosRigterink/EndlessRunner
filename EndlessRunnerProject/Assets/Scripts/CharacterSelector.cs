using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public int currentCharacterIndex = 0;
    public GameObject[] characters;

    void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject car in characters)
            car.SetActive(false);

        characters[currentCharacterIndex].SetActive(true);
    }
}
