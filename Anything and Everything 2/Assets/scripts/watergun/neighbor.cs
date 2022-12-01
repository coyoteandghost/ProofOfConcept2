using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neighbor : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        AudioSource scream = gameObject.GetComponent<AudioSource>();
        scream.Play();

        //play retreat anim

    }

}
