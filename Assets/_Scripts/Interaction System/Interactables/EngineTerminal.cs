using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineTerminal : Interactable
{
       public List<DoorButton> doorPanels;
    public Material engine;
    public override void OnInteract()
    {
        engine.EnableKeyword("_EMISSION");
       ObjectiveController.instance.SetObjective(5);
        isInteractable = false;
        foreach(DoorButton d in doorPanels)
        {
            d.DoorBlock(false);
        }
    }
}
