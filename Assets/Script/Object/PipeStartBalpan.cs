using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeStartBalpan : MonoBehaviour
{
    float a = 0;
    JointMotor2D b;
    void Start()
    {
        a = transform.rotation.z;
        b.motorSpeed = -50f;
        b.maxMotorTorque = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.z > a)
        {
            GetComponent<HingeJoint2D>().motor = b;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
