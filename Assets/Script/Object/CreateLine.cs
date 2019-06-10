using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    public GameObject Line;
    public int size;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 createPos = transform.position;
        for (int i = 0; i < size; i++)
        {
            Instantiate(Line, createPos, Line.transform.rotation, transform);
            transform.GetChild(i).name = "Line" + i;
            transform.GetChild(i).GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            if (i != 0)
            {
                transform.GetChild(i).gameObject.AddComponent<HingeJoint2D>();
                transform.GetChild(i).gameObject.GetComponent<HingeJoint2D>().connectedBody = transform.GetChild(i-1).GetComponent<Rigidbody2D>();
                transform.GetChild(i).gameObject.GetComponent<HingeJoint2D>().autoConfigureConnectedAnchor = false;
                if(i == 1) transform.GetChild(i).gameObject.GetComponent<HingeJoint2D>().anchor = new Vector2(0f, 0f);
                transform.GetChild(i).gameObject.GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, -1f);
                transform.GetChild(i).gameObject.GetComponent<HingeJoint2D>().useLimits = true;


                JointAngleLimits2D jointAngleLimits2D;
                jointAngleLimits2D = transform.GetChild(i).gameObject.GetComponent<HingeJoint2D>().limits;
                jointAngleLimits2D.min = 60;
                jointAngleLimits2D.max = 120;
                transform.GetChild(i).gameObject.GetComponent<HingeJoint2D>().limits = jointAngleLimits2D;
            }
            if(i == 0 || i == size-1)
            {
                transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
            createPos = new Vector2(createPos.x += 0.15f, createPos.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
