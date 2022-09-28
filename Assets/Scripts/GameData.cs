using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public float Cash { get; set; }
    public float MoneyOnCard { get; set; }
    public float Price { get; set; }
 
    public float ChargeAmount { get; set; }
    public float NewBalance { get; set; }

    private void Start()
    {
        Cash = 20f;
    }

    public bool hasTablet;
    
    public bool mainCourse;
    public bool sideDish;
    public bool appetizer;
    public bool dessert;
    public bool drink;
    
    public bool payed;

    public int questID;
}
