using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Random : MonoBehaviour
{
    int random;
    string xd;
    private System.Random rand;
  public static int x = 0;
    int len;
    bool next = false;
    char len2;
    // string a = "33666669";
    // string a = "66666666";
   // string a = "1088881627";
    static public string a = "";
  //  string a = "16666666666666";

    void Start()
    {

    }
    public void Death()
    {
      //  Debug.Log(a[x] + " coooooo" );
        if (a[x] == '0')
        {
         //   Debug.Log(Serf1.row + " noomm");
            if (Serf1.row != 100)
            {
                next = false;
            }
            else
            {

                EndOfTurn.i++;

                x++;
            }
        }
        else if (a[x] == '1')
        {
          //  Debug.Log(Knight1.row + " noomm");

            if (Knight1.row != 100)
            {
                next = false;
            }
            else
            {

                EndOfTurn.i++;

                x++;
            }
        }
        else if (a[x] == '2')
        {//Debug.Log(Knight2.row + " noomm");


            if (Knight2.row != 100)
            {
                next = false;
            }
            else
            {

                EndOfTurn.i++;

                x++;
            }
        }
        else if (a[x] == '3')
        {//Debug.Log(Knight3.row + " noomm");
            if (Knight3.row != 100)
            {
                next = false;
            }
            else
            {

                EndOfTurn.i++;

                x++;
            }
        }
        else if (a[x] == '4')
        {//Debug.Log(Serf2.row + " noomm");
            if (Serf2.row != 100)
            {
                next = false;
            }
            else
            {

                EndOfTurn.i++;

                x++;
            }
        }
        else if (a[x] == '5')
        {
            if (Enemy1.row != 100)
            {
                next = false;
            }
            else
            {

                EndOfTurn.i++;

                x++;
            }
        }
        else if (a[x] == '6')
        {
            if (Knight4.row != 100)
            {
                next = false;
            }
            else
            {
                EndOfTurn.i++;
                x++;
            }

        }
        else if (a[x] == '7')
        {
            if (Knight5.row != 100)
            {
                next = false;
            }
            else
            {
                EndOfTurn.i++;

                x++;
            }

        }

        else if (a[x] == '8')
        {
            if (ESerf1.row != 100)
            {
                next = false;
            }
            else
            {
                EndOfTurn.i++;

                x++;
            }

        }
        else if (a[x] == '9')
        {
            if (ESerf2.row != 100)
            {
                next = false;
            }
            else
            {
                EndOfTurn.i++;
                x++;
            }

        }
    }
    public void SystemTurowy()
    {
        EndOfTurn.blockade = true;

        ButtonMovement.blockade = true;
        ButtonAttack.blockade = true;
        ButtonUlt.blockade = true;
        a = a + "x";
     //   Debug.Log(a + "  ???" + a[x]);
        random = a[x];
        len = a.Length;
        len2 = a[len-1];
        //   Debug.Log(len2+ "  len2");
        Death();

        Death();
        Death();
        Death();
        Death();

        ButtonMovement.random =  a[x];
        ButtonAttack.random = a[x];
        ButtonUlt.random = a[x];


        if (a[x] == '5')
        {
            FindObjectOfType<Enemy1>().EnemyTurn();
            EndOfTurn.turaGracz = false;
        }
        else if (a[x] == '6')
        {
            FindObjectOfType<Knight4>().EnemyTurn();
            EndOfTurn.turaGracz = false;

        }
        else if (a[x] == '7')
        {
            FindObjectOfType<Knight5>().EnemyTurn();
            EndOfTurn.turaGracz = false;

        }

        else if (a[x] == '8')
        {
            FindObjectOfType<ESerf1>().EnemyTurn();
            EndOfTurn.turaGracz = false;

        }
        else if (a[x] == '9')
        {
            FindObjectOfType<ESerf2>().EnemyTurn();
            EndOfTurn.turaGracz = false;

        }
        else
        {
            EndOfTurn.turaGracz = true;

        }
        if (a[x] == 'x')
        {
            EndOfTurn.blockade = false;

            //  Debug.Log("SDDSADASDA");
            x = -1;
            Invoke("End", 3.3f);
        }
        x++;


    }
    void End()
    {
       // Debug.Log( "  testtt  ?  " + a);

        FindObjectOfType<round>().kurwa();   // na odwrót xdddddddddddddd

        SystemTurowy();
        Invoke("End2", 1f);
      //  Debug.Log("  testtt  ?  " + a);

    }
    void End2()
    {
        EndOfTurn.blockade = true;

    }

}
