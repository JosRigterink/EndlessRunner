using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int currentCharacterIndex = 0;
    public GameObject[] characterModels;

    public CharacterStats[] characters;
    public Button BuyButton;
    public Text coinText;
    public int coins;
    public Text characterName;

    // Start is called before the first frame update
    public void Start()
    {
        foreach(CharacterStats cha in characters)
        {
            if (cha.price == 0)
            {
                cha.isUnlocked = true;
            }
            else
            {
                cha.isUnlocked = PlayerPrefs.GetInt(cha.name, 0)==0 ? false : true;
            }
        }

        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject car in characterModels)
            car.SetActive(false);

        characterModels[currentCharacterIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void NextCharacter()
    {
        characterModels[currentCharacterIndex].SetActive(false);

        currentCharacterIndex++;
        if (currentCharacterIndex == characterModels.Length)
        {
            currentCharacterIndex = 0;
        }
        characterModels[currentCharacterIndex].SetActive(true);
        CharacterStats c = characters[currentCharacterIndex];
        if (!c.isUnlocked)
        {
            return;
        }

        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
    }

    public void PreviousCharacter()
    {
        characterModels[currentCharacterIndex].SetActive(false);

        currentCharacterIndex--;
        if (currentCharacterIndex == -1)
        {
            currentCharacterIndex = characterModels.Length -1;
        }
        characterModels[currentCharacterIndex].SetActive(true);

        CharacterStats c = characters[currentCharacterIndex];
        if (!c.isUnlocked)
        {
            return;
        }
        //characterModels[currentCharacterIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
    }

    public void UnlockCharacter()
    {
        CharacterStats c = characters[currentCharacterIndex];
        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
        c.isUnlocked = true;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - c.price);
    }

    private void UpdateUI()
    {
        CharacterStats c = characters[currentCharacterIndex];
        characterName.GetComponent<Text>().text = c.name;
        if (c.isUnlocked)
        {
            BuyButton.gameObject.SetActive(false);
        }
        else
        {
            BuyButton.gameObject.SetActive(true);
            BuyButton.GetComponentInChildren<Text>().text = "Buy-" + c.price;
            if(c.price < PlayerPrefs.GetInt("Coins"))
            {
                BuyButton.interactable = true;
            }
            else
            {
                BuyButton.interactable = false;
            }
        }

         coins = PlayerPrefs.GetInt("Coins", coins);
         coinText.text = "Coins: " + coins;
    }
}
