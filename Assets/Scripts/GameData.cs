using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [Header("wallet")]
    [SerializeField] private float cash;
    [SerializeField] private float moneyOnCard;
    // ReSharper disable once InconsistentNaming
    private float price;
    
    public float Cash { get; set; }
    public float MoneyOnCard { get; set; }
    public float Price { get; set; }
}
