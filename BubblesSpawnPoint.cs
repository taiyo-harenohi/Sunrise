using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesSpawnPoint : MonoBehaviour
{
    public GameObject bubble;

    void Start()
    {
        Instantiate(bubble, transform.position, Quaternion.identity);
    }
}
