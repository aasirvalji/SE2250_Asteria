using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefabVar;


    void Start()
    {
        for (int i = 0; i < 1; i ++) {
            StartCoroutine(ExecuteAfterTime(2));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay


        Vector3 v = new Vector3(400f, 19f, 195f);
        GameObject gObj = Instantiate<GameObject>(cubePrefabVar);
        Color c = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = c;
        gObj.transform.position = v;
    }
}
