using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider col;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        //col = GetComponent<BoxCollider>();
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("colliding with somethign");

        if (gameObject.tag == "FakePlatform")
        {
            rb.isKinematic = false;
            Debug.Log("colliding with a FakePlatform");
        }
    }
}
