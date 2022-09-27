using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Intro : MonoBehaviour
{
    [SerializeField] Button continueButton;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        continueButton.onClick.AddListener(LoadTestScene);
    }

    // Update is called once per frame
    private void LoadTestScene()
    {
        gameManager.LoadScene("TestScene");
    } 
}
