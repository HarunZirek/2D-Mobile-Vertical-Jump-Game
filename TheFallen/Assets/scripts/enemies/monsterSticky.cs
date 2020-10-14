using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSticky : MonoBehaviour
{
    private GameObject player;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
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
   
}
