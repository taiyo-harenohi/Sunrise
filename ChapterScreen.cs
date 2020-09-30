using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterScreen : MonoBehaviour
{
    public static bool chapter1 = false;
    public GameObject chapter1Box;
    public static bool chapter2 = false;
    public GameObject chapter2Box;
    public static bool chapter3 = false;
    public GameObject chapter3Box;

    void Update() 
    {
        if (chapter1) 
        {
            chapter1Box.SetActive(true);
        }
        if (chapter2)
        {
            chapter2Box.SetActive(true);
        }
        if (chapter3) 
        {
            chapter3Box.SetActive(true);
        }
    }

    public void Back() 
    {
        SceneManager.LoadScene(SceneReader.currentScene);
    }
}
