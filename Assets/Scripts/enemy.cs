using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private BoxCollider2D ecollider;
    private SpriteRenderer sr;

    [SerializeField]
    private int speed;
    bool moveright = true;
    
    public float distance;

    public Transform detection;
    Vector3 p;

    // Start is called before the first frame update
    void Start()
    {
        ecollider      = GetComponent<BoxCollider2D>();
        sr             = GetComponent<SpriteRenderer>();
        sr.flipX       = true;
        p = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( p* speed * Time.deltaTime);
        
        RaycastHit2D groundray = Physics2D.Raycast(detection.position, Vector2.down, distance);
        
        if (groundray.collider == false)
        { 
                transform.Rotate(0, 180, 0);
                moveright =!moveright;
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {            
            speed = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speed = 3;
        }
    }
}
