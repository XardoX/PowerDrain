using UnityEngine;

public interface IInteractable
{
    string PopUpText{get;}
    float HoldDuration{get;}
    bool HoldInteract {get;}
    bool MultipleUse{get;}
    bool IsInteractable{get;}

    void OnInteract();
}
