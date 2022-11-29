using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTankControls : MonoBehaviour
{

    public CharacterController controllerP;
    public float speed;

    public float rotSense = 10f;
    float xRotation = 0f;
    public Transform playerBody;

    public Transform groundCheck; // spherecheck for grav reset
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 currentVelocity;
    bool isGrounded;
    float grav = -9.81f;

    //----------------------------------
    public ParticleSystem waterPS;
    bool shot;

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // creates invisible sphere w position, radius, and layer to check for collision

        if(isGrounded && currentVelocity.y < 0) //if grounded, reset velocity
        {
            currentVelocity.y = -2f; 
        }

        float lookX = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        xRotation -= lookX;

        //transform.localRotation = Quaternion.Euler(xRotation, 0, 0); //rotating the camera body on the x axis
        playerBody.Rotate(Vector3.up * lookX * rotSense); //rotates player body on the y axis 

        /*
        Vector3 move = transform.forward*z; //controlling the movement in the forward and side to side
        controllerP.Move(move * speed * Time.deltaTime); //take the movement formula and apply it to character with respect to time and speed
        */

        //adding gravity downwards!
        currentVelocity.y += grav * Time.deltaTime;
        controllerP.Move(currentVelocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            if (!shot)
            {
                shot = true;
                waterPS.Emit(10);
                StartCoroutine(Timer());
            }
        }

    }

    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1);
        shot = false;
    }

}
