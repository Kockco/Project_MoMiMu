using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
    }
}