using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private InteractionUI interactionUI;

    private Collider[] _colliders = new Collider[3];
    private int _colAmountFound;

    private IInteract _interact;

    private bool _isInInteraction;

    private void Update()
    {
        _colAmountFound =
            Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRadius, _colliders, interactableLayer);
        // Debug.Log(_colAmountFound);

        if (_colAmountFound > 0)
        {
            _interact = _colliders[0].GetComponent<IInteract>();

            if (_interact != null && !_isInInteraction)
            {
                if (!interactionUI.isActive) interactionUI.InteractPrompt(_interact.InteractionPrompt);

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }
}
