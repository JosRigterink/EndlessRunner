using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    
    GroundSpawner groundSpawner;
    public GameObject tallObstaclePrefab;
    public GameObject bubbleWaterPrefab;
    public GameObject[] tallObstacles;
    public float tallObstacleChance = 0.7f;
    public float bubbleWaterChance = 0.02f;
    public float powerUpChance;
    public Transform leftSideLocation;
    public Transform rightSideLocation;
    public GameObject[] leftSideContent;
    public GameObject[] rightSideContent;
    public GameObject[] powerUps;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);

        if (other.gameObject.tag == "Player")
        {
            GameManager.inst.MoveSpeedIncrease();
            Debug.Log("speedincrease!");
        }

    }
    public GameObject obstaclePrefab;

    public void SpawnObstacle()
    {
        //choose which obstacle to spawn
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        float random1 = Random.Range(0f, 100f);
        if (random > tallObstacleChance)
        {
            obstacleToSpawn = tallObstacles[Random.Range(0, tallObstacles.Length)];
        }

        if (random < bubbleWaterChance)
        {
            obstacleToSpawn = bubbleWaterPrefab;
        }

        if (random1 < powerUpChance)
        {
            int coinSpawnIndex = Random.Range(4, 8);
            Transform spawnnPoint = transform.GetChild(coinSpawnIndex).transform;
            GameObject Powerup = powerUps[Random.Range(0, powerUps.Length)];
            Instantiate(Powerup, spawnnPoint.position, Quaternion.identity, transform);
        }

        GameObject leftspawn = leftSideContent[Random.Range(0, leftSideContent.Length)];
        GameObject rightspawn = rightSideContent[Random.Range(0, rightSideContent.Length)];

        Instantiate(leftspawn, leftSideLocation.position, Quaternion.identity, transform);
        Instantiate(rightspawn, rightSideLocation.position, Quaternion.identity, transform);

        //Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //spawn the obstacle at the position
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }
    public GameObject coinPrefab;

    void SpawnCoins()
    {
        int coinSpawnIndex = Random.Range(4, 8);
        Transform spawnPoint = transform.GetChild(coinSpawnIndex).transform;
        Instantiate(coinPrefab, spawnPoint.transform);
    }
}
