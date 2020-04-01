using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorButton : Interactable
{
        public GameObject door;
        public float doorOffset;
        public float duration;
        public bool isLocked;
        public Ease close;
        public Ease open;
       
       private float closedPos;
       private float openPos;
       private void Start() 
       {
           closedPos = door.transform.position.y;
           openPos = door.transform.position.y + doorOffset;
       }
    #region Methods
        public void ChangeDoorState()
        {
            if(door != null)
            {
                Debug.Log("door");
                if(isLocked)
                {
                    door.transform.DOMoveY(closedPos, duration).SetEase(close);
                    isLocked = false;
                }
                else
                {
                    door.transform.DOMoveY(openPos, duration).SetEase(open);
                    isLocked = true;
                }

            }
        }
    #endregion

    public override void OnInteract()
    {
        ChangeDoorState();
    }

}
