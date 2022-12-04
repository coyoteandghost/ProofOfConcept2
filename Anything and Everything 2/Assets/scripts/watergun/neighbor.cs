using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neighbor : MonoBehaviour
{
    ParticleSystem splat;
    public AudioSource hit;
    public bool hitTrack = false;

    private void Start()
    {
        splat = gameObject.GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        AudioSource scream = gameObject.GetComponent<AudioSource>();
        scream.Play();
        hitTrack = true;
        hit.Play();
        splat.Emit(1);

    }

}
