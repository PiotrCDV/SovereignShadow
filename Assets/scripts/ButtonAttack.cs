using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
public class ButtonAttack : MonoBehaviour
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

        FindObjectOfType<Controller>().EndOfGreen();//

        FindObjectOfType<Controller>().EndOfUltStalker();  //?????

        //  blockade = false;
        if (random == '1')
        {
            FindObjectOfType<Knight1>().Attack();
        }
        else if (random == '2')
        {
            FindObjectOfType<Knight2>().Attack();

        }
        else if (random == '3')
        {
            FindObjectOfType<Knight3>().Attack();

        }
        else if (random =='0')
        {
            FindObjectOfType<Serf1>().Attack();

        }
        else if (random == '4')
        {
            FindObjectOfType<Serf2>().Attack();

        }



    }
    /*
    public void RangeOfAttack(int column, int row, int dmg)
    {



        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;

        for (int i = -1 - k; i < 2 + k; i++)
        {
            pomrow = row;
            pomrow = pomrow + i;
            for (int j = -1 - k; j < 2 + k; j++)
            {
                pomcol = column;
                pomcol = pomcol + j;
                test = "P" + pomrow + pomcol;
                if (dictionaryTypes.ContainsKey(test))
                {
                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;

                    if (kolorObiekt.enemy == true)
                    {
                        Debug.Log(test);
                        kolorObiekt.enemy2 = true;
                        kolorObiekt.dmg = dmg;
                        // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                    }
                    //  kolorObiekt.green = true;

                    kolorObiekt.Kolor();

                }

            }

        }
        pomcol = column;
        pomrow = row;
    }
    */
    /*
    public void EndOfAttack()
    {
        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();

        col = pomcol;
        row =  pomrow;
        for (int i = -1 - k; i < 2 + k; i++)
        {
            pomrow = row;
            pomrow = pomrow + i;
            for (int j = -1 - k; j < 2 + k; j++)
            {
                pomcol = col;

                pomcol = pomcol + j;
                test = "P" + pomrow + pomcol;
                if (dictionaryTypes.ContainsKey(test))
                {
                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;
                    kolorObiekt.enemy2 = false;
                    kolorObiekt.Kolor();

                }

            }

        }
      //  collider.enabled = false;

    }
    */
}
