using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverBox;

    void Update() 
    {
        if (PlayerUnderwater.health == 0 || PlayerMove.health == 0) 
        {
            Time.timeScale = 0;
            gameOverBox.SetActive(true);
        }
    }

    public void Restart() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu");
    }
}
