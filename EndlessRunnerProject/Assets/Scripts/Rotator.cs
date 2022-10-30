using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed;
    // Update is called once per frame
    public void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
