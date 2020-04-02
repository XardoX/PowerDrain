using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public PlayerData data;
   private float _energy;
   private float _maxEnergy;

   private bool _run;

   private void Awake() 
   {
      _maxEnergy = data.maxEnergy;   
   }
   private void Start() 
   {
   }

   private void Update() 
   {
      _energy -= Time.deltaTime;
   }
}
