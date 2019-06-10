using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRotate : MonoBehaviour
{
    bool start;

    bool start2;

    public float speed;

    public float time = 0;
    void Update()
    {
        if (start == true && transform.rotation.z < 0.99f)
        {
            transform.rotation = Quaternion.Euler(0, 0,  speed);
            speed += 1;
        }
        if (transform.rotation.z > 0.99f)
        {
            speed = 1;
        }

        if (start2 == true && transform.rotation.z < 0.9f)
        {
            transform.rotation = Quaternion.Euler(0, 0, speed);
            speed += 3;
        }
        if (start2 == true && transform.rotation.z > 0.9f)
        {
            time += Time.deltaTime;
            if(time > 3)
                start2 = false;
        }
        if (start == false && start2 == false && transform.rotation.z > 0f)
        {
            transform.rotation = Quaternion.Euler(0, 0, speed);
            speed -= 3;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(transform.rotation.z < 0.99f && collision.gameObject.name == "Ball2")
        {
            start = true;
        }
        //if (transform.rotation.z < 0.99f && collision.gameObject.name == "Ball1")
        //{
        //    if(collision.gameObject.GetComponent<MovingObject>().pipeBall == false)
        //     start2 = true;
        //}
    }
}

