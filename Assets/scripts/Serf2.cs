using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serf2 : MonoBehaviour
{
    float z = (float)-3.9599;

    bool firstMove = false;
    static public int column = 4;
    static public int row = 1;
    static public int column2 = 4;
    static public int row2 = 1;
    private bool move = false;
    private Animator animator;
    public static bool start = false;
    // public static bool blockade = true;
    public float distanceToMove = 0.5f;
    public float timeMove = 2.0f;
    private Vector3 startPosition;
    private Vector3 destination;
    private float startTime;
    public static int howManyMoves = 0;
    public new Collider2D collider;
    int id = 4;
    public static string tablica = "";
    int dmg = 3;
    public int maxHealth = 9;
    public int currentHealth;
    public hpbar healthBar;
    public hpbars healthBarHeart;
    public static int rotation = 0;
    private Knight4 knight4;
    private Knight5 knight5;
    private ESerf1 eserf1;
    private ESerf2 eserf2;
    private Enemy1 enemy1;
    private DictionaryC klasaZDictionary;
    string test;
    public static int death = 0;
    int idle = 0;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = false;

        animator = GetComponent<Animator>();
        animator.SetTrigger("idle4");
        idle = 4;
        Position();

        Id();





        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBarHeart.SetMaxHealthS(maxHealth);
    }


    void Update()
    {

        // Debug.Log(row +"  " + column);
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
        Enemy1.serf_2_column = column;
        Enemy1.serf_2_row = row;
        Knight5.serf_2_column = column;
        Knight5.serf_2_row = row;
        Knight4.serf_2_column = column;
        Knight4.serf_2_row = row;
        ESerf1.serf_2_column = column;
        ESerf1.serf_2_row = row;
        ESerf2.serf_2_column = column;
        ESerf2.serf_2_row = row;
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
        StartCoroutine("AnimationUlt");

        Debug.Log(dmg + " sdsdddd");
        dmg =  4;
        Debug.Log(dmg + " sdsdddd");

    }
    public void ColliderOff()
    {
        collider.enabled = false;

    }
    public void ColliderOn()
    {
        collider.enabled = false;

    }
    public void Button()
    {

        FindObjectOfType<Movement>().Range(id, column, row);


    }
    public void StalkerNei()
    {
        FindObjectOfType<Controller>().StalkerNei(column, row);

    }
    public void Attack()
    {
        FindObjectOfType<Controller>().RangeOfAttack(column, row, dmg, id);
    }
    // public void DamageTaken(int dmg, int idGracza)
    // {





    //     Debug.Log(dmg + " sdsdsds");

    //    Takendmg(dmg);

    // }
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
    public IEnumerator AnimationUlt()
    {
        FindObjectOfType<Audio>().sAttack();
        EndOfTurn.blockade = false;

        ButtonUlt.blockade = false;
        ButtonAttack.blockade2 = false;

        ButtonMovement.blockade = false;
        int rotation = idle;
        //   ButtonMovement.blockade = true;
        //  ButtonMovement.blockade = true;

        if (rotation == 3)
        {
            animator.SetTrigger("idle");
            animator.SetTrigger("ability3");
            yield return new WaitForSeconds(1.05f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle3");

        }

        else if (rotation == 1)
        {
            animator.SetTrigger("idle");
            yield return new WaitForSeconds(0.01f);
            //   transform.Translate(new Vector3(1f, 0, 0f).normalized * 0.3f);

            animator.SetTrigger("ability1");
            yield return new WaitForSeconds(1.05f);
            //   transform.Translate(new Vector3(-1f, 0, 0f).normalized * 0.3f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle1");
        }
        else if (rotation == 4)
        {
            animator.SetTrigger("idle");
            //   transform.Translate(new Vector3(0, -1f, 0f).normalized * 0.1f);
            animator.SetTrigger("ability4");
            yield return new WaitForSeconds(1.05f);
            //   transform.Translate(new Vector3(0, 1f, 0f).normalized * 0.10f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle4");
        }
        else if (rotation == 2)
        {
            animator.SetTrigger("idle");
            //   transform.Translate(new Vector3(-0.3f, -1f, 0f).normalized * 0.15f);
            animator.SetTrigger("ability2");
            yield return new WaitForSeconds(1.05f);
            // transform.Translate(new Vector3(0.3f, 1f, 0f).normalized * 0.15f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle2");  //2
        }

        ButtonAttack.blockade2 = true;
        EndOfTurn.blockade = true;

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
            idle = 4;
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
            idle = 2;
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
            idle = 3;
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
            idle = 1;
        }
        //  Destroy(gameObject);
        transform.position = new Vector3((float)99.85, (float)14.12, 8);




    }
    public void DamageTaken(int dmg, int idGracza)
    {

      //  Debug.Log(idGracza + " !!!!!!!!!!!!");
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
        if (currentHealth <= 0)
        {
            Kontroler.k--;

            row = 100;
            Position();
            IsDead.dead_units = IsDead.dead_units + 4;

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
    public void Takendmg(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        healthBarHeart.SetHealthS(currentHealth);
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
            idle = 4;
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
            idle = 2;
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
            idle = 3;
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
            idle = 1;
        }
    }
    public IEnumerator Animation(int rotation)
    {

        //ButtonUlt.blockade = false;
        ButtonUlt.blockade2 = false;
        EndOfTurn.blockade = false;

        ButtonAttack.blockade = false;
        ButtonMovement.blockade = false;

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
            idle = 3;

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
            idle = 1;
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
            idle = 4;
        }
        else if (rotation == 4)
        {
            animator.SetTrigger("idle");
            //  transform.Translate(new Vector3(-0.3f, -1f, 0f).normalized * 0.15f);
            animator.SetTrigger("attack2");
            transform.Translate(new Vector3(-0.9f,-0.51f, 0f).normalized * 0.9f);

            yield return new WaitForSeconds(0.7f);

            transform.Translate(new Vector3(0.9f, 0.51f, 0f).normalized * 0.9f);
            //  transform.Translate(new Vector3(0.3f, 1f, 0f).normalized * 0.15f);
            animator.SetTrigger("idle");

            animator.SetTrigger("idle2");  //2
            idle = 2;
        }

        ButtonUlt.blockade2 = true;
        EndOfTurn.blockade = true;

    }
    public IEnumerator Movement()
    {

        FindObjectOfType<Audio>().sWalk();

        ButtonAttack.blockade = false;
        ButtonUlt.blockade = false;
        ButtonMovement.blockade = false;
        EndOfTurn.blockade = false;
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
        Id();
        Position();
        FindObjectOfType<Audio>().Stop();

        if (tablica[howManyMoves - 1] == '1')
        {
            animator.SetTrigger("idle3");

            idle = 3;

        }

        if (tablica[howManyMoves - 1] == '2')
        {
            animator.SetTrigger("idle1");

            idle = 1;

        }
        if (tablica[howManyMoves - 1] == '3')
        {
            animator.SetTrigger("idle4");

            idle = 4;

        }
        if (tablica[howManyMoves - 1] == '4')
        {
            animator.SetTrigger("idle2");

            idle = 2;

        }

        firstMove = true;
        EndOfTurn.blockade = true;

       // ButtonMovement.blockade = true;
        ButtonAttack.blockade = true;
        ButtonUlt.blockade = true;

        howManyMoves = 0;

    }


}
