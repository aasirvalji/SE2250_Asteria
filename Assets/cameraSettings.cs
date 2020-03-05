using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSetting : MonoBehaviour
{
    public GameObject ThirdPersonController;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - ThirdPersonController.transform.position;
    }

    // Update is called once per frame
    void LateUpdate() // guarenteed to run after all items have been processed and updated
    {
        transform.position = ThirdPersonController.transform.position + offset;
    }
}