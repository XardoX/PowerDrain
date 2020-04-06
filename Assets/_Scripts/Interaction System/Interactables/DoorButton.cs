using System.Collections;
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

    public bool canOpen = true;
    public Ease close;
    public Ease open;
    public Color accessColor;
    public Color deniedColor;

    private Material _material;
    private bool _blockButton = false;
       
    private float closedPos;
    private float openPos;
    private void Start() 
    {
        closedPos = door.transform.position.y;
        openPos = door.transform.position.y + doorOffset;
         _material = this.GetComponent<MeshRenderer>().material;
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
                            AudioManager.instance.Play("Doors up");
                            AudioManager.instance.Play("Access Granted");
                            //_material.SetColor("_EmissionColor", accessColor);
                            isLocked = false;
                        }else
                        {
                            door.transform.DOMoveY(openPos, duration).SetEase(open).OnComplete(UnblockButton);
                            AudioManager.instance.Play("Doors up");
                            AudioManager.instance.Play("Access Granted");
                           // _material.SetColor("_EmissionColor", accessColor);
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

    public void DoorBlock(bool _isBlocked)
    {
        canOpen = !_isBlocked;
        if(canOpen)
        {
            //_material.SetColor("_EmissionColor", accessColor);
        } //else _material.SetColor("_EmissionColor", deniedColor);
    }
    void CloseAfterTime()
    {
       door.transform.DOMoveY(closedPos, duration).SetEase(close).SetDelay(openTime).OnComplete(UnblockButton);
       isLocked = true;
    }

    #endregion

    public override void OnInteract()
    {
        if(canOpen)
        {
            ChangeDoorState();
        } else 
        {
            //_material.SetColor("_EmissionColor", deniedColor);
            _material.DOColor(deniedColor, "_EmissionColor", 0.5f).OnComplete(BackToNormal);
            AudioManager.instance.Play("Access Denied");
        }
    }

    void BackToNormal()
    {
         _material.DOColor(accessColor, "_EmissionColor", 0.2f);
    }
}
