using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerMaxHealth = 5;
    [SerializeField] int playerHealth = 5;
    [SerializeField] int playerMaxShield = 3;
    [SerializeField] int playerShield = 1;
    PlayerMovement playerMovement;
    HealthBar healthBar;
    HealthBar shieldBar;

    void Start()
    {
        playerHealth = playerMaxHealth;
        playerMovement = this.GetComponentInParent<PlayerMovement>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        shieldBar = GameObject.Find("ShieldBar").GetComponent<HealthBar>();
        healthBar.CreateBar(playerHealth, playerMaxHealth);
        shieldBar.CreateBar(playerShield, playerMaxShield);
    }

    public void HealHealth(int healAmount)
    {
        playerHealth += healAmount;
        if(playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
    }

    public void HealShield(int healAmount)
    {
        playerShield += healAmount;
        if(playerShield > playerMaxShield)
        {
            playerShield = playerMaxShield;
        }
    }

    public void TakeDamage()
    {
        if(playerShield >= 0)
        {
            shieldBar.TakeDamage();
            playerShield--;
        }
        else
        {
            healthBar.TakeDamage();
            playerHealth--;
        }

        if(playerHealth == 0)
        {
            playerMovement.HandlePlayerDeath();
        }
    }
}
