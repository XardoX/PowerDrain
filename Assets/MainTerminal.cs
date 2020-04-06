using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTerminal : Interactable
{
    public override void OnInteract()
    {
        GameController.instance.EndGame();
    }
}
