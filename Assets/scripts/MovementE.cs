using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography;
using UnityEngine;

public class MovementE : MonoBehaviour
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
    private Enemy1 enemy1;
    private Knight4 knight4;
    private Knight5 knight5;
    private ESerf1 eserf1;
    private ESerf2 eserf2;
    int trzy2 = 0;
    int id;
    int columnTemporary;
    int rowTemporary;
    string rycerz2;
    int k = 3;
    string currentPosition;
    string currentPosition2;
    string[] tablica = new string[25];  //6
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
    string skip;
    int trzy = 0;
    int a1 = 0;
    int a2 = 0;
    int a3 = 0;
    int a4 = 0;

    void Update()
    {
      //  if (Knight1.blockade && Knight2.blockade && Knight3.blockade && Knight4.blockade && Knight5.blockade)
      if(ButtonMovement.blockade)
        {
          //  FindObjectOfType<Knight1>().ColliderOn();
        //    FindObjectOfType<Knight2>().ColliderOn();
          //  FindObjectOfType<Knight3>().ColliderOn();
        }
        else
        {
           // FindObjectOfType<Knight1>().ColliderOff();
           // FindObjectOfType<Knight2>().ColliderOff();
           // FindObjectOfType<Knight3>().ColliderOff();
        }
    }

    public void Range(int id2, int column, int row)
    {
        for(int i = 0; i <= 20; i++)
        {
            tablica[i] = " ";
        }
        id = id2;
        columnTemporary = column;
        rowTemporary = row;
        start = true;

        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();

        pomcol = column;
        pomrow = row;
        int k = 0;
        int kk = 0;
        //   for (int k = 0; k < 3; k++)
        //   {
        for (int i = -3; i < 4 ; i++)
        {
            pomrow = row;
            pomrow = pomrow + i;
            for (int j = k; j < 1 + kk; j++)
            {
              
                pomcol = column;
                pomcol = pomcol + j;
                test = "P" + pomrow + pomcol;
                if (dictionaryTypes.ContainsKey(test))
                {
                  //  Debug.Log(test + " ?");
                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;

                    
                    if (kolorObiekt.pole2 == false)
                    {
                        tablica[tablicaPozycja] = test;
                        tablicaPozycja++;
                     //   Debug.Log(test + "  testt?????!");
                   

                    }

                }


            }
            if (i < 1)
            {
                k--;
                kk++;

            }
            else
            {
                k++;
                kk--;
            }
            

        }
        for (int i = 0; i <= 20; i++)
        {
         //  Debug.Log(tablica[i] +  "  no coooo") ;
        }
        tablicaPozycja = 0;
        //   }
    }

    public void Move( int column , int row,  int columnStart, int rowStart, int id)
    {
        trzy = 0;
    //    int id2 = id;
        Range(id, column, row);
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
                 //   kolorObiekt.Kolor();
                }
            }

        }

        bool lewo = true;
        int r;
        int c;
        for (int i = 0; i < 15; i++)
        {
            trzy2++;
            a++;

            if (columnTemporary - columnStart == 2 && rowTemporary - rowStart == 1 && i == 0)
            {
                r = rowTemporary - 1;
                c = columnTemporary - 1;
                currentPosition = "P" + r + c;
                if (tablica[0] == currentPosition || tablica[1] == currentPosition
                || tablica[2] == currentPosition || tablica[3] == currentPosition || tablica[4] == currentPosition
                || tablica[5] == currentPosition || tablica[6] == currentPosition || tablica[7] == currentPosition
                || tablica[8] == currentPosition || tablica[9] == currentPosition ||
                tablica[10] == currentPosition || tablica[11] == currentPosition
                || tablica[12] == currentPosition || tablica[13] == currentPosition || tablica[14] == currentPosition
                || tablica[15] == currentPosition || tablica[16] == currentPosition || tablica[17] == currentPosition
                || tablica[18] == currentPosition || tablica[19] == currentPosition ||
                tablica[20] == currentPosition || tablica[21] == currentPosition)
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
               || tablica[5] == currentPosition || tablica[6] == currentPosition || tablica[7] == currentPosition
               || tablica[8] == currentPosition || tablica[9] == currentPosition ||
                tablica[10] == currentPosition || tablica[11] == currentPosition
                || tablica[12] == currentPosition || tablica[13] == currentPosition || tablica[14] == currentPosition
                || tablica[15] == currentPosition || tablica[16] == currentPosition || tablica[17] == currentPosition
                || tablica[18] == currentPosition || tablica[19] == currentPosition ||
                tablica[20] == currentPosition || tablica[21] == currentPosition)
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
                 || tablica[5] == currentPosition || tablica[6] == currentPosition || tablica[7] == currentPosition
                 || tablica[8] == currentPosition || tablica[9] == currentPosition ||
                tablica[10] == currentPosition || tablica[11] == currentPosition
                || tablica[12] == currentPosition || tablica[13] == currentPosition || tablica[14] == currentPosition
                || tablica[15] == currentPosition || tablica[16] == currentPosition || tablica[17] == currentPosition
                || tablica[18] == currentPosition || tablica[19] == currentPosition ||
                tablica[20] == currentPosition || tablica[21] == currentPosition)
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
                   || tablica[5] == currentPosition || tablica[6] == currentPosition || tablica[7] == currentPosition
                   || tablica[8] == currentPosition || tablica[9] == currentPosition ||
                tablica[10] == currentPosition || tablica[11] == currentPosition
                || tablica[12] == currentPosition || tablica[13] == currentPosition || tablica[14] == currentPosition
                || tablica[15] == currentPosition || tablica[16] == currentPosition || tablica[17] == currentPosition
                || tablica[18] == currentPosition || tablica[19] == currentPosition ||
                tablica[20] == currentPosition || tablica[21] == currentPosition)
                {
                    lewo = false;

                }

            }
          //  Debug.Log(lewo  + " ????lewp");
            if (lewo && trzy != 3)
            {
             //   Debug.Log(rowTemporary+ " ! " + rowStart+ "   ?   " + i);

                if (rowTemporary > rowStart && trzy !=3)
                {
                    rowTemporary--;
                    currentPosition = "P" + rowTemporary + columnTemporary;
                    if (tablica[0] != currentPosition && tablica[1] != currentPosition
                         && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                         && tablica[5] != currentPosition
               && tablica[6] != currentPosition && tablica[7] != currentPosition && tablica[8] != currentPosition
               && tablica[9] != currentPosition && tablica[10] != currentPosition && tablica[11] != currentPosition
                         && tablica[12] != currentPosition && tablica[13] != currentPosition && 
                         tablica[14] != currentPosition   && tablica[15] != currentPosition
               && tablica[16] != currentPosition && tablica[17] != currentPosition && tablica[18] != currentPosition
               && tablica[19] != currentPosition && tablica[20] != currentPosition  && tablica[21] != currentPosition
               &&rowTemporary !=-1 && rowTemporary!=10  && a1!=4)   // zmiana
                    {
                        a1 = 3;  //to
                        a = 0;


                        rycerz2 = rycerz2 + 2;
                        howManyMoves++;
                        trzy++;

                    }
                    else
                    {
                        rowTemporary++;
                        currentPosition = "P" + rowTemporary + columnTemporary;
                    }

                }
                if (rowTemporary == rowStart && columnTemporary == columnStart)
                {
                    trzy = 3;
                    //     trzy2 = 0;
                }
                if (rowTemporary < rowStart && trzy != 3)
                {
                    rowTemporary++;
                    currentPosition = "P" + rowTemporary + columnTemporary;

                    if (tablica[0] != currentPosition && tablica[1] != currentPosition
                          && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                          && tablica[5] != currentPosition
                && tablica[6] != currentPosition && tablica[7] != currentPosition && tablica[8] != currentPosition
                && tablica[9] != currentPosition && tablica[10] != currentPosition && tablica[11] != currentPosition
                          && tablica[12] != currentPosition && tablica[13] != currentPosition &&
                          tablica[14] != currentPosition && tablica[15] != currentPosition
                && tablica[16] != currentPosition && tablica[17] != currentPosition && tablica[18] != currentPosition
                && tablica[19] != currentPosition && tablica[20] != currentPosition && tablica[21] != currentPosition
                 && rowTemporary != -1 && rowTemporary != 10 && a1 != 3)
                    {
                        a1 = 4;  // to
                        a = 0;
                        rycerz2 = rycerz2 + 3;
                        howManyMoves++;
                        trzy++;

                    }
                    else
                    {
                        rowTemporary--;
                        currentPosition = "P" + rowTemporary + columnTemporary;

                    }

                }
            }
            if (rowTemporary == rowStart && columnTemporary == columnStart)
            {
                trzy = 3;
                //     trzy2 = 0;
            }
            if (columnTemporary > columnStart && trzy != 3)
            {

                //   Debug.Log("tutaj heh 2 " + i);
                columnTemporary--;
                currentPosition = "P" + rowTemporary + columnTemporary;




                if (tablica[0] != currentPosition && tablica[1] != currentPosition
                        && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                        && tablica[5] != currentPosition
              && tablica[6] != currentPosition && tablica[7] != currentPosition && tablica[8] != currentPosition
              && tablica[9] != currentPosition && tablica[10] != currentPosition && tablica[11] != currentPosition
                        && tablica[12] != currentPosition && tablica[13] != currentPosition &&
                        tablica[14] != currentPosition && tablica[15] != currentPosition
              && tablica[16] != currentPosition && tablica[17] != currentPosition && tablica[18] != currentPosition
              && tablica[19] != currentPosition && tablica[20] != currentPosition && tablica[21] != currentPosition
              && a1!= 1 && columnTemporary != -1 && columnTemporary != 10)
                {

                    a1 = 2;
                    a = 0;
                    rycerz2 = rycerz2 + 4;
                    howManyMoves++;
                    trzy++;

                }
                else
                {

                    columnTemporary++;
                    currentPosition = "P" + rowTemporary + columnTemporary;
                }

            }
            if (rowTemporary == rowStart && columnTemporary == columnStart)
            {
                trzy = 3;
                //     trzy2 = 0;
            }
            if (columnTemporary < columnStart && trzy != 3)
            {
                columnTemporary++;
                currentPosition = "P" + rowTemporary + columnTemporary;


                if (tablica[0] != currentPosition && tablica[1] != currentPosition
                           && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                           && tablica[5] != currentPosition
                 && tablica[6] != currentPosition && tablica[7] != currentPosition && tablica[8] != currentPosition
                 && tablica[9] != currentPosition && tablica[10] != currentPosition && tablica[11] != currentPosition
                           && tablica[12] != currentPosition && tablica[13] != currentPosition &&
                           tablica[14] != currentPosition && tablica[15] != currentPosition
                 && tablica[16] != currentPosition && tablica[17] != currentPosition && tablica[18] != currentPosition
                 && tablica[19] != currentPosition && tablica[20] != currentPosition && tablica[21] != currentPosition
                 && a1 != 2 && columnTemporary != -1 && columnTemporary != 10)
                {
                    a1 = 1;
                    a = 0;
                    rycerz2 = rycerz2 + 1;
                    howManyMoves++;
                    trzy++;
                }
                else
                {

                    columnTemporary--;
                    currentPosition = "P" + rowTemporary + columnTemporary;
                }
            }

            lewo = true;

            if (rowTemporary == rowStart && columnTemporary == columnStart)
            {
                trzy = 3;
                //     trzy2 = 0;
            }

            if (a != 0 && trzy != 3)
            {
                b = 1;
                rowTemporary++;
                currentPosition = "P" + rowTemporary + columnTemporary;
                if (tablica[0] != currentPosition && tablica[1] != currentPosition
                              && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                              && tablica[5] != currentPosition
                    && tablica[6] != currentPosition && tablica[7] != currentPosition && tablica[8] != currentPosition
                    && tablica[9] != currentPosition && tablica[10] != currentPosition && tablica[11] != currentPosition
                              && tablica[12] != currentPosition && tablica[13] != currentPosition &&
                              tablica[14] != currentPosition && tablica[15] != currentPosition
                    && tablica[16] != currentPosition && tablica[17] != currentPosition && tablica[18] != currentPosition
                    && tablica[19] != currentPosition && tablica[20] != currentPosition && tablica[21] != currentPosition
                     && rowTemporary < rowStart && trzy != 3  && rowTemporary != -1 && rowTemporary != 10 && a1 != 3)
                {

                    a1 = 4;
                    a = 0;
                    rycerz2 = rycerz2 + 3;
                    howManyMoves++;
                    trzy++;

                }
                else
                {
                    if (rowTemporary == rowStart && columnTemporary == columnStart)
                    {
                        trzy = 3;
                        //     trzy2 = 0;
                    }
                    rowTemporary--;
                    columnTemporary++;
                    currentPosition = "P" + rowTemporary + columnTemporary;
                    if (tablica[0] != currentPosition && tablica[1] != currentPosition
                              && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                              && tablica[5] != currentPosition
                    && tablica[6] != currentPosition && tablica[7] != currentPosition && tablica[8] != currentPosition
                    && tablica[9] != currentPosition && tablica[10] != currentPosition && tablica[11] != currentPosition
                              && tablica[12] != currentPosition && tablica[13] != currentPosition &&
                              tablica[14] != currentPosition && tablica[15] != currentPosition
                    && tablica[16] != currentPosition && tablica[17] != currentPosition && tablica[18] != currentPosition
                    && tablica[19] != currentPosition && tablica[20] != currentPosition && tablica[21] != currentPosition
                                   && trzy != 3 && a1!=2  && columnTemporary != -1 && columnTemporary != 10)
                    {
                        a = 0;
                        a1 = 1;
                        rycerz2 = rycerz2 + 1;
                        howManyMoves++;
                        trzy++;

                    }
                    else
                    {

                        if (rowTemporary == rowStart && columnTemporary == columnStart)
                        {
                            trzy = 3;
                            //     trzy2 = 0;
                        }
                        columnTemporary--;
                        rowTemporary--;
                        currentPosition = "P" + rowTemporary + columnTemporary;
                 if (tablica[0] != currentPosition && tablica[1] != currentPosition
                         && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                         && tablica[5] != currentPosition
               && tablica[6] != currentPosition && tablica[7] != currentPosition && tablica[8] != currentPosition
               && tablica[9] != currentPosition && tablica[10] != currentPosition && tablica[11] != currentPosition
                         && tablica[12] != currentPosition && tablica[13] != currentPosition && 
                         tablica[14] != currentPosition   && tablica[15] != currentPosition
               && tablica[16] != currentPosition && tablica[17] != currentPosition && tablica[18] != currentPosition
               && tablica[19] != currentPosition && tablica[20] != currentPosition  && tablica[21] != currentPosition
               && trzy != 3 && rowTemporary != -1 && rowTemporary != 10 && a1 != 4)
                        {
                            a1 = 3;
                            a = 0;
                            rycerz2 = rycerz2 + 2;
                            howManyMoves++;
                            trzy++;

                        }
                        else
                        {
                            if (rowTemporary == rowStart && columnTemporary == columnStart)
                            {
                                trzy = 3;
                                //     trzy2 = 0;
                            }
                            rowTemporary++;
                            columnTemporary--;
                            currentPosition = "P" + rowTemporary + columnTemporary;
                            if (tablica[0] != currentPosition && tablica[1] != currentPosition
                               && tablica[2] != currentPosition && tablica[3] != currentPosition && tablica[4] != currentPosition
                               && tablica[5] != currentPosition
                     && tablica[6] != currentPosition && tablica[7] != currentPosition && tablica[8] != currentPosition
                     && tablica[9] != currentPosition && tablica[10] != currentPosition && tablica[11] != currentPosition
                               && tablica[12] != currentPosition && tablica[13] != currentPosition &&
                               tablica[14] != currentPosition && tablica[15] != currentPosition
                     && tablica[16] != currentPosition && tablica[17] != currentPosition && tablica[18] != currentPosition
                     && tablica[19] != currentPosition && tablica[20] != currentPosition
                     && tablica[21] != currentPosition && trzy != 3 && a1!=1 && columnTemporary != -1
                     && columnTemporary != 10)
                            {
                                a = 0;
                                a1 = 2;
                                rycerz2 = rycerz2 + 4;
                                howManyMoves++;
                                trzy++;

                            }
                            else
                            {
                                columnTemporary++;
                                currentPosition = "P" + rowTemporary + columnTemporary;//????????????????

                            }
                        }
                    }

                }


            }
            if (rowTemporary == rowStart && columnTemporary == columnStart )
            {
                i = 15;
            }
            if (trzy2==3)
            {
             //   i = 15;
              //  trzy2 = 0;

            }
        }
        a = 0;

        if (id == 6)
        {

            Enemy1.howManyMoves = howManyMoves;
            howManyMoves = 0;
            Enemy1.column = columnTemporary;
            Enemy1.row = rowTemporary;

            Enemy1.tablica = rycerz2;
            rycerz2 = "";
            enemy1 = FindObjectOfType<Enemy1>();
            StartCoroutine(enemy1.Movement());

        }
        else if (id == 7)
        {

            Knight4.howManyMoves = howManyMoves;
            howManyMoves = 0;
            Knight4.column = columnTemporary;
            Knight4.row = rowTemporary;

            Knight4.tablica = rycerz2;
            rycerz2 = "";
            knight4 = FindObjectOfType<Knight4>();
            StartCoroutine(knight4.Movement());

        }
        else if (id == 8)
        {

            Knight5.howManyMoves = howManyMoves;
            howManyMoves = 0;
            Knight5.column = columnTemporary;
            Knight5.row = rowTemporary;

            Knight5.tablica = rycerz2;
            rycerz2 = "";
            knight5 = FindObjectOfType<Knight5>();
            StartCoroutine(knight5.Movement());

        }
        else if (id == 5)
        {

            ESerf1.howManyMoves = howManyMoves;
            howManyMoves = 0;
            ESerf1.column = columnTemporary;
            ESerf1.row = rowTemporary;

            ESerf1.tablica = rycerz2;
            rycerz2 = "";
            eserf1 = FindObjectOfType<ESerf1>();
            StartCoroutine(eserf1.Movement());

        }
        else if (id == 9)
        {
            //   Debug.Log("????????????????????????????????");

            ESerf2.howManyMoves = howManyMoves;
            howManyMoves = 0;
            ESerf2.column = columnTemporary;
            ESerf2.row = rowTemporary;

            ESerf2.tablica = rycerz2;
            rycerz2 = "";
            eserf2 = FindObjectOfType<ESerf2>();
            StartCoroutine(eserf2.Movement());

        }
        a1 = 0;

        howManyMoves = 0;




        row2 = rowTemporary;
        column2 = columnTemporary;
    }

}

