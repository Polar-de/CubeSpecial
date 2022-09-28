using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletDelivery : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject tablet;
    [SerializeField] private GameObject tabletDelivered;

    private GameData _gameData;

    private void Start()
    {
        _gameData = FindObjectOfType<GameData>();
    }

    public string InteractionPrompt => interactionPrompt;
    public bool Interact(PlayerInteraction playerInteraction)
    {
        if (tablet.activeSelf)
        {
            tablet.SetActive(false);
            tabletDelivered.SetActive(true);
            _gameData.hasTablet = false;
            _gameData.questID = 9;
            return true;
        }

        NotificationSystem.Instance.Notification("Sie haben kein Tablett zum abgeben");
        return false;
    }
}
