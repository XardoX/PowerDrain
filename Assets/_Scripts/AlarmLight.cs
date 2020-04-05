using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlarmLight : MonoBehaviour
{
    public Transform pivot;    // Start is called before the first frame update
    private Light _light;
    private Material material;
    void Start()
    {
        _light = GetComponentInChildren<Light>();
        material = this.GetComponent<MeshRenderer>().material;
        pivot.transform.DORotate((new Vector3(0,0,360)), 2, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
    }

    public void SetLight(bool _alarm)
    {
        _light.enabled = _alarm;
        if(_alarm)
        {
            material.EnableKeyword("_EMISSION");
        } else material.DisableKeyword("_EMISSION");
    }
}
