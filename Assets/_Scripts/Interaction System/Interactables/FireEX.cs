using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEX : Interactable
{
    public ParticleSystem foamParticles;
    public Collider foamColl;
    private bool _pickedUp;

    private bool usingItem;

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
        foamParticles.Play();
        foamColl.enabled = true;
    }

    public override void OnStopUse()
    {
        foamParticles.Stop();
        foamColl.enabled = false;
    }

}
