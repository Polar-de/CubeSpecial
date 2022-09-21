using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Optionen : MonoBehaviour
{
    [SerializeField] Button closeButton;
    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadScene()
    {
        SceneManager.LoadScene("MainMenuUI", LoadSceneMode.Single);
    }
}
