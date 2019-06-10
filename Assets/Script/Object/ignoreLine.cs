using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreLine : MonoBehaviour
{
    private void Update()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("PLAYER"), LayerMask.NameToLayer("LINE"), true);
    }
}
