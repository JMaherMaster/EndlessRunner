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
    [SerializeField]int collectedCoins;

    [SerializeField] UIController uiController;
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
        if (isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
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
        }
        else
        {
            anim.SetBool("Falling", false);
        }

        lastYPos = transform.position.y;
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.transform.CompareTag("Obstacle"))
        {
            Debug.Log("hit");
            uiController.ShowGameOverScreen();
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.CompareTag("Collectable"))
        {
            collectedCoins++;
            Destroy(collision.gameObject);
        }
    }
}
