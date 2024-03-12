using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class P13 : MonoBehaviour, Pole
{


    private SpriteRenderer spriteRenderer;
    public Color kolor1 = Color.white;
    public Color kolor2 = Color.green;
    public Color kolor3 = Color.blue;
    public Color kolor4 = Color.red;
    public Color kolor5 = Color.black;
    public Color kolor6 = Color.gray;
    public Color kolor8 = Color.cyan;
    public bool ult { get; set; }
    public bool round { get; set; }
    public bool ult2 { get; set; }
    public bool enemy { get; set; }
    public bool ult3 { get; set; }

    public int dmg { get; set; }
    public int idGracza { get; set; }
    public bool ally { get; set; }
    public bool pom { get; set; }
    public bool pole { get;  set; }
    public bool pole2 { get; set; }
    public bool enemy2 { get; set; }
    public int id { get; set; }

    public bool green { get; set; }
    int kolumna = 3;
    int wiersz = 1;
    void Start()
    {
        pole2 = true;

        pole = false;

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (Knight1.column == kolumna && Knight1.row == wiersz || Knight2.column == kolumna && Knight2.row == wiersz
           || Knight3.column == kolumna && Knight3.row == wiersz || Serf1.column == kolumna && Serf1.row == wiersz
           || Serf2.column == kolumna && Serf2.row == wiersz)
        {
            pole2 = false;
            GetComponent<BoxCollider2D>().enabled = false;
            if (round == true)
            {
                spriteRenderer.color = kolor8;

            }
            else
            {
                spriteRenderer.color = kolor3;

            }
            pom = true;
        }
        else if (ult == true || ult2 == true || enemy2 == true || ult3 == true)
        {
            pole2 = false;

            GetComponent<BoxCollider2D>().enabled = true;
            enemy = true;
            spriteRenderer.color = kolor6;

        }
        else if (Knight4.stun == true && Knight4.column == kolumna && Knight4.row == wiersz ||
           Knight5.stun == true && Knight5.column == kolumna && Knight5.row == wiersz
           || Enemy1.stun == true && Enemy1.column == kolumna && Enemy1.row == wiersz
           || ESerf1.stun == true && ESerf1.column == kolumna && ESerf1.row == wiersz
           || ESerf2.stun == true && ESerf2.column == kolumna && ESerf2.row == wiersz)
        {
            pole2 = false;

            GetComponent<BoxCollider2D>().enabled = true;
            enemy = true;
            spriteRenderer.color = kolor5;

        }
        else if (Enemy1.column == kolumna && Enemy1.row == wiersz || Knight4.column == kolumna && Knight4.row == wiersz
               || Knight5.column == kolumna && Knight5.row == wiersz || ESerf1.column == kolumna && ESerf1.row == wiersz
                || ESerf2.column == kolumna && ESerf2.row == wiersz)
        {
            pole2 = false;

            GetComponent<BoxCollider2D>().enabled = true;
            enemy = true;
            spriteRenderer.color = kolor4;
        }
        else if (spriteRenderer.color != kolor2)
        {
            pole2 = true;

            GetComponent<BoxCollider2D>().enabled = true;

            spriteRenderer.color = kolor1;
            pom = false;
            enemy = false;

        }
       

        if (ally)
        {
            if (id == 1)
            {
                FindObjectOfType<Controller>().Position(kolumna, wiersz);

                enemy2 = false;
                FindObjectOfType<Knight1>().DamageTaken(dmg, idGracza);

                FindObjectOfType<Controller>().EndOfAttackAlly();
            }
            else if (id == 2)
            {
                FindObjectOfType<Controller>().Position(kolumna, wiersz);
                enemy2 = false;
                FindObjectOfType<Knight2>().DamageTaken(dmg, idGracza);

                FindObjectOfType<Controller>().EndOfAttackAlly();

            }
            else if (id == 3)
            {
                FindObjectOfType<Controller>().Position(kolumna, wiersz);
                enemy2 = false;
                FindObjectOfType<Knight3>().DamageTaken(dmg, idGracza);

                FindObjectOfType<Controller>().EndOfAttackAlly();

            }
            else if (id == 0)
            {
                FindObjectOfType<Controller>().Position(kolumna, wiersz);
                enemy2 = false;
                FindObjectOfType<Serf1>().DamageTaken(dmg, idGracza);

                FindObjectOfType<Controller>().EndOfAttackAlly();
            }
            else if (id == 4)
            {
                FindObjectOfType<Controller>().Position(kolumna, wiersz);
                enemy2 = false;
                FindObjectOfType<Serf2>().DamageTaken(dmg, idGracza);

                FindObjectOfType<Controller>().EndOfAttackAlly();
            }



        }
    }


    private void OnMouseDown()
    {
        if (ult2 == true)
        {

            if (id == 8)
            {
                FindObjectOfType<Controller>().PositionUlt(kolumna, wiersz);
                FindObjectOfType<Knight5>().TauntUlt(idGracza);
                FindObjectOfType<Controller>().EndOfUltStalker();



            }
            else if (id == 7)
            {

                FindObjectOfType<Controller>().PositionUlt(kolumna, wiersz);

                FindObjectOfType<Knight4>().TauntUlt(idGracza);
                FindObjectOfType<Controller>().EndOfUltStalker();

            }
            else if (id == 6)
            {
                FindObjectOfType<Controller>().PositionUlt(kolumna, wiersz);
                FindObjectOfType<Enemy1>().TauntUlt(idGracza);
                FindObjectOfType<Controller>().EndOfUltStalker();

            }
            else if (id == 5)
            {
                FindObjectOfType<Controller>().PositionUlt(kolumna, wiersz);
                FindObjectOfType<ESerf1>().TauntUlt(idGracza);
                FindObjectOfType<Controller>().EndOfUltStalker();

            }
            else if (id == 9)
            {
                FindObjectOfType<Controller>().PositionUlt(kolumna, wiersz);
                FindObjectOfType<ESerf2>().TauntUlt(idGracza);
                FindObjectOfType<Controller>().EndOfUltStalker();

            }
        }
        if (ult == true)
        {
            // spriteRenderer.color = kolor6;

            if (id == 8)
            {
                FindObjectOfType<Controller>().PositionUlt(kolumna, wiersz);
                FindObjectOfType<Knight5>().DamageTakenUlt(2, idGracza);
                FindObjectOfType<Controller>().EndOfUltStalker();

                Knight5.stun = true;


            }
            else if (id == 7)
            {
                FindObjectOfType<Controller>().PositionUlt(kolumna, wiersz);
                FindObjectOfType<Knight4>().DamageTakenUlt(2, idGracza);
                FindObjectOfType<Controller>().EndOfUltStalker();

                Knight4.stun = true;

            }
            else if (id == 6)
            {
                FindObjectOfType<Controller>().PositionUlt(kolumna, wiersz);
                FindObjectOfType<Enemy1>().DamageTakenUlt(2, idGracza);
                FindObjectOfType<Controller>().EndOfUltStalker();

                Enemy1.stun = true;

            }
            else if (id == 5)
            {
                FindObjectOfType<Controller>().PositionUlt(kolumna, wiersz);
                FindObjectOfType<ESerf1>().DamageTakenUlt(2, idGracza);
                FindObjectOfType<Controller>().EndOfUltStalker();

                ESerf1.stun = true;

            }
            else if (id == 9)
            {
                FindObjectOfType<Controller>().PositionUlt(kolumna, wiersz);
                FindObjectOfType<ESerf2>().DamageTakenUlt(2, idGracza);
                FindObjectOfType<Controller>().EndOfUltStalker();

                ESerf2.stun = true;

            }
        }
        if (pole == true)
        {
            FindObjectOfType<Movement>().Move(kolumna, wiersz, enemy);
        }
        if (enemy2 == true)
        {
            if (id == 8)
            {
                FindObjectOfType<Controller>().Position(kolumna, wiersz);
                FindObjectOfType<Knight5>().DamageTaken(dmg, idGracza);


            }
            else if (id == 7)
            {
                FindObjectOfType<Controller>().Position(kolumna, wiersz);
                FindObjectOfType<Knight4>().DamageTaken(dmg, idGracza);

            }
            else if (id == 6)
            {
                FindObjectOfType<Controller>().Position(kolumna, wiersz);
                FindObjectOfType<Enemy1>().DamageTaken(dmg, idGracza);

            }
            else if (id == 5)
            {
                FindObjectOfType<Controller>().Position(kolumna, wiersz);
                FindObjectOfType<ESerf1>().DamageTaken(dmg, idGracza);

            }
            else if (id == 9)
            {
                FindObjectOfType<Controller>().Position(kolumna, wiersz);
                FindObjectOfType<ESerf2>().DamageTaken(dmg, idGracza);

            }
            FindObjectOfType<Controller>().EndOfAttack();
        }

    }
    public void Kolor()
    {
        if (green)
        {
            spriteRenderer.color = kolor2;

        }
        else
        {
            pole = false;
            spriteRenderer.color = kolor1;

        }

    }

}