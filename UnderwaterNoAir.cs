using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterNoAir : MonoBehaviour
{
    public GameObject noAir1;
    public GameObject noAir2;
    public AudioClip heartbeat;
    private AudioSource source;

    void Start() 
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerUnderwater.health < 25 && PlayerUnderwater.health >= 10) 
        {
            source.PlayOneShot(heartbeat);
            noAir1.SetActive(true);
            noAir2.SetActive(false);
        }
        else if (PlayerUnderwater.health < 10) 
        {
            noAir2.SetActive(true);
            noAir1.SetActive(false);
        }
        else 
        {
            source.Stop();
            noAir2.SetActive(false);
            noAir1.SetActive(false);
        }
    }
}
