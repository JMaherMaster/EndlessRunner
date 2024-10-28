using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpForce = 5;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;
    bool jump;
    [SerializeField] Animator anim;
    float lastYPos;
    public float distancedTraveled;
    public int collectedCoins;

    [SerializeField] UIController uiController;

    [SerializeField] bool airJump;

    [SerializeField] bool shieldIsActive;
    [SerializeField] GameObject shield;

    [SerializeField] SFXManager sfxManager;

    bool playerIsFalling;


    void Start()
    {
        lastYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        distancedTraveled += Time.deltaTime;
        
        CheckForInput();

        CheckIfPlayerIsFalling();
       
    }

    void FixedUpdate()
    {
        CheckForGrounded();
        CheckForJump();
    }

    void CheckForJump()
    {
        if (jump == true)
        {
            jump = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    void CheckForInput()
    {
        if (isGrounded == true || airJump == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(airJump == true && isGrounded == false)
                {
                    airJump = false;
                    sfxManager.PlaySFX("DoubleJump");

                }
                else{
                    sfxManager.PlaySFX("Jump");

                }
                jump = true;
                anim.SetTrigger("Jump");
            }
        }
    }

    void CheckForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        if(hit.collider != null)
        {
            if(hit.distance < 0.1f)
            {
                isGrounded = true;
                anim.SetBool("IsGrounded", true);
                if (playerIsFalling == true)
                {
                    sfxManager.PlaySFX("Land");
                }
                

            }

            else
            {
                isGrounded = false;
                anim.SetBool("IsGrounded", false);
            }
            
            Debug.Log(hit.transform.name);
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);
        }   
    }

    void CheckIfPlayerIsFalling()
    {
        if(transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
            playerIsFalling = true;
        }
        else
        {
            anim.SetBool("Falling", false);
            playerIsFalling = false;
        }

        lastYPos = transform.position.y;
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.transform.CompareTag("Obstacle"))
        {
            Debug.Log("hit");
            if (shieldIsActive == true)
            {
                shield.SetActive(false);
                shieldIsActive = false;
                sfxManager.PlaySFX("ShieldBreak");
                Destroy(collision.gameObject);
            }
            
            else{
                sfxManager.PlaySFX("GameOverHit");
                uiController.ShowGameOverScreen();
            }
            
        }

        if(collision.transform.CompareTag("DeathBox"))
        {
            uiController.ShowGameOverScreen();
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.CompareTag("Collectable"))
        {
            collectedCoins++;
            sfxManager.PlaySFX("Coin");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("AirJump"))
        {
            airJump = true;
            sfxManager.PlaySFX("DoubleJumpPowerUp");
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("Shield"))
        {
            shieldIsActive = true;
            shield.SetActive(true);
            sfxManager.PlaySFX("ShieldPowerUp");
            Destroy(collision.gameObject);
        }
    }
}
