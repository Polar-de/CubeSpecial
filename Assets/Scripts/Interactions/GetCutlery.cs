using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCutlery : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject cutlery;
    private GameData _gameData;

    private void Start()
    {
        _gameData = FindObjectOfType<GameData>();
    }

    public string InteractionPrompt => interactionPrompt;

    public bool Interact(PlayerInteraction playerInteraction)
    {
        if (!cutlery.activeSelf && _gameData.payed)
        {
            cutlery.SetActive(true);
            _gameData.questID = 7;
            return true;
        }
        if (!_gameData.payed)
        {
            NotificationSystem.Instance.Notification("Sie müssen sich erst ihr Essen holen und bezahlen");
            return false;
        }
        if (cutlery.activeSelf)
        {
            NotificationSystem.Instance.Notification("Sie haben schon Besteck");
            return false;
        }
        return false;
    }
}
