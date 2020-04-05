using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piedestal : Interactable
{
    public Transform powerCorePosition;
    private bool _isSlotFree = true;
    public override void OnInteract()
    {
        if(_isSlotFree)
        {
            Player.instance.PutItem(powerCorePosition);
            _isSlotFree = false;
            isInteractable = false;
        } 
    }
}
