using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, InventoryObject
{
    [SerializeField] GameObject me;
    [SerializeField] WeaponSO weaponSO;

    Sprite spriteBlack;
    Sprite spriteGlow;

    void Awake()
    {
        spriteBlack = weaponSO.getSpriteBlack();
        spriteGlow = weaponSO.getSpriteGlow();
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
        return weaponSO;
    }
}
