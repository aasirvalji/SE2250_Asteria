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
    public ethanController disableMovementOnDeath;
    Animator anim; // defining an animator type variable


    public GameObject gameOver;
    public GameObject restartLevel;

    private Vector3 bossToPlayerDistance;
    public Transform boss;

    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthText.text = "Health: " + maxHealth.ToString();
        anim = GetComponent<Animator>(); //assigning animator component to the player

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
            SceneManager.LoadScene("PostLevel1");
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

    public void TakeDamage(int damage)
    {
        if (currentHealth >= 10)
        {
            currentHealth -= damage;
            print("damage taken");
            healthBar.SetHealth(currentHealth);
            healthText.text = "Health: " + currentHealth;
        }
        else if (currentHealth < 10)
        {
            /* Stats.ButtonsEnabled = false; */
            anim.SetBool("walking", false); 
            anim.SetBool("running", false); 
            anim.SetBool("Dying", true);  // player does the dying animation when the health goes to zero

            gameOver.SetActive(true); // displays the message 'Game Over'
            restartLevel.SetActive(true); //shows reset button

            print("printing from Player.cs script");
            //SkinnedMeshRenderer temp = playerBody.GetComponent<SkinnedMeshRenderer>();
            //temp.enabled = false;
        }
    }

    
}


