using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTablet : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject tabletPrefab;
    private GameData _gameData;

    private void Start()
    {
        _gameData = FindObjectOfType<GameData>();
    }

    public string InteractionPrompt => interactionPrompt;

    public bool Interact(PlayerInteraction playerInteraction)
    {
        if (!tabletPrefab.activeSelf && !_gameData.hasTablet && _gameData.MoneyOnCard > 0)
        {
            tabletPrefab.SetActive(true);
            _gameData.hasTablet = true;
            _gameData.questID = 2;
            return true;
        }

        if (_gameData.hasTablet)
        {
            NotificationSystem.Instance.Notification("Sie haben schon ein Tablett");
            return false;
        }

        NotificationSystem.Instance.Notification("Laden sie erst die Smartcard auf");
        return false;
    }
}
