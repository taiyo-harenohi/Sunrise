using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUnderwater : MonoBehaviour
{
    public float speed;
    private float moveHor;
    private float moveVer;

    private Rigidbody2D rb;

    public static double health = 60;
    public bool damageTaken;

    public Slider healthBar;

    void Start()
    {
        ChapterScreen.chapter1 = true;
        rb = GetComponent<Rigidbody2D>();
        healthBar.value = CalculateHealth();
    }

    void Update()
    {
        healthBar.value = CalculateHealth();
        if (health > 0 && damageTaken == false)
        {
            Damage();
        }

        if (health > 60) // making sure there is only 50 health at top
        {
            health = 60;
        }
        if (health == 0)
        {
            Destroy(this.gameObject);
            ChapterScreen.chapter2 = true;
            SceneManager.LoadScene("gameover");
        }
    }

    // Player moves in 8 directions => different animations for up & down
    void FixedUpdate()
    {
        moveHor = Input.GetAxis("Horizontal"); // getting the x pos
        moveVer = Input.GetAxis("Vertical"); // getting the y pos
        // the magic thing due the player can move ;)
        rb.velocity = new Vector2(moveHor * speed, moveVer * 3);
    }

    // IEnumerator so every second Player gets damage -1 point
    IEnumerator NoAir()
    {
        yield return new WaitForSeconds(1.0f);
        damageTaken = false;
    }

    public void Damage()
    {
        health -= 1;
        damageTaken = true;
        StartCoroutine(NoAir());
    }

    // if Player meets the bubble, it gives Player health and gets destroyed
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            health += 10;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Destroyer"))
        {
            ChapterScreen.chapter2 = true;
            Time.timeScale = 0;
            SceneManager.LoadScene("coast");
        }
        if (other.CompareTag("FasterPlayer")) 
        {
           speed *= 2;
           Debug.Log(speed);
        }
    }

    float CalculateHealth()
    {
        return (float)health / 60.00f;
    }
}
