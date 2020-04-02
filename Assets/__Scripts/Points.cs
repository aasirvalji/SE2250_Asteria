using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public GameObject projectile;
    public TextScript pointsText;

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
        {
            pointsText.setText("yooooooo");
            
        }  
    }
}
