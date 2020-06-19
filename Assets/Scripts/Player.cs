using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public Transform groundcheck;
    public Transform groundcheck1;
    
    public bool increasescore;
    public int scorecount;

    public float movespeed;
    public float jumpforce;

    public float start, current;

    private float nocollisiontime;
    public float jumptime;
    private float jumptimecounter;


    public bool Ground;
    
    public float radius;

    public int maxHealth = 100;
    public int currentHealth;

    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jumptimecounter = jumptime;

        currentHealth = maxHealth;
        ScoreManager.instance.SetMax_Health(maxHealth);

        start = transform.position.x;
        increasescore = true ;
    }

    // Update is called once per frame
    void Update()
    {
        Ground = onGround();
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movespeed, rb.velocity.y);
        jump();
        score();

        if (!Ground)
        {
            nocollisiontime += Time.deltaTime;
        }
        

        if (Input.GetKey(KeyCode.E))
        {
            //gaining maxhealth
            if (0 < ScoreManager.instance.Powercount)
            {
                AudioManager.instance.Play("PowerUse");
                ScoreManager.instance.Powercount -= 1;
                currentHealth = maxHealth;
                
                ScoreManager.instance.SetMax_Health(maxHealth);
            }

        }

        if (nocollisiontime > 5 )
        {
            bool hit = Physics2D.Raycast(groundcheck1.position, Vector2.down, 10f,ground);

            if (hit)
            {
                nocollisiontime = 0;
            }
            else
            {
                gameover();
            }
        }

        if (currentHealth <= 0)
        {
            gameover();
        }

    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDamage(1);
            AudioManager.instance.Play("EnemyHit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string s = collision.gameObject.tag;
        switch (s)
        {
            case "Coin":
                AudioManager.instance.Play("Coin");
                ScoreManager.instance.PointScore(10);
                
                break;
            case "Power":
                AudioManager.instance.Play("PowerHit");
                ScoreManager.instance.PointScore(5);
                ScoreManager.instance.Powescore();

                break;
            default:
                break;


        }
        collision.gameObject.SetActive(false);
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Ground)
            {
                AudioManager.instance.Play("Jump");
                rb.velocity = new Vector2((rb.velocity.x), jumpforce);
            }   
        }

        //To Jump more Higher 
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumptimecounter > 0)
            {
                AudioManager.instance.Play("Jump");

                rb.velocity = new Vector2((rb.velocity.x), jumpforce);
                jumptimecounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumptimecounter = 0;
        }

        if (Ground)
        {
            nocollisiontime = 0f;
            //resetting time to start
            jumptimecounter = jumptime;
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        ScoreManager.instance.Set_Health(currentHealth);
    }

    void score()
    {
        if (increasescore)
        {
            current = transform.position.x;
        }

        if (current > start)
        {
            scorecount = (int)((current - start)/10);
            ScoreManager.instance.AddScore(scorecount);
        }
    }

    bool onGround()
    {
        //checking  Ground touch
        bool left=Physics2D.OverlapCircle(groundcheck1.position,radius,ground);
        bool right = Physics2D.OverlapCircle(groundcheck.position, radius, ground);
       
        if (left||right)
        { return true; }

        return false;
    }
    
    void gameover()
    {
        AudioManager.instance.Play("GameOver");
        GameManager.manager.Gameover();
    }
}