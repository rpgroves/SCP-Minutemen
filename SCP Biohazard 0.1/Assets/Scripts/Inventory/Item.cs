using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject me;
    [SerializeField] ItemSO itemSO;

    Sprite spriteBlack;
    Sprite spriteGlow;

    void Awake()
    {
        spriteBlack = itemSO.getSpriteBlack();
        spriteGlow = itemSO.getSpriteGlow();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            this.GetComponentInParent<SpriteRenderer>().sprite = spriteGlow;
            other.GetComponentInParent<PlayerInventory>().setItem(me);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            this.GetComponentInParent<SpriteRenderer>().sprite = spriteBlack;
            other.GetComponentInParent<PlayerInventory>().unsetItem(me);
        }
    }

    public ItemSO GetItemSO()
    {
        return itemSO;
    }
}
