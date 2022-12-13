using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stretchEffect : MonoBehaviour
{
    float stretchScale = 1;
    public GameObject spriteToScale;
    void Start()
    {
        
    }

    void Update()
    {
        spriteToScale.transform.localScale = new Vector3(1.0f+ stretchScale, 1.0f, 1.0f);
        
    }
}
