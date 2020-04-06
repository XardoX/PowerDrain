using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : Interactable
{
    public override void OnInteract()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * 150);
    }
}
