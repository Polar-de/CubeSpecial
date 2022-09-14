using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class balance : MonoBehaviour
{
    [SerializeField] int BalanceNumber; // 10e aufladung
    [SerializeField] object charge; // button

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick()
    {
        BalanceNumber+=10;
        Debug.Log($"count: {BalanceNumber += 10}");

    }


}
