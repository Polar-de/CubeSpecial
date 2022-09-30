using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Intro : MonoBehaviour
{
    [SerializeField] Button continueButton;

    private GameManager gameManager;

    private GameData _gameData;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameData>();
        gameManager = FindObjectOfType<GameManager>();
        _gameData = FindObjectOfType<GameData>();
        continueButton.onClick.AddListener(LoadGame);
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSecondsRealtime(15f);
        _gameData.isInGame = true;
        gameManager.LoadScene("GameScene");
    }
    
    // Update is called once per frame
    private void LoadGame()
    {
        _gameData.isInGame = true;
        gameManager.LoadScene("GameScene");
    } 
}
