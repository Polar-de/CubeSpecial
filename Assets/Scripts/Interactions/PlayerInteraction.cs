using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactableLayer;

    private Collider[] _colliders = new Collider[3];
    private int _colAmountFound;

    private void Update()
    {
        _colAmountFound =
            Physics.OverlapSphereNonAlloc(transform.position, interactionRadius, _colliders, interactableLayer);
    }
}
