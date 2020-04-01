using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
#region  Variables
    [Header("Data")]
    public InteractionInputData interactionInputData;
    public InteractionData interactionData;
    [Space]

    [Header("Ray Settings")]
    public float rayDistance;
    public float raySphereRadius;
    public LayerMask interactableLayer;

    #region Private Variables
    private Camera _cam;
    private bool _interacting;
    private float _holdTimer = 0f;
    #endregion

#endregion

#region Built-in Methods
    private void Awake() 
    {
        _cam = FindObjectOfType<Camera>();
    }
    private void Update() 
    {
        CheckForInteractable();
        CheckForInteractableInput();
    }
#endregion

#region  Methods
    private void CheckForInteractable()
    {
        Ray _ray = new Ray(_cam.transform.position, _cam.transform.forward);
        RaycastHit _hitInfo;
        bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius, out _hitInfo, rayDistance, interactableLayer);

        if(_hitSomething)
        {
            Interactable _interactable = _hitInfo.transform.GetComponent<Interactable>();
            if(_interactable != null)
            {
                if(interactionData.IsEmpty())
                {
                    interactionData.InteractableObject = _interactable;
                }
                else
                {
                    if(!interactionData.IsSameInteractable(_interactable))
                    {
                         interactionData.InteractableObject = _interactable;
                    }
                }
            }
        }
        else
        {
            interactionData.ResetData();
        }
    }

    private void CheckForInteractableInput()
    {
        if(interactionData.IsEmpty())
            return;

        if(interactionInputData.InteractedClicked)
        {
            _interacting = true;
            _holdTimer = 0f;
        }

        if(interactionInputData.InteractedReleased)
        {
            _interacting = false;
            _holdTimer = 0f;
        }

        if(_interacting)
        {
            if(!interactionData.InteractableObject.IsInteractable)
                return;

            if(interactionData.InteractableObject.HoldInteract)
            {
                _holdTimer += Time.deltaTime;
                if(_holdTimer >= interactionData.InteractableObject.HoldDuration)
                {
                    interactionData.Interact();
                    _interacting = false;
                }
            } 
            else
            {
                interactionData.Interact();
                _interacting = false;
            }
        }
    }
#endregion
}
