using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerTrigger : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {
       ObjectiveController.instance.SetObjective(6);
   }
}
