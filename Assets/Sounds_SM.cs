using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_SM : MonoBehaviour
{
    public AudioSource backMusic;
    public AudioSource jumpSnd;
    public AudioSource dieSnd;

    void Start()
    {
        backMusic = GetComponent<AudioSource>();
        jumpSnd = GetComponent<AudioSource>();
        dieSnd = GetComponent<AudioSource>();
    }
}
