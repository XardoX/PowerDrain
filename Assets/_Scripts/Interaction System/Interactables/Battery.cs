using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Interactable
{
    public float batteryValue;

    private void Awake() {
        //if( batteryValue <= 0)
    }
    private void Start() {
        
    }
    public override void OnInteract()
    {
        GameController.instance.AddTime(batteryValue);
        Destroy(this);
    }
}
