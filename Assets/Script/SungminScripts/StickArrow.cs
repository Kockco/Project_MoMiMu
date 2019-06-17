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
            // 힘은 최대 25까지, 약 6.25 단위로 변경
            case 1:
            case 2:
            case 2.5f:
                arrowZone[0].sprite = dots[0];
                arrowZone[1].sprite = dots[4];
                for (int i = 2; i < arrowZone.Length; i++)
                    arrowZone[i].sprite = null;
                break;
            case 3:
            case 4:
            case 5:
                arrowZone[0].sprite = dots[0];
                arrowZone[1].sprite = dots[1];
                arrowZone[2].sprite = dots[4];
                for (int i = 3; i < arrowZone.Length; i++)
                    arrowZone[i].sprite = null;
                break;
            case 6:
            case 7:
            case 7.5f:
                arrowZone[0].sprite = dots[0];
                arrowZone[1].sprite = dots[1];
                arrowZone[2].sprite = dots[2];
                arrowZone[3].sprite = dots[4];
                arrowZone[4].sprite = null;
                break;
            case 8:
            case 9:
            case 10:
                arrowZone[0].sprite = dots[0];
                arrowZone[1].sprite = dots[1];
                arrowZone[2].sprite = dots[2];
                arrowZone[3].sprite = dots[3];
                arrowZone[4].sprite = dots[4];
                break;
            default:
                for (int i = 0; i < arrowZone.Length; i++)
                    arrowZone[i].sprite = null;
                break;
        }

        if (momimu.cur_throw_force_value.y != 0)
        {
            arrowZone[0].sprite = dots[0];
            arrowZone[1].sprite = dots[1];
            arrowZone[2].sprite = dots[2];
            arrowZone[3].sprite = dots[3];
            arrowZone[4].sprite = dots[4];
        }
    }
}