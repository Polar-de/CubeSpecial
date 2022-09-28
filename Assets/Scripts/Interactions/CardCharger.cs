using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCharger : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private Camera camera1;
    [SerializeField] private GameObject helpUI;

    private Camera _mainCam;
    private GameObject _player;
    private bool _isInCamera;

    private void Start()
    {
        _mainCam = Camera.main;
        _player = GameObject.FindWithTag("Player");
    }

    public string InteractionPrompt => interactionPrompt;
    public bool Interact(PlayerInteraction playerInteraction)
    {
        if (!_isInCamera)
        {
            camera1.enabled = true;
            _isInCamera = true;
            helpUI.SetActive(true);
            _player.SetActive(false);

            Cursor.lockState = CursorLockMode.Confined;
            
            return true;
        } 
        else
            return false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && _isInCamera)
        {
            CloseCardCharger();
        }
    }

    private void CloseCardCharger()
    {
        camera1.enabled = false;
        helpUI.SetActive(false);
        _player.SetActive(true);
        _isInCamera = false;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
