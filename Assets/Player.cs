using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public Text healthText;
    public int currentHealth;
    public HealthSlider healthBar;
    public GameObject player;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            TakeDamage(20);
        }

        if (other.tag.Equals("Food"))
        {
            GetHealth(20);
            other.gameObject.SetActive(false); //then deactivate the food
        }

        if (other.tag.Equals("Teleporter"))
        {
            SceneManager.LoadScene("Level2");
        }
    }

    void GetHealth(int health)
    {
        if (currentHealth == 100)
        {
            Debug.Log("Full health");
            healthText.text = "Health: " + currentHealth;
        }
        else
        {
            currentHealth += health;

            healthBar.SetHealth(currentHealth);
            healthText.text = "Health: " + currentHealth;
        }
    }

    void TakeDamage(int damage)
    {
        if (currentHealth >= 20)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
            healthText.text = "Health: " + currentHealth;
        }
        else if (currentHealth <= 0)
        {
            player.SetActive(false);
        }
    }
}


