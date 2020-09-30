using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingSword : MonoBehaviour
{
    public static bool hasSword = false;

    public GameObject katana;

    void Update() 
    {
        if (hasSword && Input.GetKeyDown(KeyCode.Space)) 
        {
            Destroy(this.gameObject);
            hasSword = true;
            katana.SetActive(true);
        }
    } 

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            hasSword = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            hasSword = false;
        }
    }
}
