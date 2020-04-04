using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Battery : Interactable
{
    public float batteryValue;

    private void Start() {
        popUpText = popUpText + " ("+batteryValue.ToString("F0")+ "s)";
        //if( batteryValue <= 0)
    }
    public override void OnInteract()
    {
        GameController.instance.AddTime(batteryValue);
        Destroy(this.gameObject);
    }
}
