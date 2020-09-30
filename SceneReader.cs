using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReader : MonoBehaviour
{
    public static string currentScene;

    void Start() 
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
}
