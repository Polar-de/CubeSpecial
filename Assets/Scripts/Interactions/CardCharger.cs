using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardCharger : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private Camera camera1;

    private bool _isInCamera;

    public string InteractionPrompt => interactionPrompt;
    public bool Interact(PlayerInteraction playerInteraction)
    {
        if (!_isInCamera)
        {
            Debug.Log("KARTEEE");
            camera1.enabled = true;
            _isInCamera = true;
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
        _isInCamera = false;
    }
}
