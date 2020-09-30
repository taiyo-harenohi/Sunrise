using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSaveScreen : MonoBehaviour
{
    public GameObject pauseBox;
    private bool openPause;

    void Update()
    {
        // chosing chapters – later probably save/load screen
        // in demo – chosing chapters, in full game – save/load function
        if (Input.GetKey(KeyCode.P)) 
        {
            SceneManager.LoadScene("chapters");
        }   

        // pause menu
        if (Input.GetKeyDown(KeyCode.Escape) && openPause == false) 
        {
            // for pausing every action in game
            Time.timeScale = 0;
            // the pause menu is closed
            pauseBox.SetActive(true);
            openPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && openPause) 
        {
            // restart every action in game
            Time.timeScale = 1;
            // the pause menu is open
            pauseBox.SetActive(false);
            openPause = false;
        } 
    }

    // implement Yes/No thing for every button
    public void Settings() 
    {
        SceneManager.LoadScene("settings");
    }

    public void MainMenu() 
    {
        SceneManager.LoadScene("mainmenu");
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
