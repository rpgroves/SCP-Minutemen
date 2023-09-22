using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public UnityEvent startTimer;
    [SerializeField] GameObject me;
    [SerializeField] int enemyHealth = 100;

    public void TakeDamage(int damage)
    {
        this.GetComponentInParent<SpriteRenderer>().color = Color.red;
        startTimer.Invoke();

        enemyHealth -= damage;
        if(enemyHealth < 0)
            enemyHealth = 0;
        if(enemyHealth == 0)
        {
            Destroy(me);
        }
    }

    public void TurnColorWhite()
    {
        this.GetComponentInParent<SpriteRenderer>().color = Color.white;
    }
}
