using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public Transform player;
    public Collider col;
    void Start()
    {
        player = FindObjectOfType<playerMove>().transform;
    }

    void Update()
    {
        if (player.position.y - (col.bounds.max).y >0)
        {
            col.enabled = true;
        }
        else
        {
            col.enabled = false;
        }

        //Debug.Log(player.position.y + "," + (col.bounds.max).y);
    
    }
}
