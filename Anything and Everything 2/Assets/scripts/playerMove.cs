using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public CharacterController controllerP;
    public float speed;
    public float jumpHeight = 3f;

    public Transform groundCheck; // spherecheck for grav reset
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask bounceMask;

    Vector3 currentVelocity;
    bool isGrounded;
    bool isBounced;
    public float grav;
    public float weight;

    public bool bounceCollision = false;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // creates invisible sphere w position, radius, and layer to check for collision

        if (isGrounded) //if grounded, reset velocity
        {
            if (isBounced)
            {

            }
            else if (currentVelocity.y < 0)
            {
                currentVelocity.y = -2f;
            }



            
        }
        //if (isBounced && )

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * 0; //controlling the movement in the forward and side to side
        controllerP.Move(move * speed * Time.deltaTime); //take the movement formula and apply it to character with respect to time and speed

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            currentVelocity.y = Mathf.Sqrt(jumpHeight * -2f * grav);
        }

        //adding gravity downwards!
        currentVelocity.y += grav * Time.deltaTime * weight;

        var flags = controllerP.Move(currentVelocity * Time.deltaTime); //tells where it collides with things
        if ((flags & CollisionFlags.Above)!=0)
        {
            currentVelocity.y = 0;
        }

        Debug.Log(isGrounded);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bounce")
        {
            isBounced = true;
        }
    }
    


}
