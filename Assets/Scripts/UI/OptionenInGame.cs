using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionenInGame : MonoBehaviour
{

    [SerializeField] Button closeButton;

    private GameManager gameManager;

    private GameData _gameData;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _gameData = FindObjectOfType<GameData>();
        closeButton.onClick.AddListener(QuitOptions);
    }

    private void QuitOptions()
    {
        SceneManager.UnloadSceneAsync("OptionenInGame");
        _gameData.isInGame = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
