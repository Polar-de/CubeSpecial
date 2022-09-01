using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geldschein : MonoBehaviour
{
    [SerializeField] GameObject Money;
    [SerializeField] GameObject Money2;
    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        Money.SetActive(active);
        Money2.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            active = !active;
            Money.SetActive(active);
            Money2.SetActive(active);
        }
    }
}
