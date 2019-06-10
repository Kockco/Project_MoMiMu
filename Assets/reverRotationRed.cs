using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverRotationRed : MonoBehaviour
{
    public GameObject[] player;
    public HingeJoint2D hinge;
    JointMotor2D motorPower;
    Vector2 speed = new Vector2(0, -1.5f);

    float movePos = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = new GameObject[2];
        player[0] = GameObject.Find("MoMi");
        player[1] = GameObject.Find("MoMu");
        motorPower = new JointMotor2D();
        motorPower.maxMotorTorque = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        if (hinge.transform.eulerAngles.z < 330 )
        {
            if (hinge.motor.motorSpeed < 10)
            {
                motorPower.motorSpeed += 10 * Time.deltaTime;
                hinge.motor = motorPower;
            }
        }
        else
        {
            motorPower.motorSpeed = 0;
            hinge.motor = motorPower;
        }
        //회전
        for (int i = 0; i <= 1; i++)
        {
            if (player[i].GetComponent<PlayerMovement>().joint)
            {
                if (player[i].GetComponent<PlayerMovement>().joint.connectedBody == GetComponent<Rigidbody2D>())
                {

                    motorPower.motorSpeed = -10;
                    hinge.motor = motorPower;
                }
            }
        }
    }
}
