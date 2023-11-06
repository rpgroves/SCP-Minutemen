using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCP106Barrier : MonoBehaviour
{
    [SerializeField] int barrierHealth = 100;
    [SerializeField] Sprite sprite2;
    [SerializeField] Sprite sprite3;
    [SerializeField] Sprite sprite4;
    SpriteRenderer spriteRenderer;
    float redTimer = 0.0f;
    bool resetColor = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(resetColor)
        {
            redTimer += Time.deltaTime;
            if(redTimer >= .5f)
            {
                TurnColorWhite();
                resetColor = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        this.GetComponentInParent<SpriteRenderer>().color = Color.red;
        resetColor = true;

        barrierHealth -= damage;
        if(barrierHealth <= 0)
        {
            Destroy(this.gameObject);
        }
        if(barrierHealth <= 80)
        {
            spriteRenderer.sprite = sprite2;
        }
        if(barrierHealth <= 60)
        {
            spriteRenderer.sprite = sprite3;
        }
        if(barrierHealth <= 30)
        {
            spriteRenderer.sprite = sprite4;
        }
    }

    public void TurnColorWhite()
    {
        this.GetComponentInParent<SpriteRenderer>().color = Color.white;
    }
}
