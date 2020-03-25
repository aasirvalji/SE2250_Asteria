using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
	{
        if(other.tag== "Boundary") //ensures that the monster ignores contact with boundry
		{
            return;
		}

        Destroy(other.gameObject); //destroys the collider (i.e. bolt) 
        Destroy(gameObject); //destroys itself
	}
}
