//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerAnime_SM : MonoBehaviour
//{
//    public Animator anime;
//    private PlayerMovement _playerscript;

//    void Start()
//    {
//        anime = GetComponent<Animator>();
//        _playerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
//    }

//    public void Jump(PlayerMovement py)
//    {
//        if (py.jumpPower == py.jump1Level_Force)
//            anime.SetInteger("JumpKeyDown", 1);

//        if (py.jumpPower == py.jump2Level_Force)
//            anime.SetInteger("JumpKeyDown", 2);

//        if (py.jumpPower == py.jump3Level_Force)
//            anime.SetInteger("JumpKeyDown", 3);

//        if (py.JumpKeyUp == true)
//        {
//            anime.SetInteger("JumpKeyDown", 0);
//            anime.SetTrigger("OnAir");

//        }
//    }

//    public void Walk(PlayerMovement py)
//    {
//        anime.SetBool("MoveKeyDown", true);

//        if (py.h == -1)
//            anime.SetInteger("LorR_Walk", 1);

//        if (py.h == 0)
//            anime.SetInteger("LorR_Walk", 0);

//        if (py.h == 1)
//            anime.SetInteger("LorR_Walk", 2);

//        if (py.h == 0)
//            anime.SetBool("MoveKeyDown", false);
//    }
    
//    public void PPush(PlayerMovement py)
//    {
//        // if (py.isStickKeyDown == true)
//            anime.SetBool("TouchDown", true);

//        if (py.isStickKeyDown == false)
//            anime.SetBool("TouchDown", false);
//    }
//}
