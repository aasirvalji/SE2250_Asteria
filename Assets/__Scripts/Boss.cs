using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int maxHealth = 2000;
    public Text healthText;
    public int currentHealth;
    public HealthSlider healthBar;

    public GameObject gameOver;

    private Vector3 bossToPlayerDistance;

    void Start()
    {

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthText.text = "Boss: " + maxHealth.ToString();

    }

    void Update()
    {
        /*
                bossToPlayerDistance = this.transform.position - boss.position;

                if (bossToPlayerDistance.magnitude < 10)
                {
                    TakeDamage(20);

                } */
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Fire"))
        {
            TakeDamage(20);
        }


    }


    public void TakeDamage(int damage)
    {
        if (currentHealth >= 20)
        {
            currentHealth -= damage;
            print("damage taken");
            healthBar.SetHealth(currentHealth);
            healthText.text = "Health: " + currentHealth;
        }
        else if (currentHealth <= 20)
        {
            gameOver.SetActive(true); // displays the message 'Game Over'

            print("printing from Player.cs script");
            //SkinnedMeshRenderer temp = playerBody.GetComponent<SkinnedMeshRenderer>();
            //temp.enabled = false;
        }
    }


}


