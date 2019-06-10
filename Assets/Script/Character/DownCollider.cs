using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownCollider : MonoBehaviour
{
    Quaternion a;
    public bool onCol;

    private void Start()
    {
        a = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = a;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            onCol = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            onCol = false;
        }
    }
}
