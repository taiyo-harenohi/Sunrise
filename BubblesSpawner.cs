using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesSpawner : MonoBehaviour
{
    public GameObject[] bubblesPatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.75f;
    public int previous;

    void Update() 
    {
        if (timeBtwSpawn <= 0)
        {
            int rnd = Random.Range(0, bubblesPatterns.Length);
            if (rnd == previous)
            {
                if (rnd == 0)
                {
                    rnd += 1;
                }
                else
                {
                    rnd -= 1;
                }
            }
            Instantiate(bubblesPatterns[rnd], transform.position, Quaternion.identity);
            previous = rnd;
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
