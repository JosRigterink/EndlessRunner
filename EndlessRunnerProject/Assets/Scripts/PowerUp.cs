using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public float powerUpDuration;
    public float rotateSpeed;
    public bool doublePoints;
    public bool doubleCoins;
    public bool doubleWater;
    public bool slowSpeed;
   
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

        // effects 
        if (doublePoints == true)
        {
            if (GameManager.inst.scoreMultiplier == 2)
            {
                Destroy(gameObject);
                return;
            }
            GameManager.inst.powerUpInRun++;
            GameManager.inst.scoreMultiplier *= 2;
            GameManager.inst.doubleScoreText.color = Color.yellow;
            GameManager.inst.doubleScoreText.text = ("2x");
        }

        if (doubleCoins == true)
        {
            GameManager.inst.powerUpText.color = Color.yellow;
            GameManager.inst.powerUpText.text = ("Double Coins!");
            GameManager.inst.timerOn = true;
            GameManager.inst.coinMultiplier *= 2;
            GameManager.inst.Invoke("EndOfDoubleCoins", powerUpDuration);
            GameManager.inst.currentTime = powerUpDuration;
            GameManager.inst.powerUpInRun++;
        }
        
        if (doubleWater == true)
        {
            GameManager.inst.powerUpText.color = Color.cyan;
            GameManager.inst.powerUpText.text = ("Double Water!");
            GameManager.inst.timerOn = true;
            GameManager.inst.bubbleWaterMultiplier *= 2;
            GameManager.inst.Invoke("EndOfDoubleWater", powerUpDuration);
            GameManager.inst.currentTime = powerUpDuration;
            GameManager.inst.powerUpInRun++;
        }

        if(slowSpeed == true)
        {
            GameManager.inst.player.GetComponent<PlayerMovement>().speed -= 4;
            GameManager.inst.powerUpInRun++;
        }

        Destroy(gameObject);
    }


     void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
