using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("success");
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 50 * Time.deltaTime, 50 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
