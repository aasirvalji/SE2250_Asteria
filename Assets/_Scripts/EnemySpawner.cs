using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab = null;//public header to get enemeyPrefab

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity); //enemy appear on the field when game starts
    }


}
