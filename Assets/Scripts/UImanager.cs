using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public Text highscore;
    public enum UIState { Menu,Help}

    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Help_menu;
   
    void Start()
    {
        SetUIState(UIState.Menu);   
    }

    public   void SetUIState(UIState uIState)
    {
        switch (uIState)
        {
            case UIState.Menu:
                Menu.SetActive(true);
                Help_menu.SetActive(false);
               
                 highscore.text =""+PlayerPrefs.GetInt("HighScore");
                
                break;

            case UIState.Help:
                Menu.SetActive(false);
                Help_menu.SetActive(true);
                break;
        }
       
    }

    public void play()
    {
        SceneManager.LoadScene("Level");
        Menu.SetActive(false);
    }

    public void help()
    {
        
        SetUIState(UIState.Help);
    }

    public void helptoMenu()
    {
        
        SetUIState(UIState.Menu);
    }
   
    public void Quit()
    {
        Application.Quit();
    }
}
