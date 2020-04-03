using UnityEngine;

public interface IInteractable
{
    string PopUpText{get;}
    float HoldDuration{get;}
    bool HoldInteract {get;}
    bool IsUsable{get;}
    bool IsInteractable{get;}

    void OnInteract();

    void OnStartUse();
    void OnStopUse();
}
