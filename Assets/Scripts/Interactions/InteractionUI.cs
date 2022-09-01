using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    private Camera _cameraMain;
    [SerializeField] private GameObject interactionKey;
    [SerializeField] private TextMeshProUGUI prompt;

    public bool isActive;
    private void Start()
    {
        interactionKey.SetActive(false);
    }

    public void InteractPrompt(string promptText)
    {
        prompt.text = promptText;
        interactionKey.SetActive(true);
        isActive = true;
    }

    public void Close()
    {
        interactionKey.SetActive(false);
        isActive = false;
    }
}
