using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region singleton

    public static GameController instance = null;

    public static GameController Instance
    {
        get
        { 
            return instance; 
        }
    }
    #endregion

#region Variables
    public Transform playerSpawn;

    public GameObject player;

    public float remainingTime;
    public float maxTime;
#endregion
    private void Awake() 
    {
         if (instance != null && instance != this) 
         {
             Destroy(this.gameObject);
         }
 
         instance = this;
         DontDestroyOnLoad( this.gameObject );
    }
    private void Update() 
    {
        
    }

    public void NextRun()
    {

    }

    public void AddTime(float value)
    {
        remainingTime += value;
        if(remainingTime > maxTime) remainingTime = maxTime;
    }
}
