using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartCard : MonoBehaviour
{
    [SerializeField] GameObject Card;
    private bool active;

    void Start()
    {
        Card.SetActive(active); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            active = !active;
            Card.SetActive(active);
        }
    }

}
