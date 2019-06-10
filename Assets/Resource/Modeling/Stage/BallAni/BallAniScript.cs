using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAniScript : MonoBehaviour
{
    public GameObject ball;
    public Animator ani;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == ball.name)
        {
            if (!ball.GetComponent<BallAni>())
            {
                ball.AddComponent<BallAni>();
                ball.GetComponent<MovingObject>().pipeBall = true;
            }
        }
    }
}
