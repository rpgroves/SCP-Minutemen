using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] int maxHearts = 5;

    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    public void CreateBar(int h, int mh)
    {
        health = h;
        maxHearts = mh;
        PrintHearts();
    }

    public void GainHealth()
    {
        health++;
        PrintHearts();
    }

    public void LoseDamage()
    {
        health--;
        PrintHearts();
    }

    public int getMaxHearts()
    {
        return maxHearts;
    }

    public void setMaxHearts(int h)
    {
        maxHearts = h;
        PrintHearts();
    }

    void PrintHearts()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i >= maxHearts)
                hearts[i].enabled = false;
            else
                hearts[i].enabled = true;
            if(i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }
}
