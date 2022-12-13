using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTankControls : MonoBehaviour
{

    public CharacterController controllerP;

    public float rotSense;
    float xRotation = 0f;
    float yRotation = 0f;
    public Transform playerBody;
    public AudioSource shoot;
    public int ratAttack;

    //----------------------------------
    public ParticleSystem waterPS;
    bool shot;

    void Update()
    {

        if(ratAttack > 3)
        {
            StartCoroutine(roomSwitchTimer());
            //GetComponent<RoomSwitch>().switchCaseReached = true;
        }

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        xRotation -= yInput;
        yRotation += xInput;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0); //rotating the camera body on the x axis
        playerBody.Rotate(Vector3.up * xInput * rotSense); //rotates player body on the y axis 
        playerBody.Rotate(Vector3.right * yInput * rotSense); //rotates player body on the y axis 


        if (Input.GetKey(KeyCode.Space))
        {
            if (!shot)
            {
                shot = true;
                waterPS.Emit(20);
                shoot.Play();
                StartCoroutine(Timer());
            }
        }

    }

    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        shot = false;
    }

    private IEnumerator roomSwitchTimer()
    {
        yield return new WaitForSeconds(2);
        GetComponent<RoomSwitch>().switchCaseReached = true;
    }

}
