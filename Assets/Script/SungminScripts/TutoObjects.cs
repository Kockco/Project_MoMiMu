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

    public GameObject triggerObject;
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
            arrow[arrowNum - 1].SetActive(false); // 화살표 오브젝트 풀링을 쓸지
            arrow[arrowNum].SetActive(true);
            arrowNum++;
        }

        if (col.gameObject.name == "Arrow (4)")
            arrow[3].SetActive(false);

            if (col.gameObject == triggerObject) // && playerInstance.isStickKeyDown)
        {
            if (triggerObject.transform.rotation.y >= 150.0f) // 초기 값 저장하고 그거에 대해 150값 이동해야함ㅇ
                arrowNum++;
        }
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