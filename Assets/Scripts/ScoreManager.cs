using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text score;
    public Text highscore;
    public Text PowerHealth;

    
    public GameObject Resume;
    public GameObject Game_Over;
    public GameObject Background;

    [SerializeField] Text CurrentScore;
    [SerializeField] Text Highscore;

    public int C_score;
    public int highscorecount;
   
    public int Powercount;
    public int Point,add;

    public Slider Healthslider;
    public Gradient gradient;
    public Image fill;

    public static ScoreManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

    }



    // Start is called before the first frame update
    void Start()
    {      
        Powercount = 0;
        add= 0;
        Point = 0;
        
        if (PlayerPrefs.HasKey("HighScore"))
        {
        highscorecount = PlayerPrefs.GetInt("HighScore");
        }
        
        Resume.SetActive(false);
        Game_Over.SetActive(false);
        Background.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {   
        C_score = Point+add;

        if (C_score>highscorecount)
        {
            highscorecount = C_score;
            PlayerPrefs.SetInt("HighScore", highscorecount);
        }

        score.text = ":" + C_score;
        highscore.text = "HIGH SCORE:" +
            "" + highscorecount;
        PowerHealth.text = ""+Powercount;
        CurrentScore.text = score.text;
        Pause();
    }
    //Set Max Health
    public void SetMax_Health(int health)
    {
        Healthslider.maxValue = health;
        Healthslider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public  void Set_Health(int health)
    {
        Healthslider.value = health;
        fill.color = gradient.Evaluate(Healthslider.normalizedValue);
    }

    public void AddScore(int count)
    {
        Point=count;
    }

    public void PointScore(int count)
    {
        add += count;
    }

    public void Powescore()
    {
        //Always keeping Power to certain Limit
        if (Powercount<4)
        {
            Powercount += 1;
        }
    }

    public void BacktoMenu()
    {
        AudioManager.instance.Play("Button_Click");
        
        SceneManager.LoadScene("Menu");
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            ScoreManager.instance.Background.SetActive(true);
            ScoreManager.instance.Resume.SetActive(true);
        }
    }

    public void resume()
    {
        AudioManager.instance.Play("Button_Click");
        Time.timeScale = 1f;
        ScoreManager.instance.Background.SetActive(false);
        ScoreManager.instance.Resume.SetActive(false);
    }
}
