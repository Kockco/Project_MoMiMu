using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipDetail : MonoBehaviour
{
    [SerializeField]
    private HingeJoint2D hinge;

    public ClipDetail instance;
    
    public void CutHinge()
    {
        Destroy(hinge);
    }

    public void LayerControl()
    {
        this.gameObject.layer = LayerMask.NameToLayer("NoPLAYER");
    }
}
