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

    [SerializeField]
    private PlayerMovement momi;
    [SerializeField]
    private PlayerMovement momu;

    [SerializeField]
    private HingeJoint2D hinge;

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
        }

        if (arrowTrigger[2].activeInHierarchy == true)
        {
            momuPopImage.sprite = momuPops[0];
        }
        else if (arrowTrigger[3].activeInHierarchy == true)
        {
            momuPopImage.sprite = momuPops[1];
        }

        AllPopImage();
        Sticky();
    }

    void AllPopImage()
    {
        if (!arrowTrigger[1].activeInHierarchy && !arrowTrigger[3].activeInHierarchy
            && !arrowTrigger[0].activeInHierarchy && !arrowTrigger[2].activeInHierarchy)
        {
            momiPopObject.SetActive(false);
            momuPopObject.SetActive(false);
            allPopObject.SetActive(true);
            allPopImage.sprite = allPops[0];
        }

        if (arrowTrigger[5].activeInHierarchy)
        {
            allPopObject.SetActive(false);
            momiPopObject.SetActive(true);
            momuPopObject.SetActive(true);
            momiPopImage.sprite = momiPops[2];
            momuPopImage.sprite = momuPops[2];
        }

        //if (!arrowTrigger[5].activeInHierarchy)
        //{
        //    allPopObject.SetActive(true);
        //    momiPopObject.SetActive(false);
        //    momuPopObject.SetActive(false);
        //    allPopImage.sprite = allPops[1];
        //}

        if (!arrowTrigger[4].activeInHierarchy && (hinge.transform.rotation.z >= -135.0f))
        {
            allPopImage.sprite = allPops[1];
        }
    }

    void Sticky()
    {
        if (momi.joint != null)
            momiPopImage.sprite = momiPops[3];
        else if (momi.isStickKeyDown)
            momiPopImage.sprite = momiPops[2];

        if (momu.joint != null)
            momuPopImage.sprite = momuPops[3];
        else if (momu.isStickKeyDown)
            momuPopImage.sprite = momuPops[2];
    }
}