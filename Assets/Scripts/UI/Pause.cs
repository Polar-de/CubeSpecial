using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{ 
    [SerializeField] Button continueButton;
    [SerializeField] Button menuButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button beendenButton;

    private GameManager gameManager;
    private GameData _gameData;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _gameData = FindObjectOfType<GameData>();

        _gameData.isInGame = false;
        Cursor.lockState = CursorLockMode.Confined;
        
        continueButton.onClick.AddListener(Continue);
        menuButton.onClick.AddListener(LoadMenuScene);
        optionsButton.onClick.AddListener(LoadOptionsScene);
        beendenButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Continue()
    {
        SceneManager.UnloadSceneAsync("Pause");
        _gameData.isInGame = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void LoadMenuScene()
    {
        gameManager.LoadScene("MainMenuUI");
        SceneManager.UnloadSceneAsync("GameScene");
    }

    private void LoadOptionsScene()
    {
        gameManager.LoadScene("OptionenInGame");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
