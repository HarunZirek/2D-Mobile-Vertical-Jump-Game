using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playables : MonoBehaviour
{
    public float speed;
    public float airSpeed;
    public float jumpForce;
    public bool isDead;
    public float JumpTimer;
    public float JumpCoolDown;
    private bool isFacingRight = true;

    private Rigidbody2D rb;
    private Animator anim;

    public bool isPlaying = true;
    public bool canJump = false;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatGround;
    public float checkRadius;

    private bool movingRight = false;
    private bool movingLeft = false;

    private int deadSound = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        JumpTimer = JumpCoolDown;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatGround);
        checkVital();
        CheckMove();       
        JumpControl();     
    }

    public void moveRight()      //button controls
    {
       if(isPlaying==true)
        {
            movingRight = true;
            movingLeft = false;
        }
    }   
    public void rightCancel()
    {
        movingRight = false;
    }
    public void moveLeft()
    {
        if (isPlaying == true)
        {
            movingRight = false;
            movingLeft = true;
        }
    }
    public void leftCancel()
    {
        movingLeft = false;
    }
    private void CheckMove()   //movement controls
    {
       if(isPlaying==true && isDead==false)
        {
            if (movingLeft == true && movingRight == false)
            {
                if (isFacingRight == true)
                {
                    flip();
                }
                if (isGrounded == true && rb.velocity.y == 0)
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    anim.SetBool("isWalking", true);
                }
                else
                {
                    rb.velocity = new Vector2(-airSpeed, rb.velocity.y);
                }
            }   //move left
            else if (movingLeft == false && movingRight == true)
            {
                if (isFacingRight == false)
                {
                    flip();
                }
                if (isGrounded == true && rb.velocity.y == 0)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    anim.SetBool("isWalking", true);
                }
                else
                {
                    rb.velocity = new Vector2(airSpeed, rb.velocity.y);
                }
            } //move right
            else if (movingLeft == false && movingRight == false)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                anim.SetBool("isWalking", false);
                anim.SetBool("isJumping", false);
            }
        }
    }  
    private void JumpControl() //timer for jump function
    {
        if(canJump==false)
        {
            JumpTimer = JumpCoolDown;
        }
        if (isGrounded == true && rb.velocity.y == 0 && canJump==true)
        {
            JumpTimer -= Time.deltaTime;
        }
        else if (isGrounded == false && rb.velocity.y != 0)
        {
            JumpTimer = JumpCoolDown;
        }
        if (JumpTimer <= 0)
        {
            if(isPlaying==true && isDead==false)
            {
                jump();
                JumpTimer = JumpCoolDown;
            }
        }
    } 
    public void jump()    //jumping control
    {
        if(canJump==true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            FindObjectOfType<audioManager>().Play("Jump");
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", true);
        }        
    }


    private void checkVital() //checking dead or alive state
    {
        if (isDead == true)
        {           
            isPlaying = false;
            canJump = false;
            JumpTimer = JumpCoolDown;
            if(isGrounded==true)
            {
                rb.velocity = new Vector2(0, 0);
            }
            if (deadSound==1)
            {
                deadSound = 0;
                FindObjectOfType<audioManager>().Play("hurt");
            }
            anim.SetBool("isDead", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
        }
        else if (isDead == false)
        {
            anim.SetBool("isDead", false);
            deadSound = 1;
        }
    }
    void flip()   
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    public void levelDone()
    {
        rb.gravityScale = 0f;
        rb.mass = 0f;
        isPlaying = false;
        canJump = false;
    }
 
}
