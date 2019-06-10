using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpGauge : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement pyScript;
    public GameObject stickImage;
    
    void Start()
    {
        pyScript = player.GetComponentInParent<PlayerMovement>();
    }

    void Update()
    {
        StickState(pyScript);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+0.22f, player.transform.position.z-2.88f);
    }

    void StickState(PlayerMovement py)
    {
        if (py.joint == null)
            stickImage.SetActive(false);
        else
            stickImage.SetActive(true);
    }
}
