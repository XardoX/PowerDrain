using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectOnTrigger : MonoBehaviour
{
    public GameObject[] toSetActive;
    public GameObject[] toSetUnactive;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            foreach(GameObject obj in toSetActive)
            {
                obj.SetActive(true);
            }
            foreach(GameObject obj in toSetUnactive)
            {
                obj.SetActive(false);
            }
        }
    }
}
