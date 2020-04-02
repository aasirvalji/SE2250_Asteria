using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2EnemiesRemaining : MonoBehaviour
{

    public Text remainingText;
    private int remainingNum;

    // Start is called before the first frame update
    void Start()
    {
        remainingNum = int.Parse(remainingText.text);
        Stats.EnemiesRemaining = remainingNum;
        print(Stats.EnemiesRemaining);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Stats.EnemiesRemaining <= 0)
        {
            print("reached");
            SceneManager.LoadScene("Level3Castle");
        }
        else
        {
            remainingText.text = Stats.EnemiesRemaining.ToString();
        }
    }
}
