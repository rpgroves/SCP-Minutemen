using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerMaxHealth = 100;
    [SerializeField] float playerHealth;
    PlayerMovement playerMovement;

    void Start()
    {
        playerHealth = playerMaxHealth;
        playerMovement = this.GetComponentInParent<PlayerMovement>();
    }

    public void TakeDamage(float damage)
    {
        playerHealth = playerHealth - damage;
        if(playerHealth >= 0)
        {
            playerHealth = 0;
            playerMovement.HandlePlayerDeath();
        }
    }
}
