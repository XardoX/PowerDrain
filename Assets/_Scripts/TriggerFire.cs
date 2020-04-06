using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFire : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {
       ObjectiveController.instance.SetObjective(3);
   }
}
