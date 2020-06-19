using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public Transform platformgenerator;
    private Vector3 platformstartpoint;

    public Player theplayer;
    private Vector3 playerstartpoint;

    //List to store platforms and its components like stars etc which are active
    private PlatformDestroyer[] platformlist;
    
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    void Start()
    {       
        platformstartpoint = platformgenerator.position;
        playerstartpoint = theplayer.transform.position;   
    }

    
    public void Gameover()
    {
        theplayer.gameObject.SetActive(false);
        
        platformlist = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformlist.Length; i++)
        {
            platformlist[i].gameObject.SetActive(false);
        }

        ScoreManager.instance.Background.SetActive(true);
        ScoreManager.instance.Game_Over.SetActive(true);

    }
    public void reset()
    {    
        AudioManager.instance.Play("Button_Click");
        theplayer.transform.position = playerstartpoint;
        platformgenerator.position = platformstartpoint;
        theplayer.gameObject.SetActive(true);

        theplayer.currentHealth = theplayer.maxHealth;
        ScoreManager.instance.SetMax_Health(theplayer.maxHealth);

        ScoreManager.instance.Point = 0;
        ScoreManager.instance.add = 0;
        ScoreManager.instance.Powercount = 0;
        theplayer.scorecount = 0;
        theplayer.increasescore = true;

        ScoreManager.instance.Background.SetActive(false);
        ScoreManager.instance.Game_Over.SetActive(false);
    }

}
