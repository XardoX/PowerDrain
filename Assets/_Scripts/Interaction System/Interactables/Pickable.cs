using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    public override void OnInteract()
    {
        PickUpItem();
    }

    public void PickUpItem()
    {
        isInteractable = false;
    }
    public void DropItem()
    {
        isInteractable = true;
    }

    public void UsePickable()
    {

    }

}
