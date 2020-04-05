using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LightsController : MonoBehaviour
{
     #region singleton
    public static LightsController instance = null;

    public static LightsController Instance
    {
        get
        { 
            return instance; 
        }
    }
    #endregion

    //[HideInInspector]
    public List<AlarmLight> alarmLights;
    private GameObject[] _alarmLights;

    private void Awake() 
    {
         if (instance != null && instance != this) 
         {
             Debug.Log("light wyjebało");
             Destroy(this.gameObject);
         }
          instance = this;
    }
    void Start()
    {
        _alarmLights = GameObject.FindGameObjectsWithTag("AlarmLight");
        foreach (GameObject _light in _alarmLights)
        {
            alarmLights.Add(_light.GetComponent<AlarmLight>());
            
        }
    }

    public void SetAlarmLights(bool alarm)
    {
        foreach(AlarmLight _light in alarmLights)
        {
           _light.SetLight(alarm);
        }
    }
}
