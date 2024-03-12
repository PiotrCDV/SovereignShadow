using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obrazek : MonoBehaviour
{
    public Sprite[] Sprites;

    public static int numer = 0;
    bool grounded;
    int z = 90;
    public static bool ChangeZ = false;
    void Start()
    {
        numer = Kontroler.obr;
      //  Debug.Log(numer + "??");

        ChangeSprite();
        Debug.Log("testt");
    }

    void Update()
    {
        if (ChangeZ == true)
        {
            ChangeZ = false;
            Debug.Log("??");
        }

    }
    void ChangeSprite()
    {
        var renderer = GetComponent<SpriteRenderer>();

        renderer.sprite = Sprites[numer];
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            grounded = true;
            
        }
        else
        {
            grounded = false;

        }

    
    }
    public void Ready()
    {
        Debug.Log(grounded + " start "  + ChangeZ);
        if (grounded == true && ChangeZ == true)
        {
            Debug.Log("?????????????????????");
            GetComponent<Collider2D>().enabled = false;
            //Vector3 newPosition = transform.();
            //   newPosition.z = z;
            //  transform.position = newPosition;
        }
        else
        {
         //   GetComponent<Collider2D>().enabled = true;

        }

    }




}
