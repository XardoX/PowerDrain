using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Battery : Interactable
{
    public float batteryValue;

    private void Awake() {
        popUpText = popUpText + " ("+batteryValue.ToString("F0")+ "s)";
        //if( batteryValue <= 0)
    }
    private void Start() {
        
    }
    public override void OnInteract()
    {
        GameController.instance.AddTime(batteryValue);
        Destroy(this.gameObject);
    }
}
