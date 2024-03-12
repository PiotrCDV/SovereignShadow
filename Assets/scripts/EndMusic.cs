using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusic : MonoBehaviour
{
    public AudioSource src;
    public AudioClip button;
     
 
    public void Button()
    {
        src.volume = 0.7f;

        src.clip = button;

        src.Play();
    }
}
