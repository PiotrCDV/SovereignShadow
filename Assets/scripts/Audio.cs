using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioSource src;
    public AudioClip
        knightWalk, knightAttack, knightDeath, knightHurt, 
        archerWalk, archerAttack, archerDeath, archerHurt,
         serfWalk, serfAttack, serfDeath, serfHurt , button;


    public void Button()
    {
        src.volume = 0.7f;

        src.clip = button;

        src.Play();
    }
    public void kWalk()
        {
        src.volume = 0.35f;

        src.clip = knightWalk;

        src.Play();
    }
    public void kAttack()
    {
        src.volume = 0.25f;
        src.clip = knightAttack;

        src.Play();

    }
    public void kDeath()
    {
        src.volume = 0.45f;

        src.clip = knightDeath;

        src.Play();
    }
    public void kHurt()
    {
        src.volume = 0.45f;

        src.clip = knightHurt;

        src.Play();
    }
    public void aWalk()
    {
        src.volume = 1f;
        src.clip = archerWalk;

        src.Play();
    }
    public void aAttack()
    {
        src.volume = 0.4f;
        src.clip = archerAttack;

        src.Play();

    }
    public void aDeath()
    {
        src.volume = 1f;
        src.clip = archerDeath;

        src.Play();
    }
    public void aHurt()
    {
        src.volume = 1f;
        src.clip = archerHurt;

        src.Play();
    }
    public void sWalk()
    {
        src.volume = 0.35f;
        src.clip = serfWalk;

        src.Play();
    }
    public void sAttack()
    {
        src.volume = 0.8f;
        src.clip = serfAttack;

        src.Play();

    }
    public void sDeath()
    {
        src.volume = 0.2f;
        src.clip = serfDeath;

        src.Play();
    }
    public void sHurt()
    {
        src.volume = 0.4f;
        src.clip = serfHurt;

        src.Play();
    }


    public void Stop()
    {
        src.Stop();
    }
}
