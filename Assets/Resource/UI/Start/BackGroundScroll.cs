using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public Material mat;

    // Update is called once per frame
    void Update()
    {
        float offSetY = mat.mainTextureOffset.y + scrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(0, offSetY);

        mat.mainTextureOffset = newOffset;
    }
}
