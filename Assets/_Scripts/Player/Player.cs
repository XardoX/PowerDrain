using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

   [Range(0f,1f)]
   public float slowPercent = 0.75f;
   private Interactable _pickedObject;
   private FirstPersonAIO _firstPersonAIO;

   public bool _pickedUp;
   private float _playerSpeed;

   private void Awake() 
   {
      if (instance != null && instance != this) 
      {
         Debug.Log("Player wyjebało");
         Destroy(this.gameObject);
      }
      instance = this;
      _firstPersonAIO = gameObject.GetComponent<FirstPersonAIO>();
      _playerSpeed = _firstPersonAIO.walkSpeed;
   }
   private void Start() 
   {
   }

   private void Update() 
   {
       if(_pickedUp)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                _pickedObject.OnStopUse();
                DropItem();
                return;
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
       DropItem();
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
         _pickedObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 100);
         _pickedObject.transform.parent = null;
         _pickedUp = false;
         _pickedObject = null;
       }
    }

    public void PutItem(Transform t)
    {
       if(_pickedObject != null)
       {
          _pickedObject.transform.parent = null;
          _pickedObject.transform.position = t.position;
          _pickedObject.transform.DORotate((new Vector3(360,0,0)), 2, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
          _pickedObject.transform.DORotate((new Vector3(0,0,360)), 2, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
          _pickedUp = false;
         _pickedObject = null;
      }
    }

    public void SlowPlayer(bool slow)
    {
       if(slow){
         _firstPersonAIO.walkSpeed = _playerSpeed * slowPercent;
       } else _firstPersonAIO.walkSpeed = _playerSpeed;
    }

    public void StopPlayer(bool stop)
    {
      _firstPersonAIO.playerCanMove = !stop;
      _firstPersonAIO.enableCameraMovement = !stop;
    }

}
