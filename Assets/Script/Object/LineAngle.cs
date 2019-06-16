using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAngle : MonoBehaviour
{
    public GameObject basket;
    public GameObject pin;
    Vector2 pos;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle = CalculateAngle(basket.transform.position, pin.transform.position);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    public static float CalculateAngle(Vector2 from, Vector2 to)
    {
        return Quaternion.FromToRotation(Vector2.up, to - from).eulerAngles.z;
    }

}
