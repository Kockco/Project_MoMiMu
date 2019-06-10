using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverRotate : MonoBehaviour
{
    public GameObject[] player;
    public GameObject reverBasket;
    public HingeJoint2D hinge;
    JointMotor2D motorPower;
    Vector2 speed = new Vector2(0, -1.5f);
    Vector2 basketPos;

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
        basketPos = new Vector2(0.15f, 2.4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (motorPower.motorSpeed > -10)
        {
            motorPower.motorSpeed -= 3000f * Time.deltaTime;
            hinge.motor = motorPower;
        }
        if(transform.eulerAngles.z < 360 && transform.eulerAngles.z > 320)
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
        reverBasket.GetComponent<RelativeJoint2D>().linearOffset = new Vector2(basketPos.x, basketPos.y + movePos);
        //올라갓다 내려갓다하는 물체
        //if (transform.rotation.z <= -0.17f)
        //{

        //    reverBasket.GetComponent<RelativeJoint2D>().linearOffset = new Vector2(basketPos.x,basketPos.y + movePos);
        //    if (basketPos.y > -0.66f)
        //    {
        //        basketPos += speed * Time.deltaTime;
        //        reverBasket.GetComponent<RelativeJoint2D>().linearOffset = basketPos;
        //    }
        //}
        //else if(transform.rotation.z > -0.17f)
        //{
        //    if (basketPos.y < 2.4f)
        //    {
        //        basketPos -= speed * Time.deltaTime;
        //        reverBasket.GetComponent<RelativeJoint2D>().linearOffset = basketPos;
        //    }
        //}
    }
}
