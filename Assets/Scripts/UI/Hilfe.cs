using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hilfe : MonoBehaviour
{
    [SerializeField] Button helpButton;
    // Start is called before the first frame update
    void Start()
    {
        helpButton.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadScene()
    {
        SceneManager.LoadScene("Hilfe", LoadSceneMode.Single);
    }
}
