using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpbars : MonoBehaviour
{
    public Slider sliders;
    public void SetMaxHealthS(int health)
    {
        sliders.maxValue = health;
        sliders.value = health;
    }
    public void SetHealthS(int health)
    {
        sliders.value = health;
    }
}
