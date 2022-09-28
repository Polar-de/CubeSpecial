using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Optionen : MonoBehaviour
{
    [SerializeField] Button closeButton;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        closeButton.onClick.AddListener(LoadMainMenu);
    }


    private void LoadMainMenu()
    {
        gameManager.LoadScene("MainMenuUI");
    }
}
