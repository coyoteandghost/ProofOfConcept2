using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public CharacterController controllerP;
    public float speed;
    public float jumpHeight = 3f;
    public float drag;

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
        currentVelocity.z = 0;

        // creates invisible sphere w position, radius, and layer to check for collision
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 

        if (isGrounded && currentVelocity.y <0) //if grounded, reset velocity
        {
            currentVelocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * 0; //controlling the movement in the forward and side to side
        //controllerP.Move(move * speed * Time.deltaTime); //take the movement formula and apply it to character with respect to time and speed

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            currentVelocity.y = Mathf.Sqrt(jumpHeight * -2f * grav);
        }

        //adding gravity downwards!
        currentVelocity.y += grav * Time.deltaTime * weight;

        var flags = controllerP.Move((currentVelocity + move*speed )* Time.deltaTime); //tells where it collides with things
        if ((flags & CollisionFlags.Above)!=0)
        {
            currentVelocity.y = 0;
        }
        /*if ((flags & CollisionFlags.Below) != 0)
        {
            currentVelocity.y = -currentVelocity.y;
        }*/

        currentVelocity.x *= Mathf.Clamp01(1f - drag * Time.deltaTime);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.sharedMaterial.bounciness > 0)
        {
            currentVelocity = Vector3.Reflect(currentVelocity, hit.normal) * hit.collider.sharedMaterial.bounciness;
        }
    }


}
