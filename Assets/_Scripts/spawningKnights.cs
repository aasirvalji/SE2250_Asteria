using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawningKnights : MonoBehaviour
{
    public float enemySpawnPerSecond = 3f; // enenemies/second that would be spawned
    public float enemyDefaultPadding = 1.5f; // enemies would be atleast 1.5f apart
    public GameObject[] prefabEnenmies; //creating array of enemy prefabs
    // Start is called before the first frame update
    void Start()
    {
        //invoke enemies every  1/3 seconds based on the default values
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    // Update is called once per frame
    /*void Update()
    {

        
    }*/

    void SpawnEnemy()
    {
        //pick a random enemy prefab to instantiate
        int randEnemy = Random.Range(0, prefabEnenmies.Length);
        GameObject enem = Instantiate<GameObject>(prefabEnenmies[randEnemy]); //we are creating an array of enemyPrefabs
                                                                              // we would only have one type of enemy for now


        Vector3 pos = Vector3.zero; // setting the vector to zero first

        // here we need to define pixed x and y position for the enemies based on our map design where they will be spawning

        //pos.x =xyz;
        //pos.y=ABC;

        enem.transform.position = pos; // the enemy postion is transformed here

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); // invoking the enemies every 1/3 seconds
        // recursive function call
    }
}
