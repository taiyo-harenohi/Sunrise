using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp_demo : MonoBehaviour
{
    public GameObject lamp_text;
    private bool around_lamp;
    private bool open_lamp_text;

    void Update()
    {
        if (around_lamp) 
        {
            if (Input.GetKeyDown(KeyCode.Space) && open_lamp_text == false)
            {
                lamp_text.SetActive(true);
                open_lamp_text = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && open_lamp_text)
            {
                lamp_text.SetActive(false);
                open_lamp_text = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            around_lamp = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            around_lamp = false;
            open_lamp_text = false;
            lamp_text.SetActive(false);
        }    
    }
}
