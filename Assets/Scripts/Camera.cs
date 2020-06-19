using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [HideInInspector]
    public Player player;

    private Vector3 lastplayerposition;
    private Vector2 distancetomove;

    private void Start()
    {
        player= FindObjectOfType<Player>();
        lastplayerposition = player.transform.position;
    }

    void LateUpdate()
    {
        distancetomove.x = player.transform.position.x - lastplayerposition.x;
        distancetomove.y = player.transform.position.y - lastplayerposition.y;
        transform.position = new Vector3(transform.position.x + distancetomove.x, transform.position.y+distancetomove.y, transform.position.z);
        lastplayerposition = player.transform.position;
    }
}
