using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("underwater1");
    }

    public void Settings() 
    {
        SceneManager.LoadScene("settings");
    }

    
}
