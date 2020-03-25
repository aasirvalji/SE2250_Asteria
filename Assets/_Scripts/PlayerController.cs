using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//so we can see it in the inspector 
public class Boundary //for organizational purposes, create a boundary class 
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour
{
    public float speed; //to be set in the inspector
    public float tilt;
    public Boundary boundary;

    public GameObject shot; //bolt prefab
    public GameObject shotSpawn;
    public float fireRate;

    private float _nextFire;

    void Update()
	{
        //shooting
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
		{
            _nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
        }
    
	}
    

    // called every physics step
    void FixedUpdate()
    {
        //to get position
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //we don't want player to move up, so zero y-axes 
        Vector3 movement= new Vector3(moveHorizontal, 0.0f, moveHorizontal);
        GetComponent<Rigidbody>().velocity = movement * speed; //move the player

        //need to keep the ship on the plane/create boundries 
        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));

        //tilt the ship
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
