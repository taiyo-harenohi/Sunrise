using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;

    public static double health = 50;
    public Slider healthBar;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private bool facingRight;

    private bool damageTaken;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
        healthBar.value = CalculateHealth();
    }

    void Update()
    {
        // for healthbar
        // if zero, Player gets destroyed
        healthBar.value = CalculateHealth();
        
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        
        // if Player is on the ground, he can jump again
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        // making sure he can jump and how many times he can jump
        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        // if Player meets Enemy with the basic script,
        // it deals him damage every second and a half -5
        if (Enemy.enemyNear && damageTaken == false && health > 0) 
        {
            Damage();
        }
    }

    public void Damage() 
    {
        health -= 5;
        damageTaken = true;
        StartCoroutine(EnemyHit());
    }

    IEnumerator EnemyHit() 
    {
        yield return new WaitForSeconds(1.5f);
        damageTaken = false;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }

    float CalculateHealth()
    {
        return (float)health / 50.00f;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
