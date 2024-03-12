using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
public class ButtonUlt : MonoBehaviour
{
    private DictionaryC klasaZDictionary;

    int pomcol;
    int pomrow;
    int k = 0;
    string test;
    // public static int random;
    public static bool blockade = true;
    public static bool blockade2 = true;

    int row;
    int col;
    public static char random;
    public new Collider2D collider;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = true;

    }

    void Update()
    {
        if (blockade && blockade2)
        {

            collider.enabled = true;

        }
        else
        {
            collider.enabled = false;

        }
    }
    private void OnMouseDown()
    {
        FindObjectOfType<EndMusic>().Button();

        FindObjectOfType<Controller>().EndOfAttack();

        FindObjectOfType<Controller>().EndOfGreen();//


        //  blockade = false;
        if (random == '1')
        {
            Debug.Log("Ult");
            FindObjectOfType<Knight1>().Ult();
        }
        else if (random == '2')
        {
            //    FindObjectOfType<Knight2>().Attack();
            FindObjectOfType<Knight2>().Ult();

        }
        else if (random == '3')
        {
            //       FindObjectOfType<Knight3>().Attack();
            FindObjectOfType<Knight3>().Ult();

        }
        else if (random == '0')
        {
            //      FindObjectOfType<Serf1>().Attack();
            FindObjectOfType<Serf1>().Ult();

        }
        else if (random == '4')
        {
            FindObjectOfType<Serf2>().Ult();

        }



    }
}    