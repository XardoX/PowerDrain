using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorButton : Interactable
{
    public GameObject door;
    public float doorOffset;
    public float duration;
    public bool isLocked =true;
    public Ease close;
    public Ease open;
    private Tween _openDoor,_closeDoor;
    private bool _blockButton = false;
       
    private float closedPos;
    private float openPos;
    private void Start() 
    {
        closedPos = door.transform.position.y;
        openPos = door.transform.position.y + doorOffset;
        if(door != null)
        {
            Debug.Log("door");
            if(isLocked)
            {
                return;
            }
            else
            {
                door.transform.DOMoveY(openPos, duration).SetEase(open);
                isLocked = false;
            }
        }
    }
    private void Update() 
    {
        
    }
    #region Methods
        public void ChangeDoorState()
        {
            if(!_blockButton)
            {
                if(door != null)
                {
                    _blockButton = true;
                    Debug.Log("door");
                    if(isLocked)
                    {
                        door.transform.DOMoveY(openPos, duration).SetEase(open).OnComplete(UnblockButton);
                        isLocked = false;
                    }
                    else
                    {
                        door.transform.DOMoveY(closedPos, duration).SetEase(close).OnComplete(UnblockButton);
                        isLocked = true;
                    }
                }
            }
        }
    void UnblockButton()
    {
        _blockButton = false;
    }
    #endregion

    public override void OnInteract()
    {
        ChangeDoorState();
    }

}
