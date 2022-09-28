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
        if (!cutlery.activeSelf)
        {
            cutlery.SetActive(true);
            _gameData.questID = 7;
            return true;
        }
        else
        {
            // TODO Nachricht "Du hast schon Besteck"
            return false;
        }
    }
}
