using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCharger : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private Camera camera1;
    private AudioListener _audioListener;

    private Camera _mainCam;
    private GameObject _player;
    private bool _isInCamera;

    private void Start()
    {
        _mainCam = Camera.main;
        _player = GameObject.FindWithTag("Player");
        _audioListener = camera1.GetComponent<AudioListener>();
    }

    public string InteractionPrompt => interactionPrompt;
    public bool Interact(PlayerInteraction playerInteraction)
    {
        if (!_isInCamera)
        {
            Debug.Log("KARTEEE");
            camera1.enabled = true;
            _audioListener.enabled = true;
            _isInCamera = true;
            _player.SetActive(false);

            Cursor.lockState = CursorLockMode.Confined;
            
            return true;
        } 
        else
            return false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isInCamera)
        {
            CloseCardCharger();
        }
    }

    private void CloseCardCharger()
    {
        camera1.enabled = false;
        _audioListener.enabled = false;
        _player.SetActive(true);
        _isInCamera = false;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
