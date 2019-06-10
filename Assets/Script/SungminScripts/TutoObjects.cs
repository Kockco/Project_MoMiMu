using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoObjects : MonoBehaviour
{
    public GameObject[] arrow;
    private int arrowNum = 1;

    public Image[] hintImage;

    private PlayerMovement playerInstance;

    public GameObject triggerObject;

    void Start()
    {
        playerInstance = GetComponent<PlayerMovement>();

        for (int i = 1; i < arrow.Length; i++)
            arrow[i].SetActive(false);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Arrow_" + arrowNum)
        {
            hintImage.SetValue(hintImage, arrowNum);
            Destroy(col.gameObject); // 화살표 파괴할지 혹은 밑의 줄에
            arrow[arrowNum - 1].SetActive(false); // 화살표 오브젝트 풀링을 쓸지
            arrow[arrowNum].SetActive(true);
            arrowNum++;
        }

        if (col.gameObject == triggerObject && playerInstance.isStickKeyDown)
        {
            hintImage.SetValue(hintImage, 4);
            if (triggerObject.transform.rotation.y >= 150.0f) // 초기 값 저장하고 그거에 대해 150값 이동해야함ㅇ
                arrowNum++;
        }
        else
            hintImage.SetValue(hintImage, arrowNum);
    }
}