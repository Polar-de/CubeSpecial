using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hilfe : MonoBehaviour
{
    [SerializeField] Button helpButton;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        helpButton.onClick.AddListener(LoadHelpScene);
    }



    private void LoadHelpScene()
    {
        gameManager.LoadScene("Hilfe");
    }
}
