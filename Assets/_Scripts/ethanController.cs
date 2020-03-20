using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ethanController : MonoBehaviour
{
    float speed = 5.0f; // spped of the player
    float rotSpeed = 80.0f; // rotation speed of player
    float rotation = 0.0f;
    float gravity = 8.0f; // the effect of gravity on player
    float jumpSpeed = 4.0f; // jump speed of the player

    Vector3 moveDir = Vector3.zero; // player would be still once game starts until it is moved

    CharacterController controller; //defining a characterController type variable
    Animator anim; // defining an animator type variable


    void Start()
    {
        controller = GetComponent<CharacterController>(); //assigning characterController component to the player
        anim = GetComponent<Animator>(); //assigning animator component to the player

    }

    void Update()
    {
        Movement(); // calling these functions after every frame
        GetInput();
    }

 
    void Movement()
    {
        if (controller.isGrounded) //checking if the knight is grounded or not
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1); // setting the condition parameter to 1 when W is pressed
                moveDir = new Vector3(0, 0, 1);
               
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir); // transforms the movement from local to global space

            }
            if (Input.GetKeyUp(KeyCode.W))
            {

                anim.SetInteger("condition", 0); // seeting the condition parameter back to zero when we stop pressing W
                //when we stop pressing W, don't move the player
                moveDir = new Vector3(0, 0, 0);

            }
        }
            if (controller.isGrounded == false)
            {
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }
            rotation += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            //this allows smooth rotation as the speed of ration gets updates with time on to the horizontal axis
            transform.localRotation = Quaternion.Euler(0, rotation, 0);
            // transform.eulerAngles = new Vector3(0, rotation, 0);
            // updates the eular angles (camera angles) and sets it at the rotation position

            moveDir.y -= gravity * Time.deltaTime; //updates gravity with time
            controller.Move(moveDir * Time.deltaTime); //moves the player while keeping it updates with time
        
    }

    void GetInput()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))  // when you press shift + w
            {
                Running();
                transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed * 2.5f; // makes the player sprint
            }

            if (Input.GetButton("Jump")) // pressing space bar
            {
                Jumping(); // calling jumping function
            }


        }
    }

    void Running()   
    {
        anim.SetInteger("condition", 2);  // this makes the player perform running animation


    }

    void Jumping()
    {
        StartCoroutine(JumpingRoutine());
    }

    IEnumerator JumpingRoutine()
    {
        anim.SetBool("is_in_air", true);  
        moveDir.y = jumpSpeed; // makes the player jump with the jumpspeed
        yield return new WaitForSeconds(1); // we wait for a second before we attack everytime
        anim.SetInteger("condition", 0); // after jump make them idle
        anim.SetBool("is_in_air", false); // player not jumping anymore
    }

}

