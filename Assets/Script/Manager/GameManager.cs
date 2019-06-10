using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] player;
    public GameObject[] playerPrefab;
    public Vector3[] playerSpornPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player[0] == null)
        {
            player[0] = GameObject.Find("Char");
        }
        else if (player[1] == null)
        {
            player[1] = GameObject.Find("Char2");
        }

        if (player[0] == null)
        {
            Instantiate(playerPrefab[0], playerSpornPosition[0], Quaternion.identity);
        }
        if (player[1] == null)
        {
            Instantiate(playerPrefab[1], playerSpornPosition[1], Quaternion.identity);
        }
    }
}
