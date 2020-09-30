using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public double health;
    public bool canHit;
    public bool damageTaken;

    public static bool enemyNear = false;

    void Update()
    {
        // Player attack
        // Player presses E, the hitting collider is true and has a sword
        if (Input.GetKeyDown(KeyCode.E) && canHit && GettingSword.hasSword == true )
        {
            health -= 5;
        }

        if (health <= 0)
        {
            PlayerMove.health += 5;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyNear = true;
            canHit = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyNear = false;
            canHit = false;
        }
    }
}
