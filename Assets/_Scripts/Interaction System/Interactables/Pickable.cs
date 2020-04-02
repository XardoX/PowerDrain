using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    private bool _pickedUp;
    private Rigidbody rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() 
    {
        if(_pickedUp)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                DropItem();
            }
        }
    }
    public override void OnInteract()
    {
        PickUpItem();
    }

    public void PickUpItem()
    {
        _pickedUp = true;
        rb.isKinematic = true;
        isInteractable = false;
        transform.position = Player.instance.handPoint.position;
        transform.parent = Player.instance.handPoint.parent;
    }
    public void DropItem()
    {
        isInteractable = true;
        
        rb.isKinematic = false;
        transform.parent = null;
    }

    public void UsePickable()
    {

    }

}
