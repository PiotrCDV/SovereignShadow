using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    static public int column2 = 0;
    static public int row2 = 0;
    public static bool start = false;
    string test;
    int howManyMoves = 0;
    int pomcol;
    int pomrow;
    private DictionaryC klasaZDictionary;
    private Knight1 ruch;
    private Knight2 knight2;
    private Knight3 knight3;
    private Serf1 serf1;
    private Serf2 serf2;


    int id;
    int columnTemporary;
    int rowTemporary;
    string rycerz2;
    int k = 3;
    string currentPosition;
    string currentPosition2;
    string[] tablica = new string[10];  //6
    int tablicaPozycja = 0;
    int xddd = 0;
    int obroty = 1;
    int a = 0;
    int b = 0;
    string test2;
    bool blokada = true;
    int pomrow2;
    int pomcol2;
    int blokada2 = 0;
    string start2;
    int blokada3 = 0;
    void Update()
    {
      //  if (Knight1.blockade && Knight2.blockade && Knight3.blockade && Knight4.blockade && Knight5.blockade)
      if(ButtonMovement.blockade)
        {
          //  FindObjectOfType<Knight1>().ColliderOn();
          //  FindObjectOfType<Knight2>().ColliderOn();
         //   FindObjectOfType<Knight3>().ColliderOn();
        }
        else
        {
          //  FindObjectOfType<Knight1>().ColliderOff();
         //   FindObjectOfType<Knight2>().ColliderOff();
          //  FindObjectOfType<Knight3>().ColliderOff();
        }
    }

    public void Range(int id2, int column, int row)
    {
        start2 = "P" + row + column;
        for (int i = 0; i < 10; i++)
        {
            tablica[i] = "";
        }
        id = id2;
        columnTemporary = column;
        rowTemporary = row;
        start = true;

        klasaZDictionary = FindObjectOfType<DictionaryC>();
        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();

        pomcol = column;
        pomrow = row;
        pomrow2 = row;
        pomcol2 = column;
        int k = 2;

        for (int i = -1 - k; i < 2 + k; i++)
        {
            pomrow = row;
            pomrow = pomrow + i;
            pomcol = column;

            for (int j = -1; j < 2; j++)
            {
                if (i - k == -5 || i - k == 1)
                {
                    if (j == -1 || j == 1)
                    {
                        test = "P" + pomrow + 16;
                    }
                    else
                    {
                        test = "P" + pomrow + pomcol;
                    }
                }
                else
                {
                    pomcol = column + j;
                    test = "P" + pomrow + pomcol;

                }
                pomrow2 = pomrow;
                pomcol2 = pomcol;




                //pole dolne skrajne
                if (i - k == -5 && j == 0)
                {
                    pomrow2 = pomrow2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }




                    }
                    pomrow2 = pomrow;

                    pomrow2 = pomrow2 + 2;

                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }
                    }
                }

                if (i - k == -4 && j == 0)
                {
                    pomrow2 = pomrow2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }
                    }
                }
                if (i - k == -3 && j == -1)
                {

                    pomrow2 = pomrow2 + 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2++;
                        }
                    }
                    pomrow2 = pomrow;
                    pomcol2 = pomcol2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;


                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2++;
                        }
                    }

                    pomcol2 = pomcol;
                    if (blokada2 == 2)
                    {
                        blokada = false;
                    }
                    blokada2 = 0;
                }

                //pole górne prawo ni¿ej
                if (i - k == -3 && j == 1)
                {

                    pomrow2 = pomrow2 + 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2++;
                        }
                    }

                    pomrow2 = pomrow;
                    pomcol2 = pomcol2 - 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2++;
                        }
                    }
                    pomcol2 = pomcol;
                    if (blokada2 == 2)
                    {
                        blokada = false;
                    }
                    blokada2 = 0;
                }

                // górne skrajne pole
                if (i - k == 1 && j == 0)
                {
                    pomrow2 = pomrow2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }

                    }
                    pomrow2 = pomrow;
                    pomrow2 = pomrow2 - 2;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;
                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }

                    }
                }
                // górne pole przed skrajnym

                if (i - k == 0 && j == 0)
                {
                    pomrow2 = pomrow2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;
                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }

                    }

                }
                //pole  górne lewo ni¿ej
                if (i - k == -1 && j == -1)
                {

                    pomrow2 = pomrow2 - 1;
                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2++;
                        }




                    }
                    pomrow2 = pomrow;

                    pomcol2 = pomcol2 + 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2++;
                        }




                    }
                    pomcol2 = pomcol;
                    if (blokada2 == 2)
                    {
                        blokada = false;

                    }
                    blokada2 = 0;
                }

                //pole górne prawo ni¿ej
                if (i - k == -1 && j == 1)
                {
                    pomrow2 = pomrow2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2++;
                        }

                    }
                    pomrow2 = pomrow;
                    pomcol2 = pomcol2 - 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2++;
                        }




                    }
                    pomcol2 = pomcol;
                    if (blokada2 == 2)
                    {
                        blokada = false;
                    }
                    blokada2 = 0;
                }
                //pole górne lewo wy¿ej
                if (i - k == 0 && j == -1)
                {
                    pomrow2 = pomrow2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            //  blokada = false;
                            blokada3 = 1;
                        }




                    }
                    pomrow2 = pomrow;
                    pomrow2 = pomrow2 - 2;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2 = 3;
                        }

                    }
                    pomrow2 = pomrow;
                    pomcol2 = pomcol2 + 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada3 == 1 )
                                blokada2 = 2;


                        }

                    }
                    pomrow2 = pomrow2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    pomrow2 = pomrow;
                    pomcol2 = pomcol;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if ( blokada3 == 1 || blokada2==3 )
                                blokada2 = 2;
                        }
                    }
                    if (blokada2 == 2)
                    {
                        blokada = false;

                    }
                    blokada2 = 0;
                    blokada3 = 0;

                }




                if (i - k == 0 && j == 1)
                {
                    pomrow2 = pomrow2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada3 = 1;
                        }

                    }
                    pomrow2 = pomrow;
                    pomrow2 = pomrow2 - 2;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2 = 3;

                        }

                    }
                    pomrow2 = pomrow;
                    pomcol2 = pomcol2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada3 == 1 )
                                blokada2 = 2;
                        }
                    }
                    pomrow2 = pomrow2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    pomrow2 = pomrow;
                    pomcol2 = pomcol;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada2 == 3 || blokada3 == 1)
                                blokada2 = 2;


                        }

                    }
                    if (blokada2 == 2)
                    {
                        blokada = false; //?????????????????????????????????????????????????????????????????????????????????????????????????

                    }
                    blokada2 = 0;
                    blokada3 = 0;

                }
                //dolne lewe
                if (i - k == -4 && j == -1)
                {
                    pomrow2 = pomrow2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada3 = 1;
                        }

                    }
                    pomrow2 = pomrow;
                    pomrow2 = pomrow2 + 2;

                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2 = 3;
                        }
                    }
                    pomrow2 = pomrow;
                    pomcol2 = pomcol2 + 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada3 == 1 )
                                blokada2 = 2;
                        }

                    }
                    pomrow2 = pomrow2 + 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    pomrow2 = pomrow;
                    pomcol2 = pomcol;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada2 == 3 || blokada3 == 1)
                                blokada2 = 2;
                        }




                    }
                    if (blokada2 == 2)
                    {
                        blokada = false;

                    }
                    blokada2 = 0;
                    blokada3 = 0;

                }
                //dolne prawe
                if (i - k == -4 && j == 1)
                {
                    pomrow2 = pomrow2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada3 = 1;
                        }

                    }
                    pomrow2 = pomrow;
                    pomrow2 = pomrow2 + 2;

                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {

                            blokada2 = 3;

                        }
                    }
                    pomrow2 = pomrow;
                    pomcol2 = pomcol2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada3 == 1 )
                                blokada2 = 2;
                        }


                    }
                    pomrow2 = pomrow2 + 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    pomrow2 = pomrow;
                    pomcol2 = pomcol;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada2 == 3 || blokada3 == 1)
                                blokada2 = 2;
                        }

                    }
                    if (blokada2 == 2)
                    {
                        blokada = false;

                    }
                    blokada3 = 0;

                    blokada2 = 0;
                }
                if (dictionaryTypes.ContainsKey(test) && blokada == true)
                {

                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;

                
                    if (kolorObiekt.pole2 == false)
                    {
                        if (test != start2)
                        {

                            //  skip = test;
                            tablica[tablicaPozycja] = test;
                            tablicaPozycja++;
                        }
                    }
                    else
                    {
                        kolorObiekt.pole = true;
                        kolorObiekt.green = true;
                        kolorObiekt.Kolor();
                    }
                }
                blokada = true;
            }

        }

        for (int j = -1 - k; j < 2 + k; j++)
        {
            pomrow = row;
            pomcol = column;
            pomcol = pomcol + j;

            for (int i = -1; i < 2; i++)
            {

                if (j - k == -5 || j - k == 1 || j - k == -3 || j - k == -1 || j - k == -2)
                {
                    if (i == -1 || i == 1)
                    {
                        test = "P" + pomrow + 16;
                    }
                    else
                    {
                        test = "P" + pomrow + pomcol;
                    }
                }
                else
                {
                    pomrow = row + i;
                    test = "P" + pomrow + pomcol;

                }

                pomrow2 = pomrow;
                pomcol2 = pomcol;

                //pole lewe skrajne
                if (j - k == -5 && i == 0)
                {
                    pomcol2 = pomcol2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }

                    }

                    pomcol2 = pomcol;

                    pomcol2 = pomcol2 + 2;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }




                    }
                }
                //pole lewe przed skrajnym
                if (j - k == -4 && i == 0)
                {
                    pomcol2 = pomcol2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }

                    }

                }
                //pole lewe góra
                if (j - k == -4 && i == 1)
                {
                    pomcol2 = pomcol;
                    pomcol2 = pomcol2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada3 = 1;
                        }
                    }

                    pomcol2 = pomcol;
                    pomcol2 = pomcol2 + 2;
                    test2 = "P" + pomrow2 + pomcol2;
                    pomcol2 = pomcol;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2 = 3;
                        }




                    }
                    pomcol2 = pomcol;
                    pomrow2 = pomrow;
                    pomrow2 = pomrow2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada3 == 1 )
                                blokada2 = 2;
                        }

                    }

                    pomcol2 = pomcol2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada2 == 3 || blokada3 == 1)
                                blokada2 = 2;
                        }

                    }


                    if (blokada2 == 2)
                    {
                        blokada = false;

                    }
                    pomcol2 = pomcol;
                    pomrow2 = pomrow;
                    blokada2 = 0;
                    blokada3 = 0;

                }
                //pole lewe dó³
                if (j - k == -4 && i == -1)
                {
                    pomcol2 = pomcol;
                    pomcol2 = pomcol2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada3 = 1;

                        }

                    }

                    pomcol2 = pomcol;
                    pomcol2 = pomcol2 + 2;
                    test2 = "P" + pomrow2 + pomcol2;
                    pomcol2 = pomcol;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2 = 3;
                        }
                    }
                    pomcol2 = pomcol;
                    pomrow2 = pomrow;
                    pomrow2 = pomrow2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada3 == 1)
                                blokada2 = 2;
                        }
                    }

                    pomcol2 = pomcol2 + 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada2 == 3 || blokada3 == 1)
                                blokada2 = 2;
                        }

                    }


                    if (blokada2 == 2)
                    {
                        blokada = false;
                    }
                    pomcol2 = pomcol;
                    pomrow2 = pomrow;
                    blokada2 = 0;
                    blokada3 = 0;

                }
                //pole prawe dó³
                if (j - k == 0 && i == -1)
                {
                    pomcol2 = pomcol;
                    pomcol2 = pomcol2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada3 = 1;

                        }

                    }

                    pomcol2 = pomcol;
                    pomcol2 = pomcol2 - 2;
                    test2 = "P" + pomrow2 + pomcol2;
                    pomcol2 = pomcol;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2 = 3;
                        }

                    }
                    pomcol2 = pomcol;
                    pomrow2 = pomrow;
                    pomrow2 = pomrow2 + 1;

                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada3 == 1 )
                                blokada2 = 2;
                        }




                    }


                    pomcol2 = pomcol2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {

                            if (blokada2 == 3 || blokada3 == 1)
                                blokada2 = 2;
                        }

                    }

                    if (blokada2 == 2)
                    {
                        blokada = false;

                    }
                    pomcol2 = pomcol;
                    pomrow2 = pomrow;
                    blokada3 = 0;

                    blokada2 = 0;
                }
                //pole prawe góra
                if (j - k == 0 && i == 1)
                {
                    pomcol2 = pomcol;
                    pomcol2 = pomcol2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada3 = 1;

                        }

                    }
                    pomcol2 = pomcol;
                    pomcol2 = pomcol2 - 2;
                    test2 = "P" + pomrow2 + pomcol2;
                    pomcol2 = pomcol;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada2 = 3;
                        }

                    }
                    pomcol2 = pomcol;
                    pomrow2 = pomrow;
                    pomrow2 = pomrow2 - 1;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada3 == 1)
                                blokada2 = 2;
                        }
                    }

                    pomcol2 = pomcol2 - 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            if (blokada2 == 3 || blokada3 == 1)
                                blokada2 = 2;
                        }

                    }

                    if (blokada2 == 2)
                    {
                        blokada = false;

                    }
                    pomcol2 = pomcol;
                    pomrow2 = pomrow;
                    blokada2 = 0;
                    blokada3 = 0;

                }
                //pole prawe 
                if (j - k == 1 && i == 0)
                {
                    pomcol2 = pomcol2 - 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }

                    }
                    pomcol2 = pomcol;
                    pomcol2 = pomcol2 - 2;

                    test2 = "P" + pomrow2 + pomcol2;
                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }




                    }
                }
                //pole prawe przed skrajnym
                if (j - k == 0 && i == 0)
                {
                    pomcol2 = pomcol2 - 1;
                    test2 = "P" + pomrow2 + pomcol2;

                    if (dictionaryTypes.ContainsKey(test2))
                    {
                        Type typ = dictionaryTypes[test2];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;

                        if (kolorObiekt.pole2 == false)
                        {
                            blokada = false;
                        }

                    }

                }
                if (dictionaryTypes.ContainsKey(test) && blokada == true)
                {

                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;

               
                    if (kolorObiekt.pole2 == false)
                    {
                        if (test != start2)
                        {

                            tablica[tablicaPozycja] = test;
                            tablicaPozycja++;
                        }
                    }
                    else
                    {
                        kolorObiekt.pole = true;
                        kolorObiekt.green = true;
                        kolorObiekt.Kolor();
                    }
                }
                blokada = true;
            }

        }
        tablicaPozycja = 0;
        for (int i = 0; i < 10; i++)
        {
           // Debug.Log(tablica[i]);
        }
    }

    public void Move(int columnStart, int rowStart, bool enemy)
    {
        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();

        int k = 5;
        for (int i = -1 - k; i < 4 + k; i++)
        {
            pomrow = rowTemporary;
            pomrow = pomrow + i;
            for (int j = -1 - k; j < 1 + k; j++)
            {
                pomcol = columnTemporary;
                pomcol = pomcol + j;
                test = "P" + pomrow + pomcol;
                if (dictionaryTypes.ContainsKey(test))
                {
                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;
                    kolorObiekt.green = false;
                    kolorObiekt.Kolor();
                }
            }

        }

        bool lewo = true;
        int r;
        int c;
        for (int i = 0; i < 15; i++)
        {
            a++;
            if (columnTemporary - columnStart == 2 && rowTemporary - rowStart == 1 && i == 0)
            {
                r = rowTemporary - 1;
                c = columnTemporary - 1;
                currentPosition = "P" + r + c;
                if (tablica[0] == currentPosition || tablica[1] == currentPosition
                || tablica[2] == currentPosition || tablica[3] == currentPosition || tablica[4] == currentPosition
                || tablica[5] == currentPosition)
                {
                    lewo = false;
                }

            }
            if (columnTemporary - columnStart == 2 && rowTemporary - rowStart == -1 && i == 0)
            {
                r = rowTemporary + 1;
                c = columnTemporary - 1;
                currentPosition = "P" + r + c;
                if (tablica[0] == currentPosition || tablica[1] == currentPosition
                || tablica[2] == currentPosition || tablica[3] == currentPosition || tablica[4] == currentPosition
                || tablica[5] == currentPosition)
                {
                    lewo = false;

                }

            }
            if (columnTemporary - columnStart == -2 && rowTemporary - rowStart == 1 && i == 0)
            {
                r = rowTemporary - 1;
                c = columnTemporary + 1;
                currentPosition = "P" + r + c;
                if (tablica[0] == currentPosition || tablica[1] == currentPosition
                     || tablica[2] == currentPosition || tablica[3] == currentPosition || tablica[4] == currentPosition
                     || tablica[5] == currentPosition)
                {
                    lewo = false;

                }
            }

            if (columnTemporary - columnStart == -2 && rowTemporary - rowStart == -1 && i == 0)
            {
                r = rowTemporary + 1;
                c = columnTemporary + 1;
                currentPosition = "P" + r + c;
                if (tablica[0] == currentPosition || tablica[1] == currentPosition
                  || tablica[2] == currentPosition || tablica[3] == currentPosition || tablica[4] == currentPosition
                  || tablica[5] == currentPosition)
                {
                    lewo = false;

                }

            }
          //  Debug.Log(lewo + " lewwwwww");
            if (lewo)
            {
                if (rowTemporary > rowStart)
                {
                    rowTemporary--;
                    currentPosition = "P" + rowTemporary + columnTemporary;
                    if (tablica[0] != currentPosition && tablica[1] != currentPosition
                                          && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                                            && tablica[5] != currentPosition)
                    {
                        a = 0;

                        rycerz2 = rycerz2 + 2;
                        howManyMoves++;
                    }
                    else
                    {

                        rowTemporary++;
                        currentPosition = "P" + rowTemporary + columnTemporary;
                    }

                }

                if (rowTemporary < rowStart)
                {
                    rowTemporary++;
                    currentPosition = "P" + rowTemporary + columnTemporary;

                    if (tablica[0] != currentPosition && tablica[1] != currentPosition
                                          && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                                          && tablica[5] != currentPosition)
                    {
                        a = 0;
                        rycerz2 = rycerz2 + 3;
                        howManyMoves++;
                    }
                    else
                    {
                        rowTemporary--;
                        currentPosition = "P" + rowTemporary + columnTemporary;

                    }

                }
            }

            if (columnTemporary > columnStart)
            {


                columnTemporary--;
                currentPosition = "P" + rowTemporary + columnTemporary;



                if (tablica[0] != currentPosition && tablica[1] != currentPosition
                                      && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                                        && tablica[5] != currentPosition)
                {
                    a = 0;
                    rycerz2 = rycerz2 + 4;
                    howManyMoves++;
                }
                else
                {

                    columnTemporary++;
                    currentPosition = "P" + rowTemporary + columnTemporary;
                }

            }

            if (columnTemporary < columnStart)
            {
                columnTemporary++;
                currentPosition = "P" + rowTemporary + columnTemporary;



                if (tablica[0] != currentPosition && tablica[1] != currentPosition
                                      && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                                        && tablica[5] != currentPosition)
                {
                    a = 0;
                    rycerz2 = rycerz2 + 1;
                    howManyMoves++;
                }
                else
                {

                    columnTemporary--;
                    currentPosition = "P" + rowTemporary + columnTemporary;
                }
            }

            lewo = true;



            if (a != 0)
            {
                b = 1;
                rowTemporary++;
                currentPosition = "P" + rowTemporary + columnTemporary;
                if (tablica[0] != currentPosition && tablica[1] != currentPosition
                && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                && rowTemporary < rowStart)
                {
                    a = 0;
                    rycerz2 = rycerz2 + 3;
                    howManyMoves++;
                }
                else
                {
                    rowTemporary--;
                    columnTemporary++;
                    currentPosition = "P" + rowTemporary + columnTemporary;
                    if (tablica[0] != currentPosition && tablica[1] != currentPosition
                                   && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                                 )
                    {
                        a = 0;

                        rycerz2 = rycerz2 + 1;
                        howManyMoves++;
                    }
                    else
                    {


                        columnTemporary--;
                        rowTemporary--;
                        currentPosition = "P" + rowTemporary + columnTemporary;
                        if (tablica[0] != currentPosition && tablica[1] != currentPosition
                               && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition)
                        {
                            a = 0;

                            rycerz2 = rycerz2 + 2;
                            howManyMoves++;
                        }
                        else
                        {
                            rowTemporary++;
                            columnTemporary--;
                            currentPosition = "P" + rowTemporary + columnTemporary;
                            if (tablica[0] != currentPosition && tablica[1] != currentPosition
                           && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition)
                            {
                                a = 0;

                                rycerz2 = rycerz2 + 4;
                                howManyMoves++;
                            }
                        }
                    }

                }


            }

            if (rowTemporary == rowStart && columnTemporary == columnStart)
            {
                i = 15;
            }
        }
        a = 0;
        if (id == 0)
        {
            Serf1.howManyMoves = howManyMoves;
            howManyMoves = 0;
            Serf1.column = columnTemporary;
            Serf1.row = rowTemporary;

            Serf1.tablica = rycerz2;
            rycerz2 = "";
            serf1 = FindObjectOfType<Serf1>();
            StartCoroutine(serf1.Movement());

        }
        if (id == 1)
        {
            Knight1.howManyMoves = howManyMoves;
            howManyMoves = 0;
            Knight1.column = columnTemporary;
            Knight1.row = rowTemporary;

            Knight1.tablica = rycerz2;
            rycerz2 = "";
            ruch = FindObjectOfType<Knight1>();
            StartCoroutine(ruch.Movement());

        }
        if (id == 2)
        {
            Knight2.howManyMoves = howManyMoves;
            howManyMoves = 0;
            Knight2.column = columnTemporary;
            Knight2.row = rowTemporary;

            Knight2.tablica = rycerz2;
            rycerz2 = "";
            knight2 = FindObjectOfType<Knight2>();
            StartCoroutine(knight2.Movement());

        }
        if (id == 3)
        {
            Knight3.howManyMoves = howManyMoves;
            howManyMoves = 0;
            Knight3.column = columnTemporary;
            Knight3.row = rowTemporary;

            Knight3.tablica = rycerz2;
            rycerz2 = "";
            knight3 = FindObjectOfType<Knight3>();
            StartCoroutine(knight3.Movement());

        }
        if (id == 4)
        {
            Serf2.howManyMoves = howManyMoves;
            howManyMoves = 0;
            Serf2.column = columnTemporary;
            Serf2.row = rowTemporary;

            Serf2.tablica = rycerz2;
            rycerz2 = "";
            serf2 = FindObjectOfType<Serf2>();
            StartCoroutine(serf2.Movement());

        }


        howManyMoves = 0;




        row2 = rowTemporary;
        column2 = columnTemporary;
    }

}

