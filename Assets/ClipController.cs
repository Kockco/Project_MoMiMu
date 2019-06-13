using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] arrows;

    [SerializeField]
    private ClipDetail[] clips;
    
    void Update()
    {
        if (!arrows[0].activeInHierarchy)
        {
            clips[0].CutHinge();
            clips[0].LayerControl();
        }
        if (!arrows[0].activeInHierarchy)
        {
            clips[1].CutHinge();
            clips[1].LayerControl();
        }
        if (!arrows[1].activeInHierarchy)
        {
            clips[2].CutHinge();
            clips[2].LayerControl();
        }
        if (!arrows[2].activeInHierarchy)
        {
            clips[3].CutHinge();
            clips[3].LayerControl();
        }
        if (!arrows[3].activeInHierarchy)
        {
            clips[4].CutHinge();
            clips[4].LayerControl();
        }
    }
}
