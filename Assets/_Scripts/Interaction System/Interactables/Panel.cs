using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : Interactable
{
    public override void OnInteract()
    {
        ObjectiveController.instance.SetObjective(0);
        LightsController.instance.SetAlarmLights(false);
        isInteractable = false;
    }
}
