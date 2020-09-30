using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI text;
    public List<string> dialogList;
    public int index;

    private float typingSpeed = 0.02f;

    public string sceneName;

    private float startTime = 0f;
    private float timer = 0f;
    private float holdTime = 1.0f;

    void Start()
    {
        // every object in scene can move again
        Time.timeScale = 1;
        // starting coroutine for typing 
        StartCoroutine(Type());
    }

    void Update()
    {
        if (text.text == dialogList[index]) 
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                if (index == dialogList.Count - 1) 
                {
                    StopCoroutine(Type());
                    StartCoroutine(LoadScene());
                    SceneManager.LoadScene(sceneName);
                }
                else 
                {
                    
                }
            }
        }
    }
}
