using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public UnityEvent startTimer;
    [SerializeField] GameObject me;
    [SerializeField] int enemyHealth = 100;
    [SerializeField] int currentHealth;

    void Start()
    {
        currentHealth = enemyHealth;
    }

    public void TakeDamage(int damage)
    {
        this.GetComponentInParent<SpriteRenderer>().color = Color.red;
        startTimer.Invoke();

        currentHealth -= damage;
        if(currentHealth < 0)
            currentHealth = 0;
        if(currentHealth == 0)
        {
            Destroy(me);
        }
    }

    public void TurnColorWhite()
    {
        this.GetComponentInParent<SpriteRenderer>().color = Color.white;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return enemyHealth;
    }
}
