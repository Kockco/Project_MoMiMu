using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingObject : MonoBehaviour
{
    Rigidbody rb;
    public bool ch1Stick;
    public bool ch2Stick;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(ch1Stick == true && ch2Stick == true)
        {
            rb.mass = 18;
        }
        else
        {
            rb.mass = 1000;
        }
    }
    private void OnCollisionStay(Collision collision)
    {

    }
}
