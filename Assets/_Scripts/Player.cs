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
    public GameObject playerBody;
    Animator anim; // defining an animator type variable


    public GameObject gameOver;

    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>(); //assigning animator component to the player

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
            print("damage taken");
            healthBar.SetHealth(currentHealth);
            healthText.text = "Health: " + currentHealth;
        }
        else if (currentHealth <= 20)
        {
            anim.SetBool("Dying", true);  // player does the dying animation when the health goes to zero

            gameOver.SetActive(true); // displays the message 'Game Over'

            print("printing from Player.cs script");
            //SkinnedMeshRenderer temp = playerBody.GetComponent<SkinnedMeshRenderer>();
            //temp.enabled = false;
        }
    }

    
}


