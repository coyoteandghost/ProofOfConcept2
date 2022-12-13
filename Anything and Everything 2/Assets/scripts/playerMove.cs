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

    public Animator playerAnim;
    public SpriteRenderer playerSpr;

    void Update()
    {
        currentVelocity.z = 0;

        // creates invisible sphere w position, radius, and layer to check for collision
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 


        if (isGrounded && currentVelocity.y < 0) //if grounded, reset velocity
        {
            currentVelocity.y = -2f;
            
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * 0; //controlling the movement in the forward and side to side


        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            currentVelocity.y = Mathf.Sqrt(jumpHeight * -2f * grav);
            playerAnim.SetBool("jumping", true);
            playerAnim.SetBool("idle", false);
            playerAnim.SetBool("walking", false);
        }


        if (!isGrounded)
        {
            if(currentVelocity.y <= 0)
            {
                playerAnim.SetBool("jumping", false);                
            }

            playerAnim.SetBool("idle", false);
            playerAnim.SetBool("walking", false);
        }

        if (Mathf.Abs(x) > 0.001)
        {
            playerAnim.SetBool("idle", false);
            playerAnim.SetBool("walking", true);
        }
        else
        {
            if (isGrounded)
            {
                playerAnim.SetBool("idle", true);
                playerAnim.SetBool("walking", false);
            }
        }

      if(x < 0)
        {
            playerSpr.flipX = true;
        } 
        else if(x > 0)
        {
            playerSpr.flipX = false;
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

        currentVelocity.x *= Mathf.Clamp01(1 - drag * Time.deltaTime);



        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bounce")
        {
            Debug.Log("colliding wiht bounce tag");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.sharedMaterial.bounciness > 0)
        {
            currentVelocity = Vector3.Reflect(currentVelocity, hit.normal) * hit.collider.sharedMaterial.bounciness;
        }
    }


}
