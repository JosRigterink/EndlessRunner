using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    public int currentCharacterIndex = 0;

    // Start is called before the first frame update
    public void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        offset = transform.position - player.position;

        player = GameObject.FindGameObjectWithTag("CharacterHolder").GetComponent<CharacterSelector>().characters[currentCharacterIndex].gameObject.transform;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
