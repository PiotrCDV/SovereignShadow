using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndOfTurn : MonoBehaviour
{
    public static bool ChangeZ = false;
   static public int i = 0;
    public static bool blockade = true;

    static public bool turaGracz = false;
    public new Collider2D collider;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        FindObjectOfType<Random>().SystemTurowy();


    }

    void Update()
    {
        if (blockade)
        {

            collider.enabled = true;

        }
        else
        {
            collider.enabled = false;

        }
    //    Debug.Log(i + " !s");
    }
    private void OnMouseDown()
    {
        FindObjectOfType<EndMusic>().Button();

        FindObjectOfType<Controller>().EndOfAttack();//
        FindObjectOfType<Controller>().EndOfGreen();//

        FindObjectOfType<Controller>().EndOfUltStalker();//
        FindObjectOfType<Controller>().EndOfRound();
        if (turaGracz == true)
        {
        //    Debug.Log(i + " !ssssssssssssssssssssssssssssssssss2");

            if (i == 0)
            {
              //  Debug.Log(i + " !ssssssssssssssssssssssssssssssssss2");

                FindObjectOfType<Obrazek0>().Ready();

            }
            else if (i == 1)
            {
                FindObjectOfType<Obrazek1>().Ready();

            }
            else if (i == 2)
            {
                FindObjectOfType<Obrazek2>().Ready();

            }
            else if (i == 3)
            {
                FindObjectOfType<Obrazek3>().Ready();

            }
            else if (i == 4)
            {
                FindObjectOfType<Obrazek4>().Ready();

            }
            else if (i == 5)
            {
                FindObjectOfType<Obrazek5>().Ready();

            }
            else if (i == 6)
            {
                FindObjectOfType<Obrazek6>().Ready();

            }
            else if (i == 7)
            {

                FindObjectOfType<Obrazek7>().Ready();

            }
            else if (i == 8)
            {
                FindObjectOfType<Obrazek8>().Ready();

            }
            else if (i == 9)
            {
                FindObjectOfType<Obrazek9>().Ready();

            }
            FindObjectOfType<Random>().SystemTurowy();

            i++;
        }
        //   Obrazek.ChangeZ = true;

        //  obrazek.Ready();
        //   Invoke("Change", 1f);



    }

         public void Change()
    {
      //  FindObjectOfType<Controller>().EndOfRound();


        if (i == 0)
        {
            FindObjectOfType<Obrazek0>().Ready();


        }
        else if (i == 1)
        {
            FindObjectOfType<Obrazek1>().Ready();

        }
        else if (i == 2)
        {
            FindObjectOfType<Obrazek2>().Ready();

        }
        else if (i == 3)
        {
            FindObjectOfType<Obrazek3>().Ready();

        }
        else if (i == 4)
        {
            FindObjectOfType<Obrazek4>().Ready();

        }
        else if (i == 5)
        {
            FindObjectOfType<Obrazek5>().Ready();

        }
        else if (i == 6)
        {
            FindObjectOfType<Obrazek6>().Ready();

        }
        else if (i == 7)
        {

            FindObjectOfType<Obrazek7>().Ready();

        }
        else if (i == 8)
        {
            FindObjectOfType<Obrazek8>().Ready();

        }
        else if (i == 9)
        {
            FindObjectOfType<Obrazek9>().Ready();

        }
        FindObjectOfType<Random>().SystemTurowy();

        i++;
    }
}
