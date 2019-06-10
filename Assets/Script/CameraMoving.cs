using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject Target;
    Transform a;
    public Vector2 LeftUp;
    public Vector2 RightDown;
    public float cameraSpeed = 2.5f;
    private void Start()
    {
        a = transform;
    }
    void FixedUpdate()
    {
        if (Target == null)
        {
            Target = GameObject.Find("MoMi");
        }
        else
        {
            float TargetPosX = Target.transform.position.x;
            float TargetPosY = Target.transform.position.y;
            if (Target.transform.position.x < LeftUp.x)
            {
                TargetPosX = LeftUp.x;
            }
            else if (Target.transform.position.x > RightDown.x)
            {
                TargetPosX = RightDown.x;
            }
            if (Target.transform.position.y > LeftUp.y)
            {
                TargetPosY = LeftUp.y;
            }
            else if (Target.transform.position.y < RightDown.y)
            {
                TargetPosY = RightDown.y;
            }
            Vector3 TargetPos = new Vector3(TargetPosX, TargetPosY, a.position.z);
            transform.position = Vector3.Lerp(transform.position, TargetPos, Time.fixedDeltaTime * cameraSpeed);
        }
    }
}
