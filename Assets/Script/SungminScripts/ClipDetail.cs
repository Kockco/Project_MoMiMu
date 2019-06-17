using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipDetail : MonoBehaviour
{
    [SerializeField]
    private HingeJoint2D hinge;

    [SerializeField]
    public ClipDetail instance;
    [SerializeField]
    private GameObject[] instanceFriends;

    public void CutHinge()
    {
        Destroy(hinge);
    }

    public void LayerControl()
    {
        this.gameObject.layer = LayerMask.NameToLayer("NoPLAYER");

        for (int i = 0; i < instanceFriends.Length; i++)
            instanceFriends[i].layer = LayerMask.NameToLayer("NoPLAYER");
    }
}
