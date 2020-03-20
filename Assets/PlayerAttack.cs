using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            
            GameObject fireball = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
            Destroy(fireball, 3.0f);
        }
    }
}
