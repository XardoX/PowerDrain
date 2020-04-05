using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCore : Interactable
{
    public override void OnInteract()
    {
        Player.instance.PickUpItem(this);
    }
}
