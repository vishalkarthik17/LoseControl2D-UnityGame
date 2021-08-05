using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGamePaused;
    public GameObject[] obstaclePatternArray;
    public GameObject[] coins;
    float stopwatch;
    float stopwatchMid;
    public float spawnPeriod;
    public float timeDecrement;
    public float minSpawnTime;
    bool coinSpwaned = false;

    void Start()
    {
        //minSpawnTime = 1.0f;
        stopwatch = 0f;
        stopwatchMid = -1f;
        isGamePaused = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGamePaused)
        {
            if (stopwatch <= stopwatchMid && coinSpwaned == false)
            {
                //Instantiate a coin 
                int rand = Random.Range(0, coins.Length);
                Instantiate(coins[rand], transform.position, Quaternion.identity);
                coinSpwaned = true;
            }

            if (stopwatch <= 0)
            {
                int rand = Random.Range(0, obstaclePatternArray.Length);
                Instantiate(obstaclePatternArray[rand], transform.position, Quaternion.identity);
                stopwatch = spawnPeriod; //stopwatch reset
                if (spawnPeriod > minSpawnTime)
                    spawnPeriod -= timeDecrement;
                stopwatchMid = spawnPeriod / 2;
                coinSpwaned = false;
            }

            else
            {
                stopwatch = stopwatch - Time.deltaTime;
            }
        }
        
        
    }
}
