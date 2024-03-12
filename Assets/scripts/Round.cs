using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class round : MonoBehaviour
{
    string martwe = "";
    public int jednostka = 5;
    public int ejednostka = 5;
    int licznik = 0;
    int[] team = new int[] {0, 1, 2, 3,4 };
    int[] eteam = new int[] { 5, 6,7,8,9 };
    public string tura = "";
    int los = 0;
    string runda = "";
   static public string fround = "";

    public void kurwa()
    {
        martwe = IsDead.dead_units;
        fround = "";

        if (jednostka != 0 && ejednostka != 0)
        {
            int[] shuffled = team.OrderBy(n => Guid.NewGuid()).ToArray();
            int[] shuffled2 = eteam.OrderBy(n => Guid.NewGuid()).ToArray();
            for (int i = 0; i < 5; i++)
            {
                tura = tura+ shuffled[i];
                tura = tura+ shuffled2[i];
            }
         //   Debug.Log(tura);
        }
        else if (ejednostka == 0)
        {

        }
        else if (jednostka == 0)
        {

        }

        char[] cTura = tura.ToCharArray();
        char[] cDead = martwe.ToCharArray();
     //   Debug.Log(martwe + " martwe");
        tura = "";
        for (int i = 0; i < cTura.Length; i++)
        {
            for (int j = 0; j < cDead.Length; j++)
            {
                if (cTura[i] == cDead[j])
                {
                    cTura[i] = ' ';
                }
            }
            runda = runda + cTura[i];

        }
       
        for (int i = 0;i<10;i++)
        {
            if (runda[i] == ' ')
            {
                
             
            }
            else
            {
                fround = fround + runda[i];
              
            }
        }
       // Debug.Log(fround + " sssd");

       Random.a = fround;

        Kontroler.runda = fround;
        fround = "";
        runda = "";

        FindObjectOfType<Kontroler>().GenObrazek();

        //  Debug.Log(Kontroler.runda + " runda");
    }



    private void Start()
    {      
        
        jednostka = 5;
        ejednostka = 5;
        kurwa();       
       

    }
    private void Update()
    {

    }

}
