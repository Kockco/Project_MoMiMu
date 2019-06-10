using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RineRander1 : MonoBehaviour
{
    LineRenderer rope;
    Vector3 ropeP1, ropeP2;
    // Start is called before the first frame update
    void Start()
    {
        rope = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rope.SetPosition(0, GameObject.Find("Baguny (1)").GetComponent<Transform>().position);
        rope.SetPosition(1, GameObject.Find("pin3").GetComponent<Transform>().position);
        rope.SetPosition(2, GameObject.Find("line3").GetComponent<Transform>().position);
    }
}
