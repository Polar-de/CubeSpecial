using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private float cash;
    [SerializeField] private float moneyOnCard;
    
    public float Cash { get; set; }
    public float MoneyOnCard { get; set; }
}
