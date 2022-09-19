using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [Header("wallet")]
    [SerializeField] private float cash;
    [SerializeField] private float moneyOnCard;
    // ReSharper disable InconsistentNaming
    private float price;
    /* UI-Charger */
    private float chargeAmount;
    private float newBalance;

    public float Cash { get; set; }
    public float MoneyOnCard { get; set; }
    public float Price { get; set; }
 
    public float ChargeAmount { get; set; }
    public float NewBalance { get; set; }
}
