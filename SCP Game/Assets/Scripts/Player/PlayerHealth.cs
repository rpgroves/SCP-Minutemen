using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerMaxHealth = 5;
    [SerializeField] int playerHealth = 5;
    [SerializeField] int playerMaxShield = 3;
    [SerializeField] int playerShield = 1;
    Player player;
    HealthBar healthBar;
    HealthBar shieldBar;
    [SerializeField] float shieldRechargeTimer = 5.0f;
    float timeSinceLastDamage = 0.0f;

    void Start()
    {
        playerHealth = playerMaxHealth;
        player = this.GetComponentInParent<Player>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        shieldBar = GameObject.Find("ShieldBar").GetComponent<HealthBar>();
        healthBar.CreateBar(playerHealth, playerMaxHealth);
        shieldBar.CreateBar(playerShield, playerMaxShield);
    }

    void Update()
    {
        timeSinceLastDamage += Time.deltaTime;
        //Debug.Log(timeSinceLastDamage);
        if(timeSinceLastDamage > shieldRechargeTimer)
        {
            HealShield();
            timeSinceLastDamage = 0.0f;
        }
    }

    public void HealHealth()
    {
        if(playerHealth <= playerMaxHealth)
        {
            playerHealth++;
            healthBar.GainHealth();
        }
    }

    public void HealShield()
    {
        if(playerShield <= playerMaxShield)
        {
            playerShield++;
            shieldBar.GainHealth();
        }
    }

    public void TakeDamage()
    {
        timeSinceLastDamage = 0.0f;
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
            player.HandlePlayerDeath();
        }
    }
}
