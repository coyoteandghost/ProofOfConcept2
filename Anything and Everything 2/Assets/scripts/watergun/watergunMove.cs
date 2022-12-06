using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watergunMove : MonoBehaviour
{

    public CharacterController controllerP;
    public float speed;

    public Transform groundCheck; // spherecheck for grav reset
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 currentVelocity;
    bool isGrounded;
    float grav = -9.81f;

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // creates invisible sphere w position, radius, and layer to check for collision

        if(isGrounded && currentVelocity.y < 0) //if grounded, reset velocity
        {
            currentVelocity.y = -2f; 
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right*x + transform.forward*z; //controlling the movement in the forward and side to side
        controllerP.Move(move * speed * Time.deltaTime); //take the movement formula and apply it to character with respect to time and speed

        //adding gravity downwards!
        currentVelocity.y += grav * Time.deltaTime;
        controllerP.Move(currentVelocity * Time.deltaTime);



    }


}
