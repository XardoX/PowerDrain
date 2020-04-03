using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public float fireHealth;
    private ParticleSystem fireParticles;
    private Collider coll;
    void Start()
    {
        fireParticles = GetComponent<ParticleSystem>();
        coll = GetComponent<Collider>();
    }

 
    private void OnTriggerStay(Collider other) 
    {
        if(other.tag == "Foam")
        {
            fireHealth -= Time.deltaTime;
            if(fireHealth <=0)
            {
                fireParticles.Stop();
                coll.enabled = false;
            }
        }
    }
}
