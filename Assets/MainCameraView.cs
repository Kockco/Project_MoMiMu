using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraView : MonoBehaviour
{
    [SerializeField]
    private Transform[] MoMiMu;
    [SerializeField]
    private float posX;

    // Update is called once per frame
    void Update()
    {
        posX = (MoMiMu[0].transform.position.x + MoMiMu[1].transform.position.x) /2;

        this.transform.position = new Vector3((MoMiMu[0].transform.position.x + MoMiMu[1].transform.position.x) / 2, -0.26f, -10);
        DontOut();
    }

    void DontOut()
    {
        if (this.transform.position.x <= -4.9f)
            this.transform.position = new Vector3(-4.9f, -0.26f, -10);
        else if (this.transform.position.x >= 4.9f)
            this.transform.position = new Vector3(4.9f, -0.26f, -10);
    }
}
