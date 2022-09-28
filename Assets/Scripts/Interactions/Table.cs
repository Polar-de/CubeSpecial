using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject tabletFull;
    [SerializeField] private GameObject tabletEmpty;
    [SerializeField] private GameObject darkenImage;

    private GameData _gameData;

    private void Start()
    {
        _gameData = FindObjectOfType<GameData>();
    }

    public string InteractionPrompt => interactionPrompt;
    public bool Interact(PlayerInteraction playerInteraction)
    {
        if (_gameData.payed)
        {
            StartCoroutine(Darken(1f));
            tabletFull.SetActive(false);
            tabletEmpty.SetActive(true);
            _gameData.questID = 8;
            return true;
        }

        if (!_gameData.payed)
        {
            NotificationSystem.Instance.Notification("Sie müssen erst bezahlen");
            return false;
        }
        
        NotificationSystem.Instance.Notification("Sie müssen sich erst essen holen");
        return false;
    }

    IEnumerator Darken(float duration)
    {
        var color = darkenImage.GetComponent<Image>().color;
        
        while (color.a < 1)
        {
            color = new Color(color.r, color.g, color.b, color.a + (duration * Time.deltaTime));
            darkenImage.GetComponent<Image>().color = color;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);
        
        while (color.a > 0)
        {
            color = new Color(color.r, color.g, color.b, color.a - (duration * Time.deltaTime));
            darkenImage.GetComponent<Image>().color = color;
            yield return null;
        } 
        
    }
}
