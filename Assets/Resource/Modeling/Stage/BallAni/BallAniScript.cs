using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAniScript : MonoBehaviour
{
    public GameObject ball;
    public GameObject rotateObject;
    public Animator ani;
    public void Update()
    {
        if(rotateObject.transform.rotation.z > 0.175f && ball.GetComponent<MovingObject>().pipeBall == false)
        {
            if (!ball.GetComponent<BallAni>())
            {
                ball.AddComponent<BallAni>();
                ball.GetComponent<MovingObject>().pipeBall = true;
            }
        }
    }
}
