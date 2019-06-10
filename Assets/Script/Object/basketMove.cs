using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketMove : MonoBehaviour
{
    public GameObject basket;
    public GameObject[] player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = new GameObject[2];
        player[0] = GameObject.Find("MoMi");
        player[1] = GameObject.Find("MoMu");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <= 1; i++)
        {
            if(player[i].GetComponent<PlayerMovement>().joint)
            {
                if (player[i].GetComponent<PlayerMovement>().joint.connectedBody == GetComponent<Rigidbody2D>())
                {
                    basket.GetComponent<Rigidbody2D>().velocity = player[i].GetComponent<ConstantForce2D>().force/1.5f;
                }
            }
        }
    }
}
