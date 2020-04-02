using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Interactable : MonoBehaviour, IInteractable
{
    #region Variables
        [Header("Interactable Settings")]

        public string popUpText = "Interact (E)";
        public float holdDuration;
        [Space]
        public bool holdInteract;
        public bool multipleUse;
        public bool isInteractable;
    #endregion

    #region Properties
        public string PopUpText => popUpText;
        public float HoldDuration => holdDuration;
        public bool HoldInteract => holdInteract;
        public bool MultipleUse => multipleUse;
        public bool IsInteractable => isInteractable;
    #endregion

    #region Methods
        public virtual void OnInteract()
        {

        }
    #endregion
}
