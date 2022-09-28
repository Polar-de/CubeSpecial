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
        continueButton.onClick.AddListener(LoadGame);
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSecondsRealtime(15f);
        gameManager.LoadScene("GameScene");
    }
    
    // Update is called once per frame
    private void LoadGame()
    {
        gameManager.LoadScene("GameScene");
    } 
}
