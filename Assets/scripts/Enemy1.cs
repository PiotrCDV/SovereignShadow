using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


public class Enemy1 : MonoBehaviour
{
    private DictionaryC klasaZDictionary;
      float z = (float)-3.929101;
    public int maxHealth = 6;
    public int currentHealth;
    public hpbar healthBar;
    public hpbars healthBarHeart;
    public static int row = 9;  //5
    public static int column = 7;   //4
    int pomcol;
    int pomrow;
    int id = 6;
    int k = 0;
    int dmg = 4;
    private Knight1 knight1;
    private Knight2 knight2;
    private Knight3 knight3;
    private Knight5 knight5;
    private Serf1 serf1;
    private Serf2 serf2;
    static public bool stun = false;
    public static int taunt = 0;
   public GameObject gameobject;
    static public int rotation;
    string test;
    private Animator animator;
    static public int stalker_1_row= 0;
    static public int stalker_1_column = 0;
    static public int serf_1_row = 0;
    static public int serf_1_column = 0;
    static public int serf_2_row = 0;
    static public int serf_2_column = 0;
    static public int knight_1_row = 0;
    static public int knight_1_column = 0;
    static public int knight_2_row = 0;
    static public int knight_2_column = 0;
    int idCelu = 15;
    int howFar1 = 0;
    int howFar0 = 0;
    int howFar2 = 0;
    int howFar3 = 0;
    int howFar4 = 0;
   public static int death = 0;
    bool enemy = false; private bool move = false;
    public static bool start = false;
    // public static bool blockade = true;
    public float distanceToMove = 0.5f;
    public float timeMove = 2.0f;
    private Vector3 startPosition;
    private Vector3 destination;
    private float startTime;
    public static int howManyMoves = 0;
    bool find = false;

    public static string tablica = "";
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("idle1");
        Vector3 newPosition = transform.position;
        newPosition.z = z;
        transform.position = newPosition;
        Enemy();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBarHeart.SetMaxHealthS(maxHealth);
    }

    void Update()
    {
        if (move)
        {

            float elapsedTime = Time.time - startTime;
            float journeyFraction = elapsedTime / timeMove;
            transform.position = Vector3.Lerp(startPosition, destination, journeyFraction);


        }
        Vector3 newPosition = transform.position;
        newPosition.z = z;
        transform.position = newPosition;
    }
    public void Death()
    {
        if (currentHealth <= 0)
        {
            Kontroler.k--;

            //    IsDead.dead_units = IsDead.dead_units + "6";
            IsDead.dead_units = IsDead.dead_units + 5;
       //     Debug.Log(death + " death");
            row = 100;
            if (death == 0)
            {
                FindObjectOfType<Obrazek0>().Ready();

            }else if(death==1)
            {
                FindObjectOfType<Obrazek1>().Ready();


            }
            else if (death == 2)
            {
                FindObjectOfType<Obrazek2>().Ready();


            }
            else if (death == 3)
            {
                FindObjectOfType<Obrazek3>().Ready();


            }
            else if (death == 4)
            {
                FindObjectOfType<Obrazek4>().Ready();


            }
            else if (death == 5)
            {
                FindObjectOfType<Obrazek5>().Ready();


            }
            else if (death == 6)
            {
                FindObjectOfType<Obrazek6>().Ready();


            }
            else if (death == 7)
            {
                FindObjectOfType<Obrazek7>().Ready();


            }
            else if (death == 8)
            {
                FindObjectOfType<Obrazek8>().Ready();


            }
            else if (death == 9)
            {
                FindObjectOfType<Obrazek9>().Ready();


            }

        }
    }
    public void EnemyTurn()
    {

        Controller.arrow = false;


        howFar1 = row - serf_1_row;

        if (howFar1 < 0)
        {
            howFar1 = howFar1 * -1;
        }
        howFar0 = column - serf_1_column;

        if (howFar0 < 0)
        {
            howFar0 = howFar0 * -1;
        }
        howFar1 = howFar1 + howFar0;
        //   Debug.Log(howFar1 + " howfar1");
        howFar2 = row - serf_2_row;

        if (howFar2 < 0)
        {
            howFar2 = howFar2 * -1;
        }
        howFar0 = column - serf_2_column;

        if (howFar0 < 0)
        {
            howFar0 = howFar0 * -1;
        }
        howFar2 = howFar2 + howFar0;
        //  Debug.Log(howFar2 + " howfar2");

        //////////////////////////////

        howFar3 = row - knight_1_row;

        if (howFar3 < 0)
        {
            howFar3 = howFar3 * -1;
        }
        howFar0 = column - knight_1_column;

        if (howFar0 < 0)
        {
            howFar0 = howFar0 * -1;
        }
        howFar3 = howFar3 + howFar0;
        //  Debug.Log(howFar3 + " howfar3");
        howFar4 = row - knight_2_row;

        if (howFar4 < 0)
        {
            howFar4 = howFar4 * -1;
        }
        howFar0 = column - knight_2_column;

        if (howFar0 < 0)
        {
            howFar0 = howFar0 * -1;
        }
        howFar4 = howFar4 + howFar0;

        if (stun == false)
        {

            //  Debug.Log(howFar4 + " howfar4");
            find = false;
            //FindObjectOfType<Controller>().StalkerRangeOfAttack(column, row, dmg, id, idCelu);
            if (taunt != 0){
               // FindObjectOfType<Controller>().StalkerRangeOfAttack2(column, row, dmg, id, idCelu);   //xdddd
                Debug.Log("heheheheniiiii3");

            }
            else
            {

            }

        if (Controller.arrow == true)
        {
                Debug.Log("heheheheniiiii2");

            }
            else
        {
                Debug.Log("heheheheniiiii");


        if (howFar3 <= howFar4 && knight_1_row != 100 && find == false && taunt != 2 && taunt != 4)
        {
               
                    //  taunt = 4;
                    idCelu = 2;
            FindObjectOfType<Knight2>().StalkerNei();

                if (row == knight_1_row + 3 && column == knight_1_column || row == knight_1_row + 4 && column == knight_1_column)
              //  || row == knight_1_row && column == knight_1_column + 3 || row == knight_1_row + 4 && column == knight_1_column)
            {
                        taunt = 0;
                FindObjectOfType<Controller>().StalkerRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();
                find = true;

            }
            else if (Controller.pole[0] == '0')
            {
                        taunt = 0;

                        FindObjectOfType<MovementE>().Move(column, row, knight_1_column, knight_1_row + 3, id);
                find = true;

            }
            else if (Controller.pole[1] == '0')
            {
                        taunt = 0;


                        FindObjectOfType<MovementE>().Move(column, row, knight_1_column, knight_1_row + 4, id);
                    find = true;

            }
          





        }
        if (knight_2_row != 100 && find == false && taunt != 1 && taunt != 4)
        {
                    //  taunt = 4;
                
                    idCelu = 3;
            FindObjectOfType<Knight3>().StalkerNei();

            if (row == knight_2_row + 3 && column == knight_2_column || row == knight_2_row +4 && column == knight_2_column)
              //  || row == knight_2_row && column == knight_2_column + 3 || row == knight_2_row && column == knight_2_column + 4)
            {
                        taunt = 0;

                        FindObjectOfType<Controller>().StalkerRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();
                find = true;

            }
            else if ( Controller.pole[0] == '0')
            {
                        taunt = 0;

                        FindObjectOfType<MovementE>().Move(column, row, knight_2_column, knight_2_row + 3, id);
                find = true;

            }
            else if (Controller.pole[1] == '0')
                    {
                        taunt = 0;


                        FindObjectOfType<MovementE>().Move(column, row, knight_2_column, knight_2_row + 4, id);
                    find = true;

            }
     




        }
        if (knight_1_row != 100 && find == false && taunt != 2 && taunt != 4)
        {
                    // taunt = 4;
                
                    idCelu = 2;
            FindObjectOfType<Knight2>().StalkerNei();

            if (row == knight_1_row + 3 && column == knight_1_column || row == knight_1_row + 4 && column == knight_1_column)
              //  || row == knight_1_row && column == knight_1_column + 3 || row == knight_1_row && column == knight_1_column + 4)
            {
                        taunt = 0;

                        FindObjectOfType<Controller>().StalkerRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();
                find = true;

            }
            else if (Controller.pole[0] == '0')
            {
                        taunt = 0;

                        FindObjectOfType<MovementE>().Move(column, row, knight_1_column, knight_1_row + 3, id);
                find = true;

            }
            else if ( Controller.pole[1] == '0')
            {
                        taunt = 0;

                        FindObjectOfType<MovementE>().Move(column, row, knight_1_column, knight_1_row + 4, id);
                    find = true;

            }
       





        }
    
        if (howFar2 >= howFar1 && serf_1_row != 100 && find == false && taunt == 0)
        {
            idCelu = 0;
            FindObjectOfType<Serf1>().StalkerNei();

            if (row == serf_1_row + 3 && column == serf_1_column || row == serf_1_row +4 && column == serf_1_column)
            //    || row == serf_1_row && column == serf_1_column + 1 || row == serf_1_row && column == serf_1_column - 1)
            {
                FindObjectOfType<Controller>().StalkerRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();       
                find = true;
            }
            else if ( Controller.pole[0] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, serf_1_column, serf_1_row + 3, id);
                find = true;


            }
            else if ( Controller.pole[1] == '0')
            {

                    FindObjectOfType<MovementE>().Move(column, row, serf_1_column, serf_1_row + 4, id);
                    find = true;


            }
   

        }
        if (serf_2_row != 100 && find == false && taunt == 0)
        {
            idCelu = 4;

            FindObjectOfType<Serf2>().StalkerNei();

            if (row  == serf_2_row + 3 && column == serf_2_column || row  == serf_2_row + 4 && column == serf_2_column)
           // || row == serf_2_row && column == serf_2_column + 1 || row == serf_2_row && column == serf_2_column - 1)
            {
                FindObjectOfType<Controller>().StalkerRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();
                find = true;

            }
            else if (Controller.pole[0] == '0')
            {
                find = true;

                FindObjectOfType<MovementE>().Move(column, row, serf_2_column, serf_2_row + 3, id);

            }
            else if ( Controller.pole[1] == '0')
            {
                find = true;

                    FindObjectOfType<MovementE>().Move(column, row, serf_2_column, serf_2_row + 4, id);

                }


            }

        if (serf_1_row != 100 && find == false && taunt == 0)
        {
            idCelu = 0;
            FindObjectOfType<Serf1>().StalkerNei();

            if (row == serf_1_row + 3 && column == serf_1_column || row == serf_1_row +4 && column == serf_1_column)
             //   || row == serf_1_row && column == serf_1_column + 1 || row == serf_1_row && column == serf_1_column - 1)
            {
                FindObjectOfType<Controller>().StalkerRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();           // je¿eli wróg ma do przejœcia jedno pole to przejdzie trzy
                find = true;
            }
            else if (Controller.pole[0] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, serf_1_column, serf_1_row + 3, id);
                find = true;


            }
            else if ( Controller.pole[1] == '0')
            {

                    FindObjectOfType<MovementE>().Move(column, row, serf_1_column, serf_1_row + 4, id);
                    find = true;


            }
    
        }

       
        if (stalker_1_row != 100 && find == false && taunt == 0)
        {
            idCelu = 1;
            FindObjectOfType<Knight1>().StalkerNei();

            if (row == stalker_1_row + 3 && column == stalker_1_column || row == stalker_1_row +4 && column == stalker_1_column)
              //  || row == stalker_1_row && column == stalker_1_column + 1 || row == stalker_1_row && column == stalker_1_column - 1)
            {
                FindObjectOfType<Controller>().StalkerRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();
                find = true;

            }
            else if (Controller.pole[0] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, stalker_1_column, stalker_1_row + 3, id);
                find = true;

            }
            else if ( Controller.pole[1] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, stalker_1_column, stalker_1_row + 4, id);
                find = true;

            }




        }
                //  if(find == false && taunt == 0)
                // {
                //  FindObjectOfType<Controller>().StalkerRangeOfAttack2(column, row, dmg, id, idCelu);

                // }


                if (taunt == 1 || taunt == 2 || find == false)
            {
                Invoke("EndOfTurn", 0.5f);   // ????

            }
          }

        }
        else
        {
            if(Controller.arrow==false)
            {
                Invoke("EndOfTurn", 0.5f);

            }

        }
        taunt = 0;
        stun = false;
    }

    void EndOfTurn()
    {
        FindObjectOfType<EndOfTurn>().Change();

    }
    public void TauntUlt(int idGracza)
    {


        Debug.Log(idGracza + "/??");
        // StartCoroutine("Hurt2");

        if (idGracza == 2)
        {
            taunt = 1;
            knight2 = FindObjectOfType<Knight2>();

            StartCoroutine(knight2.AnimationUlt(rotation));
        }
        else if (idGracza == 3)
        {
            taunt = 2;
            knight3 = FindObjectOfType<Knight3>();

            StartCoroutine(knight3.AnimationUlt(rotation));
        }





        //   Debug.Log(dmg);


    }
    public IEnumerator Hurt2()
    {

        // animator.SetTrigger("Idle2");
        if (rotation == 2)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("hurt4");
            yield return new WaitForSeconds(0.20f);

            FindObjectOfType<Audio>().aHurt();

            yield return new WaitForSeconds(1.05f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle4");
        }
        else if (rotation == 1)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("hurt2");   //2
            yield return new WaitForSeconds(0.20f);

            FindObjectOfType<Audio>().aHurt();

            yield return new WaitForSeconds(1.05f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle2");  //2
        }
        else if (rotation == 4)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("hurt3");
            yield return new WaitForSeconds(0.20f);

            FindObjectOfType<Audio>().aHurt();

            yield return new WaitForSeconds(1.05f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle3");
        }
        else if (rotation == 3)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("hurt1");
            yield return new WaitForSeconds(0.20f);

            FindObjectOfType<Audio>().aHurt();

            yield return new WaitForSeconds(1.05f);
            animator.SetTrigger("idle");
            animator.SetTrigger("idle1");
        }

    }
    public IEnumerator Animation(int rotation)
    {
        FindObjectOfType<Audio>().aAttack();

        if (rotation == 1)
        {
            animator.SetTrigger("idle");
            animator.SetTrigger("attack3");
            yield return new WaitForSeconds(1.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle3");

        }

        else if (rotation == 2)
        {
            animator.SetTrigger("idle");
           // yield return new WaitForSeconds(0.01f);
            //    transform.Translate(new Vector3(1f, 0, 0f).normalized * 0.1f);

            animator.SetTrigger("attack1");  //1
            yield return new WaitForSeconds(1.2f);
            //   transform.Translate(new Vector3(-1f, 0, 0f).normalized * 0.1f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle1");  //1
        }
        else if (rotation == 3)
        {
            animator.SetTrigger("idle");
         //   transform.Translate(new Vector3(0, -1f, 0f).normalized * 0.1f);
            animator.SetTrigger("attack4"); //4
            yield return new WaitForSeconds(1.2f);
            //  transform.Translate(new Vector3(0, 1f, 0f).normalized * 0.10f);
            animator.SetTrigger("idle");
            animator.SetTrigger("idle4");//4
        }
        else if (rotation == 4)
        {
            animator.SetTrigger("idle");
         //   transform.Translate(new Vector3(-0.3f, -1f, 0f).normalized * 0.15f);
            animator.SetTrigger("attack2");
            Debug.Log("heheheheheh!!!!!!!!!!!!!!!!!!????????????");

            yield return new WaitForSeconds(1.2f);
            Debug.Log("heheheheheh!!!!!!!!!!!!!!!!!!????????????");

            // transform.Translate(new Vector3(0.3f, 1f, 0f).normalized * 0.15f);
            animator.SetTrigger("idle");
            Debug.Log("heheheheheh!!!!!!!!!!!!!!!!!!????????????");

            animator.SetTrigger("idle2");  //2
        }



    }
    public IEnumerator Death2()
    {

        // animator.SetTrigger("Idle2");
        if (rotation == 2)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("death4");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().aDeath();

            yield return new WaitForSeconds(1.3f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle4");
        }
        else if (rotation == 1)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("death2");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().aDeath();

            yield return new WaitForSeconds(1.3f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle1");  //2
        }
        else if (rotation == 4)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("death3");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().aDeath();

            yield return new WaitForSeconds(1.3f);
            animator.SetTrigger("idle");

            animator.SetTrigger("death3");
        }
        else if (rotation == 3)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("death1");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().aDeath();

            yield return new WaitForSeconds(1.3f);
            animator.SetTrigger("idle");
            animator.SetTrigger("death1");
        }
        Destroy(gameObject);


    }
    public void DamageTaken(int dmg, int idGracza)
    {
     
        if (idGracza==1)
        {
            if (currentHealth - dmg > 0)
            {
                StartCoroutine("Hurt2");

            }
            else
            {
                StartCoroutine("Death2");

            }

            knight1 = FindObjectOfType<Knight1>();

            StartCoroutine(knight1.Animation(rotation));
        }else if (idGracza==2)
        {
            if (currentHealth - dmg > 0)
            {
                StartCoroutine("Hurt2");

            }
            else
            {
                StartCoroutine("Death2");

            }
            knight2 = FindObjectOfType<Knight2>();

            StartCoroutine(knight2.Animation(rotation));

        }
        else if (idGracza == 3)
        {
            if (currentHealth - dmg > 0)
            {
                StartCoroutine("Hurt2");

            }
            else
            {
                StartCoroutine("Death2");

            }
            knight3 = FindObjectOfType<Knight3>();

            StartCoroutine(knight3.Animation(rotation));

        }
        else if (idGracza == 0)
        {
            if (currentHealth - dmg > 0)
            {
                StartCoroutine("Hurt2");

            }
            else
            {
                StartCoroutine("Death2");

            }
            serf1 = FindObjectOfType<Serf1>();

            StartCoroutine(serf1.Animation(rotation));

        }
        else if (idGracza == 4)
        {
            if (currentHealth - dmg > 0)
            {
                StartCoroutine("Hurt2");

            }
            else
            {
                StartCoroutine("Death2");

            }
            serf2 = FindObjectOfType<Serf2>();

            StartCoroutine(serf2.Animation(rotation));

        }


        Takendmg(dmg);
        Death();
    }
    public void Takendmg(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        healthBarHeart.SetHealthS(currentHealth);
    }

    public void Enemy()
    {

        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
    

                test = "P" + row + column;
        
                if (dictionaryTypes.ContainsKey(test))
                {
                    Type typ = dictionaryTypes[test];
                    object obiekt = FindObjectOfType(typ);
                    Pole kolorObiekt = (Pole)obiekt;

                 kolorObiekt.id = id;

            //  kolorObiekt.green = true;

       //     kolorObiekt.Kolor();

                }

      
    }

    public void DamageTakenUlt(int dmg, int idGracza)
    {


        if (idGracza == 1)
        {
          //  StartCoroutine("Hurt2");

         //   knight1 = FindObjectOfType<Knight1>();

          //  StartCoroutine(knight1.AnimationUlt(rotation));




            if (currentHealth - dmg > 0)
            {
                StartCoroutine("Hurt2");

            }
            else
            {
                StartCoroutine("Death2");

            }

            knight1 = FindObjectOfType<Knight1>();

            StartCoroutine(knight1.AnimationUlt(rotation));
        }



        //   Debug.Log(dmg);
        Takendmg(dmg);
        Death();

    }
    public IEnumerator Movement()
    {
        FindObjectOfType<Audio>().aWalk();

        animator.SetTrigger("idle");
        // Debug.Log(row + "  " + column);


         for (int i = 0; i < howManyMoves; i++)
        {

            if (tablica[i] == '1')
            {

                //animator.SetTrigger("Idle");
                //    Debug.Log("Up");
                z = (float)(z + 0.01);
                //  animator.SetTrigger("Idle2");
                animator.SetTrigger("walk3");
                move = true;
                startPosition = transform.position;
                destination = startPosition + new Vector3(0.85f, 0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("idle");
                //   animator.SetTrigger("Idle1");

                //    animator.SetTrigger("Idle1");
                //  animator.SetTrigger("Idle3");

            }
            else if (tablica[i] == '2')
            {

                //  animator.SetTrigger("Idle");
                z = (float)(z - 0.0001);
                //    Debug.Log("Right");
                // animator.SetTrigger("Idle2");
                animator.SetTrigger("walk1");
                move = true;
                startPosition = transform.position;
                destination = startPosition + new Vector3(0.85f, -0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("idle");
                // animator.SetTrigger("Idle22");


            }
            else if (tablica[i] == '3')
            {

                z = (float)(z + 0.0001);
                //   Debug.Log("Left");
                //   animator.SetTrigger("Idle2");
                animator.SetTrigger("walk4");
                //     Debug.Log("lewo");
                move = true;
                startPosition = transform.position;
                destination = startPosition + new Vector3(-0.85f, 0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("idle");
                // animator.SetTrigger("Idle1");

                //   animator.SetTrigger("Idle3");
            }
            else if (tablica[i] == '4')
            {
                z = (float)(z - 0.01);
                //  animator.SetTrigger("Idle");
                //Debug.Log("Down");
                //  animator.SetTrigger("Idle2");
                animator.SetTrigger("walk2");
                move = true;

                startPosition = transform.position;
                destination = startPosition + new Vector3(-0.85f, -0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("idle");
                //     animator.SetTrigger("Idle4");
            }


        }
        FindObjectOfType<Audio>().Stop();

        FindObjectOfType<Controller>().StalkerRangeOfAttack(column, row, dmg, id, idCelu);
        if (Controller.arrow == true)
        {

        }
        else
        {
            Debug.Log("ccciiiiiiiiiiiii");
          //  FindObjectOfType<Controller>().StalkerRangeOfAttack2(column, row, dmg, id, idCelu);

        }
        Enemy();

        if (howManyMoves > 0)
        {
            if (tablica[howManyMoves - 1] == '1')//??
                animator.SetTrigger("idle3");

            if (tablica[howManyMoves - 1] == '2')
                animator.SetTrigger("idle1");

            if (tablica[howManyMoves - 1] == '3')
                animator.SetTrigger("idle4");

            if (tablica[howManyMoves - 1] == '4')
                animator.SetTrigger("idle2");
        }
        else
        {
            animator.SetTrigger("idle1");

        }




        //    firstMove = true;
        ButtonMovement.blockade = true;


        howManyMoves = 0;

    }


}


