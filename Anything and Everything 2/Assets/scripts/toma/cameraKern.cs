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
    public Transform endPosition = null;

    bool canInteract = false;
    bool buttonsActive = false;

    public GameObject food;
    public GameObject sleep;
    public GameObject hygiene;
    public GameObject game;


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
        //Debug.Log(canInteract);

        if (canInteract)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition.position, Time.deltaTime*3);
            buttonsActive = true;
        }

        if (buttonsActive)
        {
            if (Input.GetKey(KeyCode.W))
            {
                food.SetActive(true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                game.SetActive(true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                hygiene.SetActive(true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                sleep.SetActive(true);
            }
        }


    }
}
