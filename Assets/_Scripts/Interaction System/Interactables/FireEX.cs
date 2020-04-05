using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEX : Interactable
{
    public ParticleSystem foamParticles;
    public Collider foamColl;

    private void Awake() 
    {
    }
    private void Update() 
    {
    }
    public override void OnInteract()
    {
        Player.instance.PickUpItem(this);
    }

    public override void OnStartUse()
    {
        ObjectiveController.instance.SetObjective(5);
        foamParticles.Play();
        foamColl.enabled = true;
    }

    public override void OnStopUse()
    {
        foamParticles.Stop();
        foamColl.enabled = false;
    }

}
