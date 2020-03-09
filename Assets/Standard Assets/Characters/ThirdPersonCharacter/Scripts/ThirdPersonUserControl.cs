using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter controller; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 moveDir;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

        
        float speed = 50.0f; // spped of the knight
        float rotSpeed = 80.0f; // rotation speed of knight
        float rotation = 0.0f;
        float gravity = 8.0f; // the effect of gravity on knight

        Animator anim; 
        


        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )

            anim = GetComponent<Animator>(); //assigning animator component to the knight(player)
            controller = GetComponent<ThirdPersonCharacter>();
        }


       void Update()
        {
           
           // Movement();
        }

        void Movement()
        {
            if (controller.isActiveAndEnabled)
            {
                if(Input.GetKey(KeyCode.W))
                {
                    anim.SetBool("running", true); //when the player moves, the ruuning parameter should be true
                    anim.SetInteger("condition", 1); // setting the condition parameter to 1 when W is pressed
                                                     // if the input key is W, move the player one step forward
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= speed; // this is to match the speed and movement of the player
                    moveDir = transform.TransformDirection(moveDir); // transforms the movement from local to global space
                }

                if (Input.GetKeyUp(KeyCode.W))
                {

                    anim.SetBool("running", false); // when the player is still, running paramter is set to false
                    anim.SetInteger("condition", 0); // seeting the condition parameter back to zero when we stop pressing W
                   //when we stop pressing W, don't move the player
                    moveDir = new Vector3(0, 0, 0);
                }

            }


            rotation += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            //this allows smooth rotation as the speed of ration gets updates with time on to the horizontal axis
            transform.localRotation = Quaternion.Euler(0, rotation, 0);
            // transform.eulerAngles = new Vector3(0, rotation, 0);
            // updates the eular angles (camera angles) and sets it at the rotation position

            moveDir.y -= gravity * Time.deltaTime; //updates gravity with time
            
            controller.Move(moveDir * Time.deltaTime); //moves the player while keeping it updates with time
        } 


        // Fixed update is called in sync with physics
       /*void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
        */
    }
}


