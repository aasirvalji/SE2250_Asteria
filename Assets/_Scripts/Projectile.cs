using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject projectilePrefab; //to get the projectile prefab
    public float projectileSpeed; //speed


    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space)) //if user presses space bar, the player should shoot
        {
            TempFire();

        }
    }

    void TempFire() //shooting ability 
      {

        

          GameObject projGo = Instantiate<GameObject>(projectilePrefab);
          projGo.transform.position = transform.position;
          //projGo.transform.rotation= Quaternion.Euler(0.0f, 0.0f, 0.0f);

          projGo.GetComponent<Rigidbody>().velocity = gameObject.transform.position + Vector3.forward * projectileSpeed;
          //destroy after 3 seconds
          Destroy(projGo, 3);


          }

}
