using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineTerminal : Interactable
{
    public override void OnInteract()
    {
       ObjectiveController.instance.SetObjective(0);
    }
}
