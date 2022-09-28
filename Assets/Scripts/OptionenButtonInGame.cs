using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OptionenButtonInGame : MonoBehaviour
{
    [SerializeField] Button optionenButton;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        optionenButton.onClick.AddListener(LoadOptions);
    }

    private void LoadOptions()
    {
        gameManager.LoadScene("OptionenInGame");
    }
}
