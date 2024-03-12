using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    public static bool blockade = true;
    public new Collider2D collider;
    // public static int random ;
    public static char random;

    void Start()
    {
        collider = GetComponent<Collider2D>();

    }

    void Update()
    {
        if(blockade)
        {

            collider.enabled = true;

        }
        else
        {
            collider.enabled = false;

        }

        if (random == '1')
        {
            FindObjectOfType<Knight1>().MyRound();
        }
        else if (random == '2')
        {
            FindObjectOfType<Knight2>().MyRound();

        }
        else if (random == '3')
        {
            FindObjectOfType<Knight3>().MyRound();

        }
        else if (random == '0')
        {
            FindObjectOfType<Serf1>().MyRound();

        }
        else if (random == '4')
        {
            FindObjectOfType<Serf2>().MyRound();

        }
    }
    
    private void OnMouseDown()
    {
        FindObjectOfType<EndMusic>().Button();

        FindObjectOfType<Controller>().EndOfAttack();

        FindObjectOfType<Controller>().EndOfUltStalker();

       // blockade = false;
        if (random == '1')
        {
            FindObjectOfType<Knight1>().Button();
        }
        else if (random == '2')
        {
            FindObjectOfType<Knight2>().Button();

        }
        else if (random == '3')
        {
            FindObjectOfType<Knight3>().Button();

        }else if(random == '0')
        {
            FindObjectOfType<Serf1>().Button();

        }
        else if (random == '4')
        {
            FindObjectOfType<Serf2>().Button();

        }



    }
}
