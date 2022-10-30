using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleWater : MonoBehaviour
{
    public float turnSpeed = 50f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.GetComponent<Coin>() != null)
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
        GameManager.inst.AddBubbleWater();

        // destroy this item
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
