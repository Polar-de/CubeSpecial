using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Kasse : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private string defaultTextUI;

    private GameData _gameData;

    private void Start()
    {
        _gameData = FindObjectOfType<GameData>();
    }

    public string InteractionPrompt => interactionPrompt;

    public bool Interact(PlayerInteraction playerInteraction)
    {
        if (_gameData.Price > 0)
        {
            if (_gameData.MoneyOnCard >= _gameData.Price)
            {
                StartCoroutine(Pay());
                // _gameData.Price = 0f;
                // _gameData.payed = true;
                return true;
            }

            NotificationSystem.Instance.Notification("Sie müssen erst ihre Smartcard aufladen");
            return false;
        }

        NotificationSystem.Instance.Notification("Holen sie sich erst ihr Essen");
        return false;
    }

    IEnumerator Pay()
    {
        uiText.text = $"{_gameData.Price.ToString(string.Empty)},00€";
        yield return new WaitForSecondsRealtime(2f);
        _gameData.Price = 0f;
        _gameData.payed = true;
        uiText.text = $"0,00€";
        _gameData.questID = 6;
        yield return new WaitForSecondsRealtime(2f);
        uiText.text = defaultTextUI;
    }
}
