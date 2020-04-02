using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    public int maxPoints = 1000;
    public Text pointsText;
    public PointsSlider pointsBar;
    public GameObject player;

    void Start()
    {
        print(Stats.Points);
        pointsBar.SetMaxPoints(maxPoints);
        pointsBar.SetPoints(Stats.Points);
        pointsText.text = "Points: " + Stats.Points.ToString();
    }

    void Update()
    {
        pointsBar.SetPoints(Stats.Points);
        pointsText.text = "Points: " + Stats.Points.ToString();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("PointPickup"))
        {
            GainPoints(10); //add this many points
            other.gameObject.SetActive(false); //then deactivate the pickup
        }


        if (other.tag.Equals("RingPickup"))
         
        {
            print(other.gameObject);
            GainPoints(30); //add this many points
            other.gameObject.SetActive(false); //then deactivate the pickup
        }


    }

    void GainPoints(int points)
    {
        Stats.Points += points;

        
        pointsText.text = "Points: " + Stats.Points;

    }
}
