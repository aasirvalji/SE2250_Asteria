using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab = null;//public header to get enemeyPrefab

    Vector3 temp = new Vector3(441.0f, 2.0f, 200.0f);

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, temp, transform.rotation); //enemy appear on the field when game starts
    }


}
