using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Controller : MonoBehaviour
{
    private DictionaryC klasaZDictionary;
    int pomcol;
    int pomrow;
    int k = 0;
    string test;
    public static int random;
    public static bool blockade = true;
    int row;
    int col;
    int kolumnaPola;
    int wierszPola;
    int rotation = 0;
    public static string pole;
    int a = 0;
    bool end = false;
   public static bool arrow = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void PositionUlt(int kolumna, int wiersz)
    {
        kolumnaPola = kolumna;
        wierszPola = wiersz;
        PositionUlt();
    }
    public void PositionUlt()
    {
     
         if (pomrow > wierszPola)
        {
            rotation = 2;

        }
        else if (pomrow < wierszPola)
        {
            rotation = 3;

        }
        else if (pomcol > kolumnaPola)
        {
            rotation = 4;
        }
        else if (pomcol < kolumnaPola)
        {
            rotation = 1;

        }
        Knight1.rotation = rotation;
        Knight2.rotation = rotation;
        Knight3.rotation = rotation;
        Serf1.rotation = rotation;
        Serf2.rotation = rotation;
        Enemy1.rotation = rotation;
        Knight4.rotation = rotation;
        Knight5.rotation = rotation;
        ESerf1.rotation = rotation;
        ESerf2.rotation = rotation;


    }
    public void Position(int kolumna, int wiersz)
    {
        kolumnaPola = kolumna; 
        wierszPola = wiersz;
        PositionAttack();
    }
    public void PositionAttack()
    {
        if(pomcol > kolumnaPola)
        {
            rotation = 4;
        }else if(pomcol < kolumnaPola)
            {
            rotation = 1;

        }
        else if (pomrow > wierszPola)
        {
            rotation = 2;

        }
        else if (pomrow < wierszPola)
        {
            rotation = 3;

        }
        Knight1.rotation = rotation;
        Knight2.rotation = rotation;
        Knight3.rotation = rotation;
        Serf1.rotation = rotation;
        Serf2.rotation = rotation;
        Enemy1.rotation = rotation;
        Knight4.rotation = rotation;
        Knight5.rotation = rotation;
        ESerf1.rotation = rotation;
        ESerf2.rotation = rotation;


    }
    public static bool ende = false;
    public void AllyRangeOfAttack(int column, int row, int dmg, int idGracza, int idCelu)
    {



        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
        for (int i = -1; i <= 1; i++)
        {
            pomrow = row + i;
            pomcol = column;
            test = "P" + pomrow + pomcol;

            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.pom == true)

                {
                 //   Debug.Log(kolorObiekt.id + "  id " + idCelu);
                    if (idCelu == kolorObiekt.id)
                    {
                        Invoke("EndOfTurn", 2f);
                        ende = true;
                        end = true;
                        kolorObiekt.ally = true;
                        kolorObiekt.dmg = dmg;
                        kolorObiekt.idGracza = idGracza;
                    }
             



                }
                //  kolorObiekt.green = true;

               // kolorObiekt.Kolor();

            }
            pomrow = row;
            pomcol = column + i;
            test = "P" + pomrow + pomcol;

            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.pom == true)

                {
              //      Debug.Log(kolorObiekt.id + "  id " + idCelu);

                    if (idCelu == kolorObiekt.id)
                    {
                        Invoke("EndOfTurn", 2f);
                        ende = true;

                        end = true;
                        kolorObiekt.ally = true;
                        kolorObiekt.dmg = dmg;
                        kolorObiekt.idGracza = idGracza;
                    }
             



                }
                //  kolorObiekt.green = true;

               // kolorObiekt.Kolor();

            }
            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
        }

        pomcol = column;
        pomrow = row;
        for (int i = -1; i <= 1; i++)
        {
            pomrow = row + i;
            pomcol = column;
            test = "P" + pomrow + pomcol;

            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.pom == true && end == false)

                {
                    Debug.Log("hmmmm + 1");
                    //   Debug.Log(kolorObiekt.id + "  id " + idCelu);
                    Invoke("EndOfTurn", 2f);
                    end = true;
                    ende = true;

                    kolorObiekt.ally = true;
                    kolorObiekt.dmg = dmg;
                    kolorObiekt.idGracza = idGracza;



                }


            }
            pomrow = row;
            pomcol = column + i;
            test = "P" + pomrow + pomcol;

            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.pom == true && end == false)

                {
                    Debug.Log("hmmmm + 2");

                    //    Debug.Log(kolorObiekt.id + "  id " + idCelu);

                    Invoke("EndOfTurn", 2f);
                    end = true;
                    ende = true;

                    kolorObiekt.ally = true;
                    kolorObiekt.dmg = dmg;
                    kolorObiekt.idGracza = idGracza;



                }

            }
        }
        if (end == false)
        {

            Invoke("EndOfTurn", 0.5f);

        }
        end = false;
        pomcol = column;
        pomrow = row;
    }

    void EndOfTurn()
    {
        FindObjectOfType<EndOfTurn>().Change();

    }
    public void StalkerRangeOfAttack(int column, int row, int dmg, int idGracza, int idCelu)
    {

        arrow = false;


        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
        for (int i = -4; i <= -1; i++)
        {
            pomrow = row + i;
            pomcol = column;
            test = "P" + pomrow + pomcol;

            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.pom == true)//ten if powinien siê chyba odpaliæ raz ¿eby enemy nie uderzy³ dwóch postaci

                {
                    Debug.Log("heheheheheopopopop");

                    //   Debug.Log(kolorObiekt.id + "  id " + idCelu);
                    arrow = true;
                    if (idCelu == kolorObiekt.id)
                    {
                        Invoke("EndOfTurn", 2f);
                        end = true;
                        kolorObiekt.ally = true;
                        kolorObiekt.dmg = dmg;
                        kolorObiekt.idGracza = idGracza;
                    }


                    // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                }
                //  kolorObiekt.green = true;

                // kolorObiekt.Kolor();

            }
          
        }

        pomcol = column;
        pomrow = row;
        for (int i = -4; i <= -1; i++)
        {
            pomrow = row + i;
            pomcol = column;
            test = "P" + pomrow + pomcol;

            if (dictionaryTypes.ContainsKey(test))
            {

                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.pom == true && end == false)

                {
                    Invoke("EndOfTurn", 2f);
                    Debug.Log("heheheheheopopopop");

                    //     Debug.Log(kolorObiekt.id + "  id " + idCelu);
                    arrow = true;
                    end = true;             //?????????????????????????????????????????
                    kolorObiekt.ally = true;
                    kolorObiekt.dmg = dmg;
                    kolorObiekt.idGracza = idGracza;



                }


            }
          
        }
        if (end == false)
        {
            Invoke("EndOfTurn", 0.5f);

        }
        end = false;
        pomcol = column;
        pomrow = row;
    }
    
    public void StalkerRangeOfAttack2(int column, int row, int dmg, int idGracza, int idCelu)
    {
        Debug.Log("heheheheheopopopop");
        Debug.Log(arrow + " arrow nnnn");

        arrow = false;


        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
  

       
        for (int i = -4; i <= 4; i++)
        {
            pomrow = row + i;
            pomcol = column;
            test = "P" + pomrow + pomcol;

            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.pom == true && end == false && i!=-4 && i != -3 && i != -2 && i != -1 && i != 0)

                {
                    end = true;
                    Invoke("EndOfTurn", 2f);

                    //        Debug.Log(kolorObiekt.id + "  id " + idCelu);
                    arrow = true;

                    kolorObiekt.ally = true;
                    kolorObiekt.dmg = dmg;
                    kolorObiekt.idGracza = idGracza;



                }


            }
            pomrow = row;
            pomcol = column + i;
            test = "P" + pomrow + pomcol;

            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.pom == true && end == false)

                {
                    Invoke("EndOfTurn", 2f);
                    end = true;
                    //      Debug.Log(kolorObiekt.id + "  id " + idCelu);
                    arrow = true;

                    kolorObiekt.ally = true;
                    kolorObiekt.dmg = dmg;
                    kolorObiekt.idGracza = idGracza;



                }

            }
        }

        Debug.Log(arrow + " arrow");
        end = false;
        pomcol = column;
        pomrow = row;
    }
  
         public void RangeOfUltStalker(int column, int row,  int idGracza)
    {

        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
        for (int i = -3; i <= 3; i++)
        {
            pomrow = row + i;
            pomcol = column;
            test = "P" + pomrow + pomcol;

            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.enemy == true)//ten if powinien siê chyba odpaliæ raz ¿eby enemy nie uderzy³ dwóch postaci

                {
                    //  Debug.Log(test);
                    kolorObiekt.ult = true;
                    kolorObiekt.idGracza = idGracza;

                    // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                }
               //   kolorObiekt.green = true;

             //   kolorObiekt.Kolor();

            }
            for(int j=-3; j<=3; j++)
            {
              //  pomrow = row;
                pomcol = column + j;
                test = "P" + pomrow + pomcol;

                if (dictionaryTypes.ContainsKey(test))
                {
                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;

                    if (kolorObiekt.enemy == true)
                    {
                        kolorObiekt.ult = true;
                        kolorObiekt.idGracza = idGracza;

                        // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                    }
                    //kolorObiekt.green = true;

                   // kolorObiekt.Kolor();

                }
            }
      
            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
        }

        pomcol = column;
        pomrow = row;
    }
    public void RangeOfUltKnight(int column, int row, int idGracza)
    {


        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
        for (int i = -2; i <= 2; i++)
        {
            pomrow = row + i;
            pomcol = column;
            test = "P" + pomrow + pomcol;

            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.enemy == true)//ten if powinien siê chyba odpaliæ raz ¿eby enemy nie uderzy³ dwóch postaci

                {
                    //  Debug.Log(test);
                    kolorObiekt.ult2 = true;
                    kolorObiekt.idGracza = idGracza;

                    // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                }
                //   kolorObiekt.green = true;

             //   kolorObiekt.Kolor();

            }
            for (int j = -2; j <= 2; j++)
            {
                //  pomrow = row;
                pomcol = column + j;
                test = "P" + pomrow + pomcol;

                if (dictionaryTypes.ContainsKey(test))
                {
                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;

                    if (kolorObiekt.enemy == true)
                    {
                        kolorObiekt.ult2 = true;
                        kolorObiekt.idGracza = idGracza;

                        // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                    }
                    //kolorObiekt.green = true;

                  //  kolorObiekt.Kolor();

                }
            }

            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
        }

        pomcol = column;
        pomrow = row;
        Debug.Log(pomrow + "heh");
    }
    public void EndOfRound()
    {
        int column = 0;
        row = 0;

        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
        for (int i = 0; i <= 10; i++)
        {
            pomrow = row + i;
            pomcol = column;
            test = "P" + pomrow + pomcol;

            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;


                
                    //  Debug.Log(test);
                    kolorObiekt.round = false;




               // kolorObiekt.Kolor();

            }
            for (int j = 0; j <= 10; j++)
            {
                //  pomrow = row;
                pomcol = column + j;
                test = "P" + pomrow + pomcol;

                if (dictionaryTypes.ContainsKey(test))
                {
                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;

                    {
                        kolorObiekt.round = false;



                    }

                  //  kolorObiekt.Kolor();

                }
            }

            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
        }

        pomcol = column;
        pomrow = row;
    }
    public void EndOfGreen()
    {
        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();

        int k = 5;
        for (int i = -1 - k; i < 4 + k; i++)
        {
            pomrow = 5;
            pomrow = pomrow + i;
            for (int j = -1 - k; j < 1 + k; j++)
            {
                pomcol = 5;
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
    }
    public void EndOfUltStalker()
    {
        int column = 0;
        row = 0;

        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
        for (int i = 0; i <= 10; i++)
        {
            pomrow = row + i;
            pomcol = column;
            test = "P" + pomrow + pomcol;

            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.enemy == true)//ten if powinien siê chyba odpaliæ raz ¿eby enemy nie uderzy³ dwóch postaci

                {
                    //  Debug.Log(test);
                    kolorObiekt.ult = false;
                    kolorObiekt.ult2 = false;

                    // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                }
                //   kolorObiekt.green = true;

                //kolorObiekt.Kolor();

            }
            for (int j = 0; j <= 10; j++)
            {
                //  pomrow = row;
                pomcol = column + j;
                test = "P" + pomrow + pomcol;

                if (dictionaryTypes.ContainsKey(test))
                {
                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;

                    if (kolorObiekt.enemy == true)
                    {
                        kolorObiekt.ult = false;
                        kolorObiekt.ult2 = false;

                        // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                    }
                    //kolorObiekt.green = true;

                   // kolorObiekt.Kolor();

                }
            }

            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
        }

        pomcol = column;
        pomrow = row;
    }
    public void RangeOfAttackStalker(int column, int row, int dmg, int idGracza)
    {



        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
        for (int i = -4; i <= 4; i++)
        {
            pomrow = row + i;
            pomcol = column;
            test = "P" + pomrow + pomcol;

            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.enemy == true)//ten if powinien siê chyba odpaliæ raz ¿eby enemy nie uderzy³ dwóch postaci

                {
                    //  Debug.Log(test);
                    kolorObiekt.enemy2 = true;
                    kolorObiekt.dmg = dmg;
                    kolorObiekt.idGracza = idGracza;

                    // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                }
                //  kolorObiekt.green = true;

             //   kolorObiekt.Kolor();

            }
            pomrow = row;
            pomcol = column + i;
            test = "P" + pomrow + pomcol;

            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.enemy == true)
                {
                    kolorObiekt.enemy2 = true;
                    kolorObiekt.dmg = dmg;
                    kolorObiekt.idGracza = idGracza;

                    // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                }
                //  kolorObiekt.green = true;

              //  kolorObiekt.Kolor();

            }
            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
        }

        pomcol = column;
        pomrow = row;
    }

    public void RangeOfAttack(int column, int row, int dmg, int idGracza)
    {
   


        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
        for (int i = -1; i <= 1; i++)
        {
            pomrow = row + i;
            pomcol = column;
            test = "P" + pomrow + pomcol;

            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.enemy == true)//ten if powinien siê chyba odpaliæ raz ¿eby enemy nie uderzy³ dwóch postaci

                {
                  //  Debug.Log(test);
                   kolorObiekt.enemy2 = true;
                    kolorObiekt.dmg = dmg;
                    kolorObiekt.idGracza = idGracza;

                    // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                }
                //  kolorObiekt.green = true;

             //   kolorObiekt.Kolor();

            }
            pomrow = row;
            pomcol = column + i;
            test = "P" + pomrow + pomcol;

            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.enemy == true)
                {
                    kolorObiekt.enemy2 = true;
                    kolorObiekt.dmg = dmg;
                    kolorObiekt.idGracza = idGracza;

                    // obra¿enia jakie zadaje dana jednostka przesy³ane do zmiennej w polu


                }
                //  kolorObiekt.green = true;

               // kolorObiekt.Kolor();

            }
            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
        }
    
        pomcol = column;
        pomrow = row;
    }


    public void Neighbours(int column, int row)
    {
        a = 0;
        pole = "";

        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
        for (int i = -1; i <= 1; i++)
        {

            pomrow = row + i;
            pomcol = column;
            if (i != 0)
            {
                test = "P" + pomrow + pomcol;
                a++;

            }
            else
            {
                test = "poza";
            }

            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
            if (dictionaryTypes.ContainsKey(test))
            {
                
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;
             //   Debug.Log(a + " ??  " + test + "   " +pole);

                if (kolorObiekt.enemy == true || kolorObiekt.pom == true || kolorObiekt.pole2 == false)
                {
                    //Debug.Log(test + "  test");
                    pole = pole + a;

                }
                else
                {
                    pole = pole + 0;
                }


            }   else if(test!="poza")
            {
                pole = pole + 5;
             //   Debug.Log(pole);


            }
            pomrow = row;
            pomcol = column + i;
            if (i != 0)
            {
                test = "P" + pomrow + pomcol;
                a++;

            }
            else
            {
                test = "poza";
            }

            if (dictionaryTypes.ContainsKey(test))
            {
                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.enemy == true || kolorObiekt.pom == true || kolorObiekt.pole2 == false)
                {

                    pole = pole + a;

                }
                else
                {
                    pole = pole + 0;
                }




            }
              else if(test!="poza")
            {
                pole = pole + 5;

            }
        }
        Debug.Log(pole + "  poleee");
        pomcol = column;
        pomrow = row;
      
    }
    public void StalkerNei(int column, int row)
    {
        a = 0;
        pole = "";

        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
        for (int i = 3; i <= 4; i++)
        {

            pomrow = row + i;
            pomcol = column;
            if (i != 0)
            {
                test = "P" + pomrow + pomcol;
                a++;

            }
            else
            {
                test = "poza";
            }
         //   Debug.Log(test + " test?! " + pole);

            // Zaznacz pole o wspó³rzêdnych (pomrow, pomcol)
            if (dictionaryTypes.ContainsKey(test))
            {

                Type typ = dictionaryTypes[test];
                object obiekt = FindObjectOfType(typ);
                Pole kolorObiekt = (Pole)obiekt;

                if (kolorObiekt.enemy == true || kolorObiekt.pom == true)
                {
                    pole = pole + a;

                }
                else
                {
                    pole = pole + 0;
                }


            }
            else if (test != "poza")
            {
                pole = pole + 5;


            }

        }
        pomcol = column;
        pomrow = row;

    }
    public void EndOfAttack()
    {
        
        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();

        col = pomcol;
        row = pomrow;
        for (int i = -6 - k; i < 6 + k; i++)       //tu
        {
            pomrow = row;
            pomrow = pomrow + i;
            for (int j = -6 - k; j < 6 + k; j++)
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
                  //  kolorObiekt.Kolor();

                }

            }
        
          }
        //  collider.enabled = false;
        
    }
    public void EndOfAttackAlly()
    {

        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();

        col = pomcol;
        row = pomrow;
        for (int i = -4 - k; i < 4 + k; i++)
        {
            pomrow = row;
            pomrow = pomrow + i;
            for (int j = -4 - k; j < 4 + k; j++)
            {
                pomcol = col;

                pomcol = pomcol + j;
                test = "P" + pomrow + pomcol;
                if (dictionaryTypes.ContainsKey(test))
                {
                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;
                    kolorObiekt.ally = false;
                   // kolorObiekt.Kolor();  ??????????????????????????????????????????????????????????????????????????

                }

            }

        }
        //  collider.enabled = false;

    }

}
