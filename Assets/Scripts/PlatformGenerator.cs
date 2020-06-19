using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    public Transform generationpoint;

    public float xmin, xmax;
    public float ymin, ymax;

    public Objectpool pool;

    private float xgap, ygap;

    //gap depending on the prefab size(here platformwidth is 1 and platform takes size 10
    public float gap = 9.1f;
    private float platformwidth;

    private float coinx;
    private int coiny;

    private int n;

    private float powertime;

    void Start()
    {
        powertime = 0;
        platformwidth = platform.GetComponent<BoxCollider2D>().size.x;

    }

    void Update()
    {
        powertime += Time.deltaTime;

        if (transform.position.x < generationpoint.position.x)
        {
            xgap = Random.Range(xmin, xmax);
            ygap = Random.Range(ymin, ymax);

            //Coins to be placed
            n = Random.Range(0, 5);

            //Placing Objects(platforms,enemies,coins...etc,)
            PlacingPlatforms();
            PlacingCoins();
            PlacingEnemies();
            PlacingPowers();

            //so that it dont overlap
            transform.position = new Vector3(transform.position.x + (platformwidth / 2), transform.position.y, transform.position.z);
        }
    
    }
    void PlacingPlatforms()
    {
        transform.position = new Vector3(transform.position.x + (platformwidth / 2) + gap + xgap, transform.position.y + ygap, transform.position.z);
        GameObject newplatform = pool.Getpooledobjects();
        newplatform.transform.position = transform.position;
        newplatform.transform.rotation = transform.rotation;
        newplatform.SetActive(true);
               
    }

    void PlacingEnemies()
    {
        GameObject newcoin = pool.SpawnEnemies();
        newcoin.transform.position = new Vector3(transform.position.x + 1.8f, transform.position.y + 1.0f, transform.position.z);
        newcoin.transform.rotation = transform.rotation;
        newcoin.SetActive(true);
    }

    void PlacingPowers()
    {
        int x = Random.Range(50, 200);
        if (powertime > x)
        {
            GameObject newpower = pool.SpawnPowers();
            newpower.transform.position = new Vector3(transform.position.x + ygap, transform.position.y + 7.0f, transform.position.z);
            newpower.transform.rotation = transform.rotation;
            newpower.SetActive(true);
            powertime = 0;
        }
    }

    void PlacingCoins()
    {
        for (int i = 0; i < n; i++)
        {
            //COIN SPAWNING POSITIONS
            coinx = Random.Range(-5, 5);
            if (coinx <= -1.3)
            {
                coiny = Random.Range(2, 5);
            }
            else if (coinx > -1.3f && coinx <= -1.1f)
            {
                coiny = Random.Range(1, 5);
            }
            else if (coinx > -1.1f && coinx <= 1.5f)
            {
                coiny = Random.Range(3, 5);
            }
            else if (coinx > 1.5f && coinx <= 3.4f)
            {
                coiny = Random.Range(4, 5);
            }
            else
            {
                coiny = Random.Range(4, 5);
            }

            GameObject newcoin = pool.Spawncoins();
            newcoin.transform.position = new Vector3(transform.position.x + coinx, transform.position.y + coiny, transform.position.z);
            newcoin.transform.rotation = transform.rotation;
            newcoin.SetActive(true);
        }
    }
    
}
