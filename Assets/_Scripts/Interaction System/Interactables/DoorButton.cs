﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorButton : Interactable
{
    [Header("Door Settings")]
    public GameObject door;
    public float doorOffset;
    public float duration;
    public float openTime;
    public bool isLocked =true;
    public bool autoLocking = false;
    public Ease close;
    public Ease open;
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
                        if(autoLocking)
                        {
                            door.transform.DOMoveY(openPos, duration).SetEase(open).OnComplete(CloseAfterTime);
                            isLocked = false;
                        }else
                        {
                            door.transform.DOMoveY(openPos, duration).SetEase(open).OnComplete(UnblockButton);
                            isLocked = false;
                        }
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
    void CloseAfterTime()
    {
       door.transform.DOMoveY(closedPos, duration).SetEase(close).SetDelay(openTime).OnComplete(UnblockButton);
       isLocked = true;
    }

    #endregion

    public override void OnInteract()
    {
        ChangeDoorState();
        FindObjectOfType<AudioManager>().Play("Doors up");
        FindObjectOfType<AudioManager>().Play("Access Granted");
    }

}
