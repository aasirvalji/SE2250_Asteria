using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyKnight : MonoBehaviour
{
    private NavMeshAgent badGuy;

    public GameObject Player;
    //defining aatributes for this class

    float speed = 40.0f; // spped of the knight
    float rotSpeed = 80.0f; // rotation speed of knight
    float rotation = 0.0f;
    float gravity = 8.0f; // the effect of gravity on knight

    Vector3 moveDir = Vector3.zero; // knight would be still once game starts until it is moved


    public float MobDistanceRun = 0.1f;

    CharacterController controller; //defining a characterController type variable
    Animator anim; // defining an animator type variable


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); //assigning characterController component to the knight(player)
        anim = GetComponent<Animator>(); //assigning animator component to the knight(player)
        badGuy = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        Movement(); // calling the movement method on every frame
        
    }

    void Movement()
    {
            float distance = Vector3.Distance(transform.position, Player.transform.position);


            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            badGuy.SetDestination(newPos);
   

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

