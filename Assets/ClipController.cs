using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] arrows;

    [SerializeField]
    private ClipDetail[] clips;

    private bool step_1 = false;
    private bool step_2 = false;

    void Update()
    {
        if (!arrows[0].activeInHierarchy && !arrows[2].activeInHierarchy)
        {
            clips[0].CutHinge();
            clips[0].LayerControl();
            clips[2].CutHinge();
            clips[2].LayerControl();
            step_1 = true;
        }
        
        if (step_1 && !arrows[1].activeInHierarchy && !arrows[3].activeInHierarchy)
        {
            clips[1].CutHinge();
            clips[1].LayerControl();
            clips[3].CutHinge();
            clips[3].LayerControl();
            step_2 = true;
        }
        
        if (step_2 && !arrows[4].activeInHierarchy)
        {
            clips[4].CutHinge();
            clips[4].LayerControl();
        }
    }
}