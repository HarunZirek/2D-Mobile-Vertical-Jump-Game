using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private GameObject player;
    public GameObject finish;
    private float Distance;
    public SpriteRenderer bg;
    public GameObject pit;
    public GameObject cam;
    public float PitDistance;
    private void Start()
    {
       
        player = GameObject.Find("Player");
        transform.position = new Vector3(0, player.transform.position.y+3.5f, -10);
        scaleRatio();
    }
   
    void FixedUpdate()
    {

        Distance =1/ ((float)Screen.width / (float)Screen.height);
        if (transform.position.y-player.transform.position.y<=Distance && transform.position.y+5f <= finish.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y+Distance, -10);
            pit.transform.position = new Vector3(0, transform.position.y - PitDistance, -10);
        }


        if (player.transform.position.y <= pit.transform.position.y) 
        {
            player.GetComponent<Playables>().isDead = true;
        }
    }
    public void RestartPos()
    {       
            transform.position = new Vector3(transform.position.x, player.transform.position.y+3.5f, -10);
            pit.transform.position = new Vector3(0, transform.position.y - PitDistance, -10);
    }
    private void scaleRatio()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = bg.bounds.size.x / bg.bounds.size.y;

        float difInSize = targetRatio / screenRatio;
        Camera.main.orthographicSize = bg.bounds.size.y / 2 * difInSize;

        PitDistance = 3 / screenRatio;
        pit.transform.position = new Vector3(0, transform.position.y - PitDistance, -10);
    }
}
