using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    [SerializeField] Button startButton;
    [SerializeField] Button optionenButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(LoadScene);
        optionenButton.onClick.AddListener(LoadSceneTwo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadScene()
    {
        SceneManager.LoadScene("ManagmentScene", LoadSceneMode.Single);
    }

    public static void LoadSceneTwo()
    {
        SceneManager.LoadScene("Optionen", LoadSceneMode.Single);
    }
}
