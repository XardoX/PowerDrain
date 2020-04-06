using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : Interactable
{
    public override void OnInteract()
    {
        isInteractable = false;
        ObjectiveController.instance.UploadServer();
    }
}
