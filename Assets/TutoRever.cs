using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoRever : MonoBehaviour
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
        hinge = GetComponent<HingeJoint2D>();
        motorPower = new JointMotor2D();
        motorPower.maxMotorTorque = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        if (motorPower.motorSpeed > -10)
        {
            motorPower.motorSpeed -= 3000f * Time.deltaTime;
            hinge.motor = motorPower;
        }
        if (transform.eulerAngles.z < 360 && transform.eulerAngles.z > 320)
        {
            movePos = (transform.eulerAngles.z - 360) * 0.0725f;
        }
        //회전
        for (int i = 0; i <= 1; i++)
        {
            if (player[i].GetComponent<PlayerMovement>().joint)
            {
                if (player[i].GetComponent<PlayerMovement>().joint.connectedBody == GetComponent<Rigidbody2D>())
                {

                    motorPower.motorSpeed = player[i].GetComponent<PlayerMovement>().cur_throw_force_value.x * 3;
                    hinge.motor = motorPower;
                }
            }
        }
    }
}
