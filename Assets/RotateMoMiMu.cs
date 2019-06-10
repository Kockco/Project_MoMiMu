using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMoMiMu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, 10 * Time.deltaTime + 2));
    }
}
