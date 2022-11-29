using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neighbor : MonoBehaviour
{
    
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        AudioSource scream = gameObject.GetComponent<AudioSource>();
        scream.Play();
    }

}
