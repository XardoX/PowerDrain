using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piedestal : Interactable
{
    public Transform powerCorePosition;

    public DoorButton door;
    private bool _isSlotFree = true;
    public override void OnInteract()
    {
        if(_isSlotFree)
        {
            if(Player.instance._pickedUp)
            {
                Player.instance.PutItem(powerCorePosition);
                _isSlotFree = false;
                isInteractable = false;
                door.canOpen = true;
                door.ChangeDoorState();
            }
        } 
    }
}
