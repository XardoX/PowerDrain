using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interaction Data", menuName = "Interaction System/Interaction Data")]
public class InteractionData : ScriptableObject
{
   private Interactable _interactable;

   public Interactable InteractableObject
   {
       get => _interactable;
       set => _interactable = value;
   }

   public void Interact()
   {
       _interactable.OnInteract();
       ResetData();
   }

    public bool IsSameInteractable(Interactable _newInteractable) => _interactable == _newInteractable;
    public bool IsEmpty() => _interactable == null;
    public void ResetData() => _interactable = null;
}
