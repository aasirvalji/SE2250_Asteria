using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyScript : MonoBehaviour
{

    public GameObject Player;
    float MoveSpeed = 10f;
    int MaxDist = 10;
    int MinDist = 5;

    private Rigidbody rb;
    Vector3 direction;
    


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        direction = Player.transform.position - rb.transform.position;

        if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
        {
            rb.MovePosition(transform.position + (direction * MoveSpeed * Time.deltaTime));


            if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }

        }
    }
}