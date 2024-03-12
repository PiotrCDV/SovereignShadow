using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight3 : MonoBehaviour
{
    float z = (float)-3.97;
    static public int column = 3;
    static public int row = 0;
    static public int column2 = 3;
    static public int row2 = 0;
    private bool move = false;
    private Animator animator;
    public static bool start = false;
    public static bool blockade = true;
    public float distanceToMove = 0.5f;
    public float timeMove = 2.0f;
    private Vector3 startPosition;
    private Vector3 destination;
    private float startTime;
    public static int howManyMoves = 0;
    public new Collider2D collider;
    int id = 3;
    public static int death = 0;

    bool firstMove = false;
    public static int rotation = 0;
    public int maxHealth = 12;
    public int currentHealth;
    public hpbar healthBar;
    public hpbars healthBarHeart;
    private Knight4 knight4;
    private Knight5 knight5;
    private ESerf1 eserf1;
    private ESerf2 eserf2;
    private Enemy1 enemy1;
    public static string tablica = "";
    public static int dmg = 3;
    private DictionaryC klasaZDictionary;
    string test;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = false;

        animator = GetComponent<Animator>();
        animator.SetTrigger("Idle22");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBarHeart.SetMaxHealthS(maxHealth);

        Position();

        Id();
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
    public void Neighbours()
    {
        FindObjectOfType<Controller>().Neighbours(column, row);

    }
    public void Position()
    {
        Enemy1.knight_2_column = column;
        Enemy1.knight_2_row = row;
        Knight5.knight_2_column = column;
        Knight5.knight_2_row = row;
        Knight4.knight_2_column = column;
        Knight4.knight_2_row = row;
        ESerf1.knight_2_column = column;
        ESerf1.knight_2_row = row;
        ESerf2.knight_2_column = column;
        ESerf2.knight_2_row = row;
    }

    public void ColliderOff()
    {
        collider.enabled = false;

    }
    public void ColliderOn()
    {
        collider.enabled = false;

    }
    public void StalkerNei()
    {
        FindObjectOfType<Controller>().StalkerNei(column, row);

    }
    public void Button()
    {

        FindObjectOfType<Movement>().Range(id, column, row);


    }
    public void MyRound()
    {
        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();


        test = "P" + row + column;

        if (dictionaryTypes.ContainsKey(test))
        {
            Type typ = dictionaryTypes[test];
            object obiekt = FindObjectOfType(typ);
            Pole kolorObiekt = (Pole)obiekt;

            kolorObiekt.round = true;



        }
    }
    public void Ult()
    {
        FindObjectOfType<Controller>().RangeOfUltKnight(column, row, id);

    }
    public void Attack()
    {
        FindObjectOfType<Controller>().RangeOfAttack(column, row, dmg, id);
    }
    public void Id()
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



        }


    }
    public IEnumerator Death2()
    {

        // animator.SetTrigger("Idle2");
        if (rotation == 2)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("death4");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().kDeath();

            yield return new WaitForSeconds(1.7f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle4");
        }
        else if (rotation == 1)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("death2");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().kDeath();

            yield return new WaitForSeconds(1.7f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle2_2");
        }
        else if (rotation == 4)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("death3");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().kDeath();

            yield return new WaitForSeconds(1.7f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle22");
        }
        else if (rotation == 3)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("death1");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().kDeath();

            yield return new WaitForSeconds(1.7f);
            animator.SetTrigger("Idle2");
            animator.SetTrigger("Idle1");
        }
        Destroy(gameObject);


    }
    public void DamageTaken(int dmg, int idGracza)
    {

        Debug.Log(idGracza + " !!!!!!!!!!!!");
        if (idGracza == 7)
        {
            if (currentHealth - dmg > 0)
            {
                StartCoroutine("Hurt2");

            }
            else
            {
                StartCoroutine("Death2");

            }

            knight4 = FindObjectOfType<Knight4>();

            StartCoroutine(knight4.Animation(rotation));
        }
        else if (idGracza == 8)
        {
            if (currentHealth - dmg > 0)
            {
                StartCoroutine("Hurt2");

            }
            else
            {
                StartCoroutine("Death2");

            }

            knight5 = FindObjectOfType<Knight5>();

            StartCoroutine(knight5.Animation(rotation));

        }
        else if (idGracza == 6)
        {
            if (currentHealth - dmg > 0)
            {
                StartCoroutine("Hurt2");

            }
            else
            {
                StartCoroutine("Death2");

            }

            enemy1 = FindObjectOfType<Enemy1>();

            StartCoroutine(enemy1.Animation(rotation));

        }
        else if (idGracza == 5)
        {
            // StartCoroutine("Hurt2");
            if (currentHealth - dmg > 0)
            {
                StartCoroutine("Hurt2");

            }
            else
            {
                StartCoroutine("Death2");

            }


            eserf1 = FindObjectOfType<ESerf1>();

            StartCoroutine(eserf1.Animation(rotation));

        }
        else if (idGracza == 9)
        {
            //  StartCoroutine("Hurt2");
            if (currentHealth - dmg > 0)
            {
                StartCoroutine("Hurt2");

            }
            else
            {
                StartCoroutine("Death2");

            }


            eserf2 = FindObjectOfType<ESerf2>();

            StartCoroutine(eserf2.Animation(rotation));

        }




        //  Debug.Log(dmg + "dsds " + idGracza);
        Takendmg(dmg);
        Death();

    }
    public void Death()
    {

        Debug.Log(death + " death!!!!!");

        if (currentHealth <= 0)
        {
            Kontroler.k--;

            row = 100;
            Position();
            IsDead.dead_units = IsDead.dead_units + 3;

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
    public IEnumerator AnimationUlt(int rotation)
    {
        ButtonAttack.blockade2 = false;
        EndOfTurn.blockade = false;

        ButtonUlt.blockade = false;
        ButtonMovement.blockade = false;
        FindObjectOfType<Audio>().kAttack();

        if (rotation == 1)
        {
            animator.SetTrigger("Idle2");
            animator.SetTrigger("ability3");
            yield return new WaitForSeconds(1.60f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle1");

        }

        else if (rotation == 2)
        {
            animator.SetTrigger("Idle2");
            yield return new WaitForSeconds(0.01f);
            transform.Translate(new Vector3(1f, 0, 0f).normalized * 0.3f);

            animator.SetTrigger("ability1");
            yield return new WaitForSeconds(1.60f);
            transform.Translate(new Vector3(-1f, 0, 0f).normalized * 0.3f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle2_2");
        }
        else if (rotation == 3)
        {
            animator.SetTrigger("Idle2");
            transform.Translate(new Vector3(0, -1f, 0f).normalized * 0.1f);
            animator.SetTrigger("ability4");
            yield return new WaitForSeconds(1.60f);
            transform.Translate(new Vector3(0, 1f, 0f).normalized * 0.10f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle22");
        }
        else if (rotation == 4)
        {
            animator.SetTrigger("Idle2");
            transform.Translate(new Vector3(-0.3f, -1f, 0f).normalized * 0.15f);
            animator.SetTrigger("ability2");  //4
            yield return new WaitForSeconds(1.60f);
            transform.Translate(new Vector3(0.3f, 1f, 0f).normalized * 0.15f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle4");
        }

        EndOfTurn.blockade = true;

        ButtonAttack.blockade2 = true;

    }
    public void Takendmg(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        healthBarHeart.SetHealthS(currentHealth);
    }
    public IEnumerator Hurt2()
    {

        // animator.SetTrigger("Idle2");
        if (rotation == 3)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Hurt2");

            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().kHurt();
            yield return new WaitForSeconds(1.4f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle2_2");
        }
        else if (rotation == 1)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Hurt4");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().kHurt();
            yield return new WaitForSeconds(1.4f); 
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle4");
        }
        else if (rotation == 4)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Hurt3");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().kHurt();
            yield return new WaitForSeconds(1.4f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle1");
        }
        else if (rotation == 2)
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Hurt1");
            yield return new WaitForSeconds(0.2f);

            FindObjectOfType<Audio>().kHurt();
            yield return new WaitForSeconds(1.4f);
            animator.SetTrigger("Idle2");
            animator.SetTrigger("Idle22");
        }

    }
    public IEnumerator Animation(int rotation)
    {
        ButtonUlt.blockade2 = false;
        EndOfTurn.blockade = false;

        ButtonAttack.blockade = false;
        ButtonMovement.blockade = false;
        FindObjectOfType<Audio>().kAttack();

        if (rotation ==1)
        {
            animator.SetTrigger("Idle2");
            animator.SetTrigger("Attack3"); 
            yield return new WaitForSeconds(1.60f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle1");
        }    /*else if(rotation ==2) 
           {
           animator.SetTrigger("Idle2");
           transform.Translate(new Vector3(1f, 0, 0f).normalized * 0.3f);
           animator.SetTrigger("Attack2");
           yield return new WaitForSeconds(1.60f);
           transform.Translate(new Vector3(-1f, 0, 0f).normalized * 0.3f);
           animator.SetTrigger("Idle2");

           animator.SetTrigger("Idle2_2");
       }*/
        else if (rotation == 2)
            {
                animator.SetTrigger("Idle2");
                yield return new WaitForSeconds(0.01f);
                transform.Translate(new Vector3(1f, 0, 0f).normalized * 0.3f);

                animator.SetTrigger("Attack2");
                yield return new WaitForSeconds(1.60f);
                transform.Translate(new Vector3(-1f, 0, 0f).normalized * 0.3f);
                animator.SetTrigger("Idle2");

                animator.SetTrigger("Idle2_2");
            }
        else if (rotation == 3)
        {
            animator.SetTrigger("Idle2");
            transform.Translate(new Vector3(0, -1f, 0f).normalized * 0.1f);
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(1.60f);
            transform.Translate(new Vector3(0, 1f, 0f).normalized * 0.10f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle22");
        }
        else if (rotation == 4)
        {
            animator.SetTrigger("Idle2");
            transform.Translate(new Vector3(-0.3f, -1f, 0f).normalized * 0.15f);
            animator.SetTrigger("Attack4");  //4
            yield return new WaitForSeconds(1.60f);
            transform.Translate(new Vector3(0.3f, 1f, 0f).normalized * 0.15f);
            animator.SetTrigger("Idle2");

            animator.SetTrigger("Idle4");
        }


        ButtonUlt.blockade2 = true;
        EndOfTurn.blockade = true;

    }
    public IEnumerator Movement()
    {

        FindObjectOfType<Audio>().kWalk();

        ButtonAttack.blockade = false;
        ButtonUlt.blockade = false;
        ButtonMovement.blockade = false;
        EndOfTurn.blockade = false;
        animator.SetTrigger("Idle2");
        
        for (int i = 0; i < howManyMoves; i++)
        {

            if (tablica[i] == '1')
            {

                //animator.SetTrigger("Idle");
                //    Debug.Log("Up");
                z = (float)(z + 0.01);
                //  animator.SetTrigger("Idle2");
                animator.SetTrigger("StartWalk1");
                move = true;
                startPosition = transform.position;
                destination = startPosition + new Vector3(0.85f, 0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");
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
                animator.SetTrigger("StartWalk2");
                move = true;
                startPosition = transform.position;
                destination = startPosition + new Vector3(0.85f, -0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");
                // animator.SetTrigger("Idle22");


            }
            else if (tablica[i] == '3')
            {

                z = (float)(z + 0.0001);
                //   Debug.Log("Left");
                //   animator.SetTrigger("Idle2");
                animator.SetTrigger("StarWalk3");
                //     Debug.Log("lewo");
                move = true;
                startPosition = transform.position;
                destination = startPosition + new Vector3(-0.85f, 0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");
                // animator.SetTrigger("Idle1");

                //   animator.SetTrigger("Idle3");
            }
            else if (tablica[i] == '4')
            {
                z = (float)(z - 0.01);
                //  animator.SetTrigger("Idle");
                //Debug.Log("Down");
                //  animator.SetTrigger("Idle2");
                animator.SetTrigger("StartWalk4");
                move = true;

                startPosition = transform.position;
                destination = startPosition + new Vector3(-0.85f, -0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");
                //     animator.SetTrigger("Idle4");
            }


         
        }
        Position();

        Id();
        FindObjectOfType<Audio>().Stop();

        if (tablica[howManyMoves - 1] == '1')
            animator.SetTrigger("Idle1");

        if (tablica[howManyMoves - 1] == '2')
            animator.SetTrigger("Idle2_2");

        if (tablica[howManyMoves - 1] == '3')
            animator.SetTrigger("Idle22");

        if (tablica[howManyMoves - 1] == '4')
            animator.SetTrigger("Idle4");


        firstMove = true;
        EndOfTurn.blockade = true;

       // ButtonMovement.blockade = true;
        ButtonAttack.blockade = true;
        ButtonUlt.blockade = true;

        howManyMoves = 0;

    }



}
