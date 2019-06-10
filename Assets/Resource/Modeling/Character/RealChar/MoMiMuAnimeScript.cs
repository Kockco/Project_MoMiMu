using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoMiMuAnimeScript : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnim;
    private PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        movement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.JumpKeyDown)
            playerAnim.SetTrigger("Jump");

        switch (movement.h)
        {
            case -1:
                playerAnim.SetBool("LeftOrRight", true);
                playerAnim.SetBool("Walk", true);
                return;
            case 1:
                playerAnim.SetBool("LeftOrRight", false);
                playerAnim.SetBool("Walk", true);
                return;
            default:
                playerAnim.SetBool("LeftOrRight", false);
                playerAnim.SetBool("Walk", false);
                return;
        }
    }
}
