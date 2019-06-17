using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    public GameObject[] card;
    public UIFuncScript endGame;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball1")
        {
            endGame.GameClearAnime();
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            for (int i = 0; i < 7; i++)
            {
               card[i].gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                card[i].layer = 11;
            }
        }
    }
}
