using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickArrow : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement momimu;

    [SerializeField]
    private SpriteRenderer[] arrowZone;
    [SerializeField]
    private Sprite[] dots;

    [SerializeField]
    private float vecZ;

    // Update is called once per frame
    void Update()
    {
        SetVectorZ();
        CreateDot();
        this.transform.rotation = Quaternion.Euler(0, 0, vecZ);
    }

    void SetVectorZ()
    {
        vecZ = 0f;

        if (momimu.cur_throw_force_value.x > 0)
            vecZ = 90f;
        if (momimu.cur_throw_force_value.x < 0)
            vecZ = -90f;

        if (momimu.cur_throw_force_value.y != 0)
            vecZ = momimu.cur_throw_force_value.x * 4.5f;
    }

    void CreateDot()
    {


        switch(Mathf.Abs(momimu.cur_throw_force_value.x))
        {
            case 1:
                arrowZone[0].sprite = dots[5];
                break;
            case 2:
            case 3:
            case 4:
            case 5:
            case 7:
            case 8:
            case 9:
            case 10:
                for (int i = 0; i < arrowZone.Length; i++)
                    arrowZone[i].sprite = null;
                break;
            default:
                break;
        }
    }
}