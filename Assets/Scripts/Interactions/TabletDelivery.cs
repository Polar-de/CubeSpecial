using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletDelivery : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject tablet;
    [SerializeField] private GameObject tabletDelivered;

    public string InteractionPrompt => interactionPrompt;
    public bool Interact(PlayerInteraction playerInteraction)
    {
        if (tablet.activeSelf)
        {
            tablet.SetActive(false);
            tabletDelivered.SetActive(true);
            return true;
        }
        else
        {
            return false;
        }
    }
}
