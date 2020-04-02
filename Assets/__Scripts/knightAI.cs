using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class knightAI : MonoBehaviour
{

    private NavMeshAgent badGuy;

    public GameObject Player;

    public float MobDistanceRun = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        badGuy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);


        Vector3 dirToPlayer = transform.position - Player.transform.position;

        Vector3 newPos = transform.position - dirToPlayer;

        badGuy.SetDestination(newPos);


    }
}
