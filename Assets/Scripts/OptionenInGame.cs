using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionenInGame : MonoBehaviour
{

    [SerializeField] Button closeButton;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        closeButton.onClick.AddListener(LoadTestScene);
    }

    // Update is called once per frame
    private void LoadTestScene()
    {
        gameManager.LoadScene("TestScene");
    }
}
