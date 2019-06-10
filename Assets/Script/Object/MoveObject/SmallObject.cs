using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallObject : MonoBehaviour
{
    public float speed;
    public float DownPosition;
    // Update is called once per frame
    void Update()
    {
    }
    public void Down()
    {
        if (transform.position.y > DownPosition)
        {
            transform.Translate(0, -speed* Time.deltaTime, 0);
        }
    }
}
