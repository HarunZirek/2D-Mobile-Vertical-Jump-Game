using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aspectRatio : MonoBehaviour
{
    public SpriteRenderer bg;
    public GameObject pit;
    public GameObject cam;
    public float PitDistance;
    void Start()
    {
        scaleRatio();
    }

    private void scaleRatio()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = bg.bounds.size.x / bg.bounds.size.y;

        float difInSize = targetRatio / screenRatio;
        Camera.main.orthographicSize = bg.bounds.size.y / 2 * difInSize;

        PitDistance = 3 / screenRatio;
        pit.transform.position = new Vector3(0, transform.position.y-PitDistance, -10);
    }
}
