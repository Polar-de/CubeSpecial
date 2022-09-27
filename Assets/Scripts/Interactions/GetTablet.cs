using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTablet : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject tabletPrefab;

    public string InteractionPrompt => interactionPrompt;

    public bool Interact(PlayerInteraction playerInteraction)
    {
        if (!tabletPrefab.activeSelf)
        {
            tabletPrefab.SetActive(true);
            return true;
        }
        else
        {
            // TODO Nachricht "Du hast schon ein Tablett"
            Debug.Log("ASDASDASDASDASD");
            return false;
        }
    }
}
