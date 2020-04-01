using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public static GameController Instance
    {
        get
        { 
            return instance; 
        }
    }

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

    public void NextRun(float _remainingEnergy)
    {

    }
}
