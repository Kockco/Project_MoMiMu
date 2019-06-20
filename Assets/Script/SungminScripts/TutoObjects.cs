using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoObjects : MonoBehaviour
{
    public GameObject[] arrow;

    [SerializeField]
    private int arrowNum = 1;

    [SerializeField]
    private PlayerMovement playerInstance;
    [SerializeField]
    private ImageControl pops;

    public bool onJoint = false;

    void Start()
    {
        playerInstance = this.GetComponent<PlayerMovement>();

        for (int i = 1; i < arrow.Length; i++)
            arrow[i].SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Arrow (" + arrowNum + ")")
        {
            arrow[arrowNum - 1].SetActive(false);
            arrow[arrowNum++].SetActive(true);
        }

        if (col.gameObject.name == "Arrow (4)")
            arrow[3].SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "moving")
        {
            onJoint = true;
            pops.Sticky();
        }
        else
            onJoint = false;
    }
}