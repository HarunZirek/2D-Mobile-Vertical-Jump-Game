using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePoint : MonoBehaviour
{
    private GameObject player;
    
    public bool isSaved;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(player.transform.position.y>=transform.position.y)
        {
            isSaved = true;
        }
    }
}
