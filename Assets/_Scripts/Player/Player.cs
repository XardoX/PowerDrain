using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   private void Awake() 
   {
      if (instance != null && instance != this) 
      {
         Destroy(this.gameObject);
      }
      instance = this;
   }
   private void Start() 
   {
   }

   private void Update() 
   {

   }
}
