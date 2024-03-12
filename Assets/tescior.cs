using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tescior : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;
    public hpbar healthBar;
    public hpbars healthBarHeart;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBarHeart.SetMaxHealthS(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Takendmg(5);
        }
    }
    void Takendmg(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        healthBarHeart.SetHealthS(currentHealth);
    }
}
