using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionInputData", menuName = "Interaction System/Input Data")]
public class InteractionInputData : ScriptableObject
{
    private bool _interactedClicked;
    private bool _interactedRelease;

    public bool InteractedClicked
    {
        get => _interactedClicked;
        set => _interactedClicked = value;
    }
    public bool InteractedReleased
    {
        get => _interactedRelease;
        set => _interactedRelease = value;
    }

    public void ResetInput()
    {
        _interactedClicked = false;
        _interactedRelease = false;
    }
}
