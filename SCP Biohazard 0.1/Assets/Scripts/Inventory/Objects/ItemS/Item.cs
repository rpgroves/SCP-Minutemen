using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, InventoryObject
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            this.GetComponentInParent<SpriteRenderer>().sprite = spriteGlow;
            other.GetComponentInParent<PlayerInventory>().setItem(me);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            this.GetComponentInParent<SpriteRenderer>().sprite = spriteBlack;
            other.GetComponentInParent<PlayerInventory>().unsetItem(me);
        }
    }

    public InventoryObjectSO GetSO()
    {
        return itemSO;
    }
}
