using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterCrawling : MonoBehaviour
{
    private GameObject player;
    private GameObject end;
    private Animator anim;
    private GameObject pit;
    private Rigidbody2D rb;
    private bool FacingRight = true;
    private float speed;
    private int sound = 1;
    public bool isAttacking = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        pit = GameObject.Find("Bottom");
        end = GameObject.Find("finishLine");
    }
  
    void FixedUpdate()
    {              
        if(end.GetComponent<LevelComplete>().reviveCount==0)
        {
            if(isAttacking==true && player.GetComponent<Playables>().isDead==true)
            {              
                    Destroy(gameObject);                
            }
        }
        if(transform.position.y<pit.transform.position.y)
        {
            Destroy(gameObject);
            if(player.GetComponent<Playables>().isDead==false)
            {
                FindObjectOfType<audioManager>().Play("monsterDeath");
            }
        }
        
        if (isAttacking==true)
        {
            StartCoroutine(attack());
        }       
        else
        {
            anim.SetBool("isRunning", false);
            if (-0.5f < transform.position.y - player.transform.position.y && 0.5f > transform.position.y - player.transform.position.y)
            {
                if (transform.position.x - player.transform.position.x <= 2.5f && transform.position.x - player.transform.position.x >= -2.5f)
                {
                    if (player.transform.position.x < transform.position.x)
                    {
                        if (FacingRight == true)
                        { flip(); }
                        speed = -0.6f;
                        isAttacking = true;
                    }
                    else if (player.transform.position.x >= transform.position.x)
                    {
                        if (FacingRight == false)
                        { flip(); }
                        speed = 0.6f;
                        isAttacking = true;
                    }
                }
                else
                {
                    sound = 1;
                }
            }
            else { sound = 1; }
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            player.GetComponent<Playables>().isDead = true;
            FindObjectOfType<audioManager>().Play("monsterDeath");
            Destroy(gameObject);
        }
    }

    IEnumerator attack()
    {
        if(sound==1)
        {
            FindObjectOfType<audioManager>().Play("monster1");
            sound = 0;
        }
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isRunning", true);
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

   
    void flip()
    {
        FacingRight = !FacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
