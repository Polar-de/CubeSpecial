using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract
{
    public string InteractionPrompt { get; }
    public bool Interact(PlayerInteraction playerInteraction);
}
