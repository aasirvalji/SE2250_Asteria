using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newEnenmyScript : MonoBehaviour
{
    public Transform player;
    static Animator anim;
    float speed = 10.0f; // spped of the player
    CharacterController controller; //defining a characterController type variable
    Vector3 moveDir = Vector3.zero; // player would be still once game starts until it is moved

    public Player playerScript;
    private float nextUpdate = 1.5f;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>(); //assigning characterController component to the player
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 70) //checks the distance between player and knight
        {
            Vector3 direction = player.position - this.transform.position; //work out the direction
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f); //make the knight rotate towards the player

            anim.SetBool("idle", false);
            if (direction.magnitude > 20)
            {
                anim.SetBool("walking", true);
                anim.SetBool("attacking", false);
                //  this.transform.Translate(0, 0, 1f);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir); // transforms the movement from local to global space

            }
            else
            {




                anim.SetBool("walking", false);
                anim.SetBool("attacking", true);


                if (Time.time >= nextUpdate)
                {
                    // Change the next update (current second+1)
                    nextUpdate = Mathf.FloorToInt(Time.time) + 1;
                    // Call your fonction
                    UpdateEverySecond();
                }

                void UpdateEverySecond()
                { 
                    playerScript.TakeDamage(10);
                }

            }
        }

        else
        {
            anim.SetBool("walking", false);
            anim.SetBool("idle", true);
            anim.SetBool("attacking", false);
        }

        controller.Move(moveDir * Time.deltaTime); //moves the player while keeping it updates with time

    }

    IEnumerator DoCheck()
    {
            // execute block of code here
            yield return new WaitForSeconds(2f);

            playerScript.TakeDamage(20);
        
    }

}
