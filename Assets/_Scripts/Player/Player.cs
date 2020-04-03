using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   #region singleton

   public static Player instance = null;

   public static Player Instance
   {
      get
      { 
         return instance; 
      }
   }
   #endregion
   public PlayerData data;

   public Transform handPoint;
   private Interactable _pickedObject;

   private bool _pickedUp;

   private void Awake() 
   {
      if (instance != null && instance != this) 
      {
         Destroy(this.gameObject);
      }
      instance = this;
   }
   private void Start() 
   {
   }

   private void Update() 
   {
       if(_pickedUp)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                DropItem();
            }
            if(_pickedObject.isUsable)
            {
               if((Input.GetKeyDown(KeyCode.Mouse0)))
               {
                     _pickedObject.OnStartUse();
               }
               if((Input.GetKeyUp(KeyCode.Mouse0)))
               {
                     _pickedObject.OnStopUse();
               }
            }
        }
   }

   public void PickUpItem(Interactable p)
    {
      _pickedObject = p;
      _pickedUp = true;
      _pickedObject.GetComponent<Collider>().enabled = false;
      _pickedObject.GetComponent<Rigidbody>().isKinematic = true;
      _pickedObject.isInteractable = false;
      _pickedObject.transform.position = handPoint.position;
      _pickedObject.transform.parent = handPoint.parent;
      _pickedObject.transform.rotation = handPoint.rotation;
    }
    public void DropItem()
    {
       if(_pickedObject != null)
       {
         _pickedObject.isInteractable = true;
         _pickedObject.GetComponent<Collider>().enabled = true;
         _pickedObject.GetComponent<Rigidbody>().isKinematic = false;
         _pickedObject.transform.parent = null;
         _pickedUp = false;
         _pickedObject = null;
       }
    }
}
