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
}
