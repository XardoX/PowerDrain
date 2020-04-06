using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : Interactable
{
    public List<DoorButton> doorPanels;
    private void Start() 
    {
    }
    public override void OnInteract()
    {
        ObjectiveController.instance.SetObjective(0);
        LightsController.instance.SetAlarmLights(false);
        isInteractable = false;
        foreach(DoorButton d in doorPanels)
        {
            d.DoorBlock(false);
        }
    }
}
