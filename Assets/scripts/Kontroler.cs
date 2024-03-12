using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontroler : MonoBehaviour
{
    public GameObject obrazek;
    static public string runda;
    int y = 2;
    public static int obr = 0;
    static public int z = 100;
    static public int death = 0;
    public static int k =10;
    void Start()
    {
        

    }

    void Update()
    {
        
    }

    public void GenObrazek()
    {
     //   Debug.Log(runda + " rs");
        Czekaj();

    }

   // public IEnumerator Czekaj()
   public void Czekaj()
    {

       // Debug.Log(k);
        for (int i = 0; i < k; i++)
        {
           // yield return new WaitForSeconds(0.00001f);

            EndOfTurn.i = 0;

            if (runda[i] == '0')
            {
                obr = 2;
                Serf1.death = i;
              //  Debug.Log(Serf1.death + "  Serf1 !!!");

            }
            else if (runda[i] == '1')
            {

                obr = 4;
                Knight1.death = i;
            //    Debug.Log(Knight1.death + "  Knight1 !!!");

            }
            else if (runda[i] == '2')
            {


                obr = 0;
                Knight2.death = i;
            //    Debug.Log(Knight2.death + "  Knight2 !!!");

            }
            else if (runda[i] == '3')
            {
                obr = 0;
                Knight3.death = i;
            //    Debug.Log(Knight3.death + "  Knight3 !!!");

            }
            else if (runda[i] == '4')
            {


                obr = 2;
                Serf2.death = i;
             //   Debug.Log(Serf2.death + "  Serf2 !!!");


            }
            else if (runda[i] == '5')
            {
              //  Debug.Log(runda[i] + "   " + runda + "  " + i);
                obr = 5;

                Enemy1.death = i;

            }
            else if (runda[i] == '6')
            {
                obr = 1;
                Knight4.death = i;

            }
            else if (runda[i] == '7')
            {
                obr = 1;
                Knight5.death = i;

            }
            else if (runda[i] == '8')
            {
                obr = 3;
                ESerf1.death = i;

            }
            else if (runda[i] == '9')
            {
                obr = 3;
                ESerf2.death = i;

            }

            if (i == 0)
            {
                FindObjectOfType<Obrazek0>().ChangeSprite(obr);


            }
            else if (i == 1)
            {
                FindObjectOfType<Obrazek1>().ChangeSprite(obr);

            }
            else if (i == 2)
            {
                FindObjectOfType<Obrazek2>().ChangeSprite(obr);

            }
            else if (i == 3)
            {
                FindObjectOfType<Obrazek3>().ChangeSprite(obr);

            }
            else if (i == 4)
            {
                FindObjectOfType<Obrazek4>().ChangeSprite(obr);

            }
            else if (i == 5)
            {
                FindObjectOfType<Obrazek5>().ChangeSprite(obr);

            }
            else if (i == 6)
            {
                FindObjectOfType<Obrazek6>().ChangeSprite(obr);

            }
            else if (i == 7)
            {
                FindObjectOfType<Obrazek7>().ChangeSprite(obr);

            }
            else if (i == 8)
            {
                FindObjectOfType<Obrazek8>().ChangeSprite(obr);

            }
            else if (i == 9)
            {
                FindObjectOfType<Obrazek9>().ChangeSprite(obr);

            }
            //  Obrazek.numer = obr;
            // Debug.Log(Obrazek.numer + "  numer");

            //  var newObject = (GameObject)Instantiate(obrazek, new Vector3((float)8.668, y, z), Quaternion.identity);
            //  newObject.name = "Obraz" + i;

            y = y + 2;
        }
    }



}
