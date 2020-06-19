using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectpool : MonoBehaviour
{
    public GameObject[] pooledobject;
    public GameObject coin;
    public GameObject power;
    public GameObject enemy;
    
    public int maxpool;
    [HideInInspector]
    public int i;

    List<GameObject> Objectspooled;
    List<GameObject> Coinspooled;
    List<GameObject> Powers;
    List<GameObject> Enemies;
    
    void Start()
    {
        Objectspooled = new List<GameObject>();
        Coinspooled   = new List<GameObject>();
        Powers        = new List<GameObject>();
        Enemies       = new List<GameObject>();
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < maxpool; i++)
        {
            //PLATFORMS
            GameObject obj = (GameObject)Instantiate(pooledobject[i]);
            obj.SetActive(false);
            Objectspooled.Add(obj);

            //COINS
            GameObject obj1 = (GameObject)Instantiate(coin);
            obj1.SetActive(false);
            Coinspooled.Add(obj1);

            //ENEMIES
            GameObject o = (GameObject)Instantiate(enemy);
            o.SetActive(false);
            Enemies.Add(o);

            //HEALTH POWER
            GameObject ob = (GameObject)Instantiate(power);
            ob.SetActive(false);
            Powers.Add(ob);
                        
        }
    }
    public GameObject Getpooledobjects()
    {
        //checking the availibility of objects that are not active
        for(int i=0;i<Objectspooled.Count;i++)
        {
            if(!Objectspooled[i].activeInHierarchy)
            {
                return Objectspooled[i];

            }
        }
        //if all are active ,create new one
        i = Random.Range(0, pooledobject.Length);
        GameObject obj = (GameObject)Instantiate(pooledobject[i]);
        obj.SetActive(false);
        Objectspooled.Add(obj);
        return obj;
    }

    public GameObject Spawncoins()
    {
        //checking the availibility of objects that are not active
        for (int i = 0; i < Coinspooled.Count; i++)
        {
            if (!Coinspooled[i].activeInHierarchy)
            {
                return Coinspooled[i];

            }
        }
        //if all are active ,create new one
        GameObject obj = (GameObject)Instantiate(coin);
        obj.SetActive(false);
        Coinspooled.Add(obj);
        return obj;
    }

    public GameObject SpawnEnemies()
    {
        for (int i = 0; i<Enemies.Count; i++)
        {
            if (!Enemies[i].activeInHierarchy)
            {
                return Enemies[i];

            }
        }
        GameObject obj = (GameObject)Instantiate(enemy);
        obj.SetActive(false);
        Enemies.Add(obj);
        return obj;
    }


    public GameObject SpawnPowers()
    {
        for (int i = 0; i < Powers.Count; i++)
        {
            if (!Powers[i].activeInHierarchy)
            {
                return Powers[i];
            }

        }
        return null;
    }
}
