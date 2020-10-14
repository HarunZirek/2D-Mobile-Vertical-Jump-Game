using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpHole : MonoBehaviour
{
    public GameObject portal;
    private GameObject player;
    public float My;
    public float Mx;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            player.GetComponent<Playables>().transform.position = new Vector3(portal.transform.position.x + Mx, portal.transform.position.y + My, player.GetComponent<Playables>().transform.position.z);
            player.GetComponent<Playables>().jump();
            FindObjectOfType<audioManager>().Play("monsterDeath");
        }
    }
}
