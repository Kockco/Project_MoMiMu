using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Vector3 startPos;
    Rigidbody2D rb;
    public bool pipeBall;

    // Start is called before the first frame update
    void Start()
    {
        pipeBall = false;
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "OutSide")
        {
            transform.position = startPos;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
        if(gameObject.name == "Ball1" && collision.transform.tag == "pipe" && pipeBall == false)
        {
            transform.position = startPos;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.name == "col_Floor3 hinge" && transform.name == "Ball1")
        {
            Vector2 a = new Vector2(20, 0);
            rb.velocity = a;
        }
    }
}
