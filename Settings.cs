﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public void Back() 
    {
        
        SceneManager.LoadScene(SceneReader.currentScene);
        Time.timeScale = 1;
    }
}
