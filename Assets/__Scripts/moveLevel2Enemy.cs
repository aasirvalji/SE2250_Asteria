using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLevel2Enemy : MonoBehaviour
{

    public float fSpeed;
  
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(2 * transform.position - (GameObject.FindWithTag("Player").transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(2 * transform.position - (GameObject.FindWithTag("Player").transform.position));
       
        transform.position += new Vector3(fSpeed, 0, -fSpeed); //moves enemy along the negative z-axis
    }
}
