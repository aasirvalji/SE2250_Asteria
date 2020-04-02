using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;

    public Vector3 fireballSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            fireballSpawn = transform.position;
            fireballSpawn.y += 6.2f;

            GameObject fireball = Instantiate(projectile, fireballSpawn, transform.rotation) as GameObject;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
            Destroy(fireball, 5.0f);

        }

    }





}
