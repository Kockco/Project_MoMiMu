using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubGroundScroll : MonoBehaviour
{
    private Vector3 startPos;

    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, startPos.y * Time.deltaTime + 1, 0);

        if (this.transform.position.y >= 60)
            this.transform.position = startPos;
    }
}
