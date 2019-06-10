using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] arrowTrigger;

    [SerializeField]
    private Image momiPopImage;
    [SerializeField]
    private Sprite[] momiPops;

    [SerializeField]
    private Image momuPopImage;
    [SerializeField]
    private Sprite[] momuPops;

    [SerializeField]
    private Image allPopImage;
    [SerializeField]
    private Sprite[] allPops;

    [SerializeField]
    private GameObject momiPopObject;
    [SerializeField]
    private GameObject momuPopObject;
    [SerializeField]
    private GameObject allPopObject;

    // Start is called before the first frame update
    void Start()
    {
        momiPops = GetComponent<Sprite[]>();
        momuPops = GetComponent<Sprite[]>();
        allPops = GetComponent<Sprite[]>();

        //momiPopObject = GameObject.Find("MoMiPop");
        //momuPopObject = GameObject.Find("MoMuPop");
        //allPopObject = GameObject.Find("AllPop");

        allPopObject.SetActive(false);
    }

    void Update()
    {
        if (arrowTrigger[0].activeInHierarchy == true)
        {
            momiPopImage.sprite = momiPops[0];
        }
        else if (arrowTrigger[1].activeInHierarchy == true)
        {
            momiPopImage.sprite = momiPops[1];
            AllPopImage();
        }

        if (arrowTrigger[2].activeInHierarchy == true)
        {
            momuPopImage.sprite = momuPops[0];
        }
        else if (arrowTrigger[3].activeInHierarchy == true)
        {
            momuPopImage.sprite = momuPops[1];
            AllPopImage();
        }
    }

    void AllPopImage()
    {
        if (!arrowTrigger[1].activeInHierarchy && !arrowTrigger[3].activeInHierarchy)
        {
            momiPopObject.SetActive(false);
            momuPopObject.SetActive(false);
            allPopObject.SetActive(true);
            allPopImage.sprite = allPops[0];
        }
    }
}