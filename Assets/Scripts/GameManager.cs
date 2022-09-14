using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private readonly string[] _persistentScenes = {"ManagementScene"};

    private void Start()
    {
        LoadScene("MainMenu");
    }

    private void LoadScene(string sceneName)
    {
        UnloadAllNonPersistentScenes();
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
    
    private void LoadScene(string[] scenes)
    {
        UnloadAllNonPersistentScenes();
        foreach (var scene in scenes)
        {
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }
    }
    
    private void UnloadAllNonPersistentScenes()
    {
        // Go trough all active Scenes
        for (var i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i).name;
            // is Scene persistent?
            // bool isPersistent = Array.IndexOf(_persistentScenes, scene) > -1;
            var isPersistent = _persistentScenes.Contains(scene);
            
            // if no -> unload Scene
            if (!isPersistent) SceneManager.UnloadSceneAsync(scene);
        }
    }
}