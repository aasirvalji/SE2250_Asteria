using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // healthbar variables
    public RectTransform healthTransform;
    private float cachedY;
    private float minX;
    private float maxX;
    private int currentHealth;
    public int maxHealth;
    public Text healthText;
    public Image visualHealth;
    // method for returning can calling HandleHealth for health bar
    private int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            HandleHealth();
        }
    }

    // variable for coolDown
    public float coolDown;
    // determines if player can take damage
    private bool onCD;

    // exp and level variables
    public RectTransform expTransform;
    private int currentLevel = 1;
    public int expLevel;
    public int maxExp;
    public int minExp;
    public Text expText;
    public Image visualExp;

    private int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }


    void Start()
    {
        // making sure healthbar stays in the same place
        cachedY = healthTransform.position.y;
        maxX = healthTransform.position.x;
        minX = healthTransform.position.x - healthTransform.rect.width;
        currentHealth = maxHealth;
        onCD = false;

        // making sure exp bar stays in same place;
        cachedY = expTransform.position.y;
        maxX = expTransform.position.x;
        minX = expTransform.position.x - expTransform.rect.width;
        currentLevel = minExp;
    }

    void OnTriggerStay(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        // if food found, replenish health
        if (other.name == "Food")
        {
            if (!onCD && currentHealth < maxHealth)
            {
                StartCoroutine(CoolDownDmg());
                CurrentHealth += 1;
            }
        }

        // if enemy does damage, decrease health

            if (other.name == "Damage")
            {
                if (!onCD && currentHealth > 0)
                {
                    StartCoroutine(CoolDownDmg());
                    CurrentHealth -= 50;
                }

            }
        }
    

    private void HandleHealth()
    {
        //text of healthbar
        healthText.text = "Health: " + currentHealth;

        //getting position of healthbar
        float currentXValue = MapValues(currentHealth, 0, maxHealth, minX, maxX);
        healthTransform.position = new Vector3(currentXValue, cachedY);

        //changing color of health bar
        if (currentHealth > maxHealth / 2) //more than 50% health
        {
            visualHealth.color = new Color32((byte)MapValues(currentHealth, maxHealth / 2, maxHealth, 255, 0), 255, 0, 255);
        }
        else // less than 50% health
        {
            visualHealth.color = new Color32(255, (byte)MapValues(currentHealth, 0, maxHealth / 2, 0, 255), 0, 255);
        }
    }


    IEnumerator CoolDownDmg()
    {
        onCD = true;
        yield return new WaitForSeconds(coolDown);
        onCD = false;
    }

    // mapping the values for the healthbar to increase and decrease
    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return ((x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);
    }
}