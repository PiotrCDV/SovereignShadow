using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obrazek0 : MonoBehaviour
{
    public Sprite[] Sprites;

  //  public static int numer = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public  void ChangeSprite(int numer)
    {
        var renderer = GetComponent<SpriteRenderer>();

        renderer.sprite = Sprites[numer];
                        transform.position = new Vector3((float)9.85, (float)-1.86, -80);
        GetComponent<Collider2D>().enabled = true;

    }
    public void Ready()
    {

            GetComponent<Collider2D>().enabled = false;

      

    }
}