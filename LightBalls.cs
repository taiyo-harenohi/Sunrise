using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBalls : MonoBehaviour
{
    private bool lightballPicked;

    public List<string> sentences;
    private int index;
    public string displayedSentence;
    

    void Update()
    {
        if (PlayerMove.health < 50 && lightballPicked) 
        {
            PlayerMove.health += 5;
            Destroy(this.gameObject);
        }

        if (PlayerMove.health > 50) 
        {
            PlayerMove.health = 50;
        }      
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            lightballPicked = true;
        }   
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            lightballPicked = false;
        }   
    }
}
