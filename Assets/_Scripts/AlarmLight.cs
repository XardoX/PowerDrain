using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlarmLight : MonoBehaviour
{
    public Transform pivot;    // Start is called before the first frame update
    void Start()
    {
        pivot.transform.DORotate((new Vector3(0,0,360)), 2, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
