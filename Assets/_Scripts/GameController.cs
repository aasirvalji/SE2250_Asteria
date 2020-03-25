using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour //this script is for spawning the sea creatures 
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount; //to get more than one creature
    public float spawnWait; //time between each spawn
    public float startWait; //time to allow player to get ready before game starts
    public float waveWait;//wait between waves

    void Start()//unity calls start at the beginning 
	{
        StartCoroutine(SpawnWaves());
	}

    //use IEnumerator because need to wait between spawns
    IEnumerator SpawnWaves()
	{
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                //spawn location
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

                Quaternion spawnRotation = Quaternion.identity; //no rotation 
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
	}
}
