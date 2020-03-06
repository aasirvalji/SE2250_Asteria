using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightController : MonoBehaviour
{
    //defining aatributes for this class

    float speed = 40.0f; // spped of the knight
    float rotSpeed = 80.0f; // rotation speed of knight
    float rotation = 0.0f;
    float gravity = 8.0f; // the effect of gravity on knight

    Vector3 moveDir = Vector3.zero; // knight would be still once game starts until it is moved

    CharacterController controller; //defining a characterController type variable
    Animator anim; // defining an animator type variable


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); //assigning characterController component to the knight(player)
        anim = GetComponent<Animator>(); //assigning animator component to the knight(player)
        
    }

    // Update is called once per frame
    void Update()
    {

        Movement(); // calling the movement method on every frame
        GetInput();
    }

    void Movement()
    {
        if (controller.isGrounded) //checking if the knight is grounded or not
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (anim.GetBool("attcking") == true)
                {
                    return; // if we are attcking then we just return
                }
                else if (anim.GetBool("attacking") == false) // if we are not attacking then we want to move
                {
                    anim.SetBool("running", true); //when the player moves, the ruuning parameter should be true
                    anim.SetInteger("condition", 1); // setting the condition parameter to 1 when W is pressed
                                                     // if the input key is W, move the player one step forward
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= speed; // this is to match the speed and movement of the player
                    moveDir = transform.TransformDirection(moveDir); // transforms the movement from local to global space
                }
                

            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("running", false); // when the player is still, running paramter is set to false
                anim.SetInteger("condition", 0); // seeting the condition parameter back to zero when we stop pressing W
                //when we stop pressing W, don't move the player
                moveDir = new Vector3(0, 0, 0);

            }

        }

        if(controller.isGrounded == false)
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
        if (controller.isGrounded) // checking id the player is grounded or not
        {
            if (Input.GetMouseButtonDown(0)) // if there is a left click on mouse
            {
                if (anim.GetBool("running") == true) // if the player is running
                {
                    anim.SetBool("running", false); // set the running paramter to false (stop the player)
                    anim.SetInteger("condition", 0); // make the player idle
                }
                if (anim.GetBool("running") == false)
                {
                    Attacking(); // whenever this is the case, just call the attacking method
                }
                
            }
        }
    }


    void Attacking() // creating a function for attacking
    {
        StartCoroutine(AttackingRoutine());
        
    }

    IEnumerator AttackingRoutine()
    {
        anim.SetBool("attcking", true); // setting attacking parameter to true
        anim.SetInteger("condition", 2); // this sets the consition parameter to 2 which triggers the attacking animation
        yield return new WaitForSeconds(1); // we wait for a second before we attack everytime
        anim.SetInteger("condition", 0); //after we attack, we idle
        anim.SetBool("attcking", false); // we are not attacking anymore
    }
}
