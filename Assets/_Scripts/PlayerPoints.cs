using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    public int maxPoints = 1000;
    public Text pointsText;
    public int currentPoints;
    public PointsSlider pointsBar;
    public GameObject player;

    void Start()
    {
        pointsBar.SetMaxPoints(maxPoints);
        pointsBar.SetPoints(currentPoints);
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("PointPickup"))
        {
            GainPoints(10); //add this many points
            other.gameObject.SetActive(false); //then deactivate the pickup
        }

        if (other.tag.Equals("Teleporter"))
        {
            SceneManager.LoadScene("Level2");
        }
    }

    void GainPoints(int points)
    {
            currentPoints += points;

            pointsBar.SetPoints(currentPoints);
            pointsText.text = "Points: " + currentPoints;
        
    }
}


