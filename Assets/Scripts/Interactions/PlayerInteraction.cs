using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    // private UnityEvent _event;
    [SerializeField] private LayerMask interactableLayerMask;
    [SerializeField] private float raycastMaxDistance;
    [SerializeField] private InteractionUI interactionUI;

    private Camera _cam;
    private IInteract _interact;
    private bool _isInInteraction;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, raycastMaxDistance, interactableLayerMask))
        {
            _interact = hit.collider.GetComponent<IInteract>();
            if (hit.collider != null && !_isInInteraction)
            {
                if(!interactionUI.isActive) interactionUI.InteractPrompt(_interact.InteractionPrompt);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    _isInInteraction = true;
                    interactionUI.Close();
                    _interact.Interact(this);
                }
            }
        }
        else
        {
            _isInInteraction = false;
            _interact = null;
            if (interactionUI.isActive) interactionUI.Close();
        }
    }
}
