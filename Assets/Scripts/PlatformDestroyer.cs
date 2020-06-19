using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private GameObject destructionpoint;

    void Start()
    {
        destructionpoint = GameObject.Find("PlatformDestructionpoint");
    }
   
    void Update()
    {
        if(transform.position.x<destructionpoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
