using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PRESS ANY BUTTON, THE TOMA OBJECT KERNS CLOSER TO THE SCREEN. NOW YOU CAN INTERACT WITH IT.
// CANT PUT IT BACK DOWN
// A, W, D KEYS FOR THE BUTTONS
//FIND A WAY TO INTERACT WITH THE BUTTONS
//TIMED EVENT ????
//WIN STATE: MAKE THE PET HAPPY (SOME KIND OF BAR THAT GOES ALL THE WAY UP )

public class cameraKern : MonoBehaviour
{
    bool canInteract = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (!canInteract)
        {
            if (Input.anyKey)
            {
                canInteract = true;
            }
        }
        Debug.Log(canInteract);


    }
}
