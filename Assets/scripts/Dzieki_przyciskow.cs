using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dzieki_przyciskow : MonoBehaviour
{
    public AudioSource src;
    public AudioClip klik;
    public void Button()
    {
        src.clip = klik;
        src.Play();
    }





}
