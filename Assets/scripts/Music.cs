using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource src;
    public AudioClip music;

    void Start()
    {
        src.volume = 0.06f;

        src.clip = music;

        src.Play();
    }

    void Update()
    {
        
    }

    public void Stop()
    {
        src.Stop();
    }

    public void Play()
    {
        src.Play();
    }
}
