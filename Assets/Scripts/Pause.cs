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

    // Start is called before the first frame update
    void Start()
    {
        menuButton.onClick.AddListener(LoadMenuScene);
        optionsButton.onClick.AddListener(LoadOptionsScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenuUI", LoadSceneMode.Single);
    }

    public static void LoadOptionsScene()
    {
        SceneManager.LoadScene("Optionen", LoadSceneMode.Single);
    }
}
