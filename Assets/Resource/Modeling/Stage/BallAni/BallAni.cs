using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAni : MonoBehaviour
{
    float endTime;
    private void Start()
    {
        endTime = 0;
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().SetTrigger("end");
    }
    // Update is called once per frame
    void Update()
    {
        endTime += Time.deltaTime;
        if (endTime > 2.7f)
        {
            transform.position = new Vector2(-6.11f, -4.43f);
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Animator>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = true;
            Destroy(this);
        }

    }
}
