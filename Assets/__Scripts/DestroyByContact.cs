using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public Vector3 destroyPosition;
    public GameObject ring;

    void OnTriggerEnter(Collider other)
	{
        if(other.tag== "Boundary") //ensures that the monster ignores contact with boundry
		{
            return;
		}

        if (other.tag == "RingPickup") //ensures that the monster ignores contact with boundry
        {
            
        }

        if (other.tag == "Player")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation); //spaws explosion after game object is destroyed

            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);

                // Code to execute after the delay

                SceneManager.LoadScene("PostLevel2");
            }

            StartCoroutine(ExecuteAfterTime(2));
        }


        Destroy(other.gameObject); //destroys the collider (i.e. bolt) 
        Destroy(gameObject); //destroys itself

        destroyPosition = other.transform.position;

        destroyPosition.y += 15f;

        Instantiate(ring, destroyPosition, other.transform.rotation); //spawns coin after gameobject is destroyed

        Stats.Points += 20;
        Stats.EnemiesRemaining -= 1;

    }
}
