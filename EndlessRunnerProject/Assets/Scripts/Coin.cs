using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 50f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        //check that the object we collided with is the player
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        //add to the players score
        GameManager.inst.AddScore();

        // destroy this coin
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
