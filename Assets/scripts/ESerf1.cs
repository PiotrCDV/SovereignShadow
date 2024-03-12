using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ESerf1 : MonoBehaviour
{
    private DictionaryC klasaZDictionary;
    float z = (float)-3.959201;
    public int maxHealth = 9;
    public int currentHealth;
    public hpbar healthBar;
    public hpbars healthBarHeart;
    public static int row = 8;  //5
    public static int column = 4;   //2
    int pomcol;
    int pomrow;
    int id = 5;
    int k = 0;
    int idCelu = 15;
    int dmg = 4;
    private Knight1 knight1;
    private Knight2 knight2;
    private Knight3 knight3;
    private Serf1 serf1;
    private Serf2 serf2;
    public static int taunt = 0;

    private Knight5 knight5;
    static public int rotation;
    string test;
    private Animator animator;
    static public int stalker_1_row = 0;
    static public int stalker_1_column = 0;
    static public int serf_1_row = 0;
    static public int serf_1_column = 0;
    static public int serf_2_row = 0;
    static public int serf_2_column = 0;
    static public int knight_1_row = 0;
    static public int knight_1_column = 0;
    static public int knight_2_row = 0;
    static public int knight_2_column = 0;
    bool find = false;
    bool enemy = false; private bool move = false;
    public static bool start = false;
    // public static bool blockade = true;
    public float distanceToMove = 0.5f;
    public float timeMove = 2.0f;
    private Vector3 startPosition;
    private Vector3 destination;
    private float startTime;
    public static int howManyMoves = 0;
    public static int death = 0;
    static public bool stun = false;

    public static string tablica = "";

    int howFar1 = 0;
    int howFar0 = 0;
    int howFar2 = 0;
    int howFar3 = 0; 
    int howFar4 = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("idle1");
        Enemy();
        Vector3 newPosition = transform.position;
        newPosition.z = z;
        transform.position = newPosition;
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

            IsDead.dead_units = IsDead.dead_units + 8;

            row = 100;
            if (death == 0)
            {
                FindObjectOfType<Obrazek0>().Ready();

            }
            else if (death == 1)
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
        if (howFar2 >= howFar1 && serf_1_row != 100 && taunt == 0)
        {
            idCelu = 0;
            FindObjectOfType<Serf1>().Neighbours();

            if (row == serf_1_row + 1 && column == serf_1_column || row == serf_1_row - 1 && column == serf_1_column
                || row == serf_1_row && column == serf_1_column + 1 || row == serf_1_row && column == serf_1_column - 1)
            {
                FindObjectOfType<Controller>().AllyRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();           
                find = true;
            }
            else if (row > serf_1_row && Controller.pole[2] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, serf_1_column, serf_1_row + 1, id);
                find = true;


            }
            else if (column > serf_1_column && Controller.pole[3] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, serf_1_column + 1, serf_1_row, id);
                find = true;


            }
            //    else if (column < serf_1_column && Controller.pole[1] == '0')
            else if ( Controller.pole[1] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, serf_1_column - 1, serf_1_row, id);
                find = true;


            }
            //    else if (row < serf_1_row && Controller.pole[0] == '0')
            else if ( Controller.pole[0] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, serf_1_column, serf_1_row - 1, id);
                find = true;

            }
        
        }
        if (serf_2_row != 100 && find==false && taunt == 0)
        {
            idCelu = 4;

            FindObjectOfType<Serf2>().Neighbours();

            if (row + 1 == serf_2_row && column == serf_2_column || row - 1 == serf_2_row && column == serf_2_column
            || row == serf_2_row && column == serf_2_column + 1 || row == serf_2_row && column == serf_2_column - 1)
            {
                FindObjectOfType<Controller>().AllyRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();
                find = true;

            }
            else if (row > serf_2_row && Controller.pole[2] == '0')
            {
                find = true;

                FindObjectOfType<MovementE>().Move(column, row, serf_2_column, serf_2_row + 1, id);

            }
            else if (column > serf_2_column && Controller.pole[3] == '0')
            {
                find = true;

                FindObjectOfType<MovementE>().Move(column, row, serf_2_column + 1, serf_2_row, id);

            }
            //  else if (column < serf_2_column && Controller.pole[1] == '0')
            else if ( Controller.pole[1] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, serf_2_column - 1, serf_2_row, id);
                find = true;


            }
            // else if (row < serf_2_row && Controller.pole[0] == '0')
            else if (Controller.pole[0] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, serf_2_column, serf_2_row - 1, id);
                find = true;


            }

        }
      
        if (serf_1_row != 100 &&  find==false && taunt == 0)
        {
            idCelu = 0;
            FindObjectOfType<Serf1>().Neighbours();

            if (row == serf_1_row + 1 && column == serf_1_column || row == serf_1_row - 1 && column == serf_1_column
                || row == serf_1_row && column == serf_1_column + 1 || row == serf_1_row && column == serf_1_column - 1)
            {
                FindObjectOfType<Controller>().AllyRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();           // je¿eli wróg ma do przejœcia jedno pole to przejdzie trzy
                find = true;
            }
            else if (row > serf_1_row && Controller.pole[2] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, serf_1_column, serf_1_row + 1, id);
                find = true;


            }
            else if (column > serf_1_column && Controller.pole[3] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, serf_1_column + 1, serf_1_row, id);
                find = true;


            }
            //    else if (column < serf_1_column && Controller.pole[1] == '0')
            else if (Controller.pole[1] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, serf_1_column - 1, serf_1_row, id);
                find = true;


            }
            //    else if (row < serf_1_row && Controller.pole[0] == '0')
            else if (Controller.pole[0] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, serf_1_column, serf_1_row - 1, id);
                find = true;

            }
            else
            {
                find = false;
            }
        }
        if (howFar3 <= howFar4 && knight_1_row != 100 && find == false && taunt != 2 && taunt != 4)
        {
                // taunt = 4;
           
                idCelu = 2;
            FindObjectOfType<Knight2>().Neighbours();

            if (row == knight_1_row + 1 && column == knight_1_column || row == knight_1_row - 1 && column == knight_1_column
                || row == knight_1_row && column == knight_1_column + 1 || row == knight_1_row && column == knight_1_column - 1)
            {
                FindObjectOfType<Controller>().AllyRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();
                find = true;
                    taunt = 0;

                }
                else if (row > knight_1_row && Controller.pole[2] == '0')
            {
                    Debug.Log("cooo???!!?!1");
                FindObjectOfType<MovementE>().Move(column, row, knight_1_column, knight_1_row + 1, id);
                find = true;
                    taunt = 0;

                }
                else if (column > knight_1_column && Controller.pole[3] == '0')
            {
                    Debug.Log("cooo???!!?!2");

                    FindObjectOfType<MovementE>().Move(column, row, knight_1_column + 1, knight_1_row, id);
                find = true;
                    taunt = 0;

                }
                //   else if (column < knight_1_column && Controller.pole[1] == '0')
                else if (Controller.pole[1] == '0')
            {
                    Debug.Log("cooo???!!?!3");

                    FindObjectOfType<MovementE>().Move(column, row, knight_1_column - 1, knight_1_row, id);
                find = true;
                    taunt = 0;

                }
                //  else if (row < knight_1_row && Controller.pole[0] == '0')
                else if (Controller.pole[0] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, knight_1_column, knight_1_row - 1, id);
                find = true;
                    taunt = 0;

                }





            }
       if (knight_2_row != 100 && find == false && taunt != 1 && taunt != 4)
        {
                //  taunt = 4;
           
                idCelu = 3;
            FindObjectOfType<Knight3>().Neighbours();

            if (row == knight_2_row + 1 && column == knight_2_column || row == knight_2_row - 1 && column == knight_2_column
                || row == knight_2_row && column == knight_2_column + 1 || row == knight_2_row && column == knight_2_column - 1)
            {
                FindObjectOfType<Controller>().AllyRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();
                find = true;
                    taunt = 0;

                }
                else if (row > knight_2_row && Controller.pole[2] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, knight_2_column, knight_2_row + 1, id);
                find = true;
                    taunt = 0;

                }
                else if (column > knight_2_column && Controller.pole[3] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, knight_2_column + 1, knight_2_row, id);
                find = true;
                    taunt = 0;

                }
                //      else if (column < knight_2_column && Controller.pole[1] == '0')
                else if (Controller.pole[1] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, knight_2_column - 1, knight_2_row, id);
                find = true;
                    taunt = 0;

                }
                //  else if (row < knight_2_row && Controller.pole[0] == '0')
                else if (Controller.pole[0] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, knight_2_column, knight_2_row - 1, id);
                find = true;
                    taunt = 0;

                }





            }
        if ( knight_1_row != 100 && find == false && taunt != 2 && taunt != 4)
        {
                //   taunt = 4;
           
                idCelu = 2;
            FindObjectOfType<Knight2>().Neighbours();

            if (row == knight_1_row + 1 && column == knight_1_column || row == knight_1_row - 1 && column == knight_1_column
                || row == knight_1_row && column == knight_1_column + 1 || row == knight_1_row && column == knight_1_column - 1)
            {
                FindObjectOfType<Controller>().AllyRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();
                find = true;
                    taunt = 0;

                }
                else if (row > knight_1_row && Controller.pole[2] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, knight_1_column, knight_1_row + 1, id);
                find = true;
                    taunt = 0;

                }
                else if (column > knight_1_column && Controller.pole[3] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, knight_1_column + 1, knight_1_row, id);
                find = true;
                    taunt = 0;

                }
                //  else if (column < knight_1_column && Controller.pole[1] == '0')
                else if (Controller.pole[1] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, knight_1_column - 1, knight_1_row, id);
                find = true;
                    taunt = 0;

                }
                //    else if (row < knight_1_row && Controller.pole[0] == '0')
                else if (Controller.pole[0] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, knight_1_column, knight_1_row - 1, id);
                find = true;
                    taunt = 0;

                }





            }
        if (stalker_1_row != 100 && find == false && taunt == 0)
        {
            idCelu = 1;
            FindObjectOfType<Knight1>().Neighbours();
            if (row == stalker_1_row + 1 && column == stalker_1_column || row == stalker_1_row - 1 && column == stalker_1_column
                || row == stalker_1_row && column == stalker_1_column + 1 || row == stalker_1_row && column == stalker_1_column - 1)
            {
                FindObjectOfType<Controller>().AllyRangeOfAttack(column, row, dmg, id, idCelu);
                Enemy();
                find = true;

            }
            else if (row > stalker_1_row && Controller.pole[2] == '0')
            {


                FindObjectOfType<MovementE>().Move(column, row, stalker_1_column, stalker_1_row + 1, id);
                find = true;

            }
            else if (column > stalker_1_column && Controller.pole[3] == '0')
            {

                FindObjectOfType<MovementE>().Move(column, row, stalker_1_column + 1, stalker_1_row, id);
                find = true;

            }
            //   else if (column < stalker_1_column && Controller.pole[1] == '0')
            else if ( Controller.pole[1] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, stalker_1_column - 1, stalker_1_row, id);
                find = true;

            }
            // else if (row < stalker_1_row && Controller.pole[0] == '0')
            else if (Controller.pole[0] == '0')
            {
                FindObjectOfType<MovementE>().Move(column, row, stalker_1_column, stalker_1_row - 1, id);
                find = true;

            }





        }
            if (taunt == 1 || taunt == 2)
            {
                Invoke("EndOfTurn", 0.5f);   // ????

            }
        }
        else
        {
            Invoke("EndOfTurn", 0.5f);

        }
        taunt = 0;

        stun = false;
    }

    void EndOfTurn()
    {
        FindObjectOfType<EndOfTurn>().Change();

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
    public IEnumerator Death2()
    {
        
        // animator.SetTrigger("Idle2");
        if (rotation == 2)
        {
            yield return new WaitForSeconds(0.3f);
            animator.SetTrigger("idle");

            animator.SetTrigger("death4");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().sDeath();

            yield return new WaitForSeconds(0.8f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle4");

        }
        else if (rotation == 1)
        {
            yield return new WaitForSeconds(0.3f);
            animator.SetTrigger("idle");

            animator.SetTrigger("death2");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().sDeath();

            yield return new WaitForSeconds(0.8f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle2");  //2


        }
        else if (rotation == 4)
        {
            yield return new WaitForSeconds(0.3f);
            animator.SetTrigger("idle");

            animator.SetTrigger("death3");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().sDeath();

            yield return new WaitForSeconds(0.8f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle3");

        }
        else if (rotation == 3)
        {
            yield return new WaitForSeconds(0.3f);
            animator.SetTrigger("idle");

            animator.SetTrigger("death1");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().sDeath();

            yield return new WaitForSeconds(0.8f);
            animator.SetTrigger("idle");
            animator.SetTrigger("idle1");

        }

        transform.position = new Vector3((float)99.85, (float)14.12, 8);

        //  Destroy(gameObject);


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
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().sHurt();

            yield return new WaitForSeconds(0.6f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle4");
        }
        else if (rotation == 1)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("hurt2");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().sHurt();

            yield return new WaitForSeconds(0.6f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle2");  //2
        }
        else if (rotation == 4)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("hurt3");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().sHurt();

            yield return new WaitForSeconds(0.6f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle3");
        }
        else if (rotation == 3)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("idle");

            animator.SetTrigger("hurt1");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().sHurt();

            yield return new WaitForSeconds(0.6f);
            animator.SetTrigger("idle");
            animator.SetTrigger("idle1");
        }
    }
    public IEnumerator Animation(int rotation)
    {
        FindObjectOfType<Audio>().sAttack();

        if (rotation == 1)
        {
            animator.SetTrigger("idle");
            transform.Translate(new Vector3(0.3f, 0.1f, 0f).normalized * 0.63f);

            animator.SetTrigger("attack3");
            yield return new WaitForSeconds(0.7f);
            transform.Translate(new Vector3(-0.3f, -0.1f, 0f).normalized * 0.63f);

            animator.SetTrigger("idle");

            animator.SetTrigger("idle3");

        }

        else if (rotation == 2)
        {
            animator.SetTrigger("idle");
            yield return new WaitForSeconds(0.01f);
            transform.Translate(new Vector3(0.7f, -1f, 0f).normalized * 0.7f);

            animator.SetTrigger("attack1");
            yield return new WaitForSeconds(0.7f);
            transform.Translate(new Vector3(-0.7f, 1f, 0f).normalized * 0.7f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle1");
        }
        else if (rotation == 3)
        {
            animator.SetTrigger("idle");
            //  transform.Translate(new Vector3(0, -1f, 0f).normalized * 0.1f);
            animator.SetTrigger("attack4"); //4
            yield return new WaitForSeconds(0.85f);
            //  transform.Translate(new Vector3(0, 1f, 0f).normalized * 0.10f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle4");//4
        }
        else if (rotation == 4)
        {
            animator.SetTrigger("idle");
            //  transform.Translate(new Vector3(-0.3f, -1f, 0f).normalized * 0.15f);
            animator.SetTrigger("attack2");
            transform.Translate(new Vector3(-0.9f, -0.51f, 0f).normalized * 0.9f);

            yield return new WaitForSeconds(0.7f);

            transform.Translate(new Vector3(0.9f, 0.51f, 0f).normalized * 0.9f);
            //  transform.Translate(new Vector3(0.3f, 1f, 0f).normalized * 0.15f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle2");  //2
        }



    }
    public void DamageTaken(int dmg, int idGracza)
    {

        if (idGracza == 1)
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
        }
        else if (idGracza == 2)
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

        //    kolorObiekt.Kolor();

        }


    }
    public IEnumerator Movement()
    {
        FindObjectOfType<Audio>().sWalk();

        //    Debug.Log("????????????????????????????????");
        // Debug.Log(row + "  " + column);

        if (howManyMoves != 0)
        {
            animator.SetTrigger("idle");

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

            FindObjectOfType<Controller>().AllyRangeOfAttack(column, row, dmg, id, idCelu);
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
        }
        else
        {
            FindObjectOfType<Audio>().Stop();

            Controller.ende = false;
            FindObjectOfType<Controller>().AllyRangeOfAttack(column, row, dmg, id, idCelu);
            Enemy();
            //  animator.SetTrigger("idle1");
            if (Controller.ende == true)
            {

            }
            else
            {
                animator.SetTrigger("idle");

                animator.SetTrigger("idle1");

            }

        }


        //    firstMove = true;
        ButtonMovement.blockade = true;


        howManyMoves = 0;

    }
    /*
    public IEnumerator Movement()
    {
        FindObjectOfType<Audio>().sWalk();
        // Debug.Log(row + "  " + column);


        animator.SetTrigger("idle");

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

        FindObjectOfType<Controller>().AllyRangeOfAttack(column, row, dmg, id, idCelu);
        Enemy();

        if (howManyMoves > 0)
        {

            if (tablica[howManyMoves - 1] == '1')
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
    */
}