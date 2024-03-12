using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Dzwiek_menu : MonoBehaviour
{
    public AudioSource src;
    public AudioClip muzyka;

    void Start()
    {
        src.clip = muzyka; 
        src.loop = true;
        src.volume = 0.15f;
        src.Play();
    }



}
