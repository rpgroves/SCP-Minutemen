using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon", fileName = "WeaponSO")]
public class WeaponSO : ScriptableObject, InventoryObjectSO
{
    [SerializeField] string itemName;
    [SerializeField] string itemType;
    [TextArea()]
    [SerializeField] string itemDescription;
    [SerializeField] Sprite spriteBlack;
    [SerializeField] Sprite spriteGlow;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Sprite fullBullet;
    [SerializeField] Sprite emptyBullet;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] int damage;
    [SerializeField] int rateOfFire;
    [SerializeField] int capacity;
    [SerializeField] int spread;

    public string getItemName()
    {
        return itemName;
    }
    public string getItemType()
    {
        return itemType;
    }
    public string getItemDescription()
    {
        return itemDescription;
    }
    public Sprite getSpriteBlack()
    {
        return spriteBlack;
    }
    public Sprite getSpriteGlow()
    {
        return spriteGlow;
    }
    public GameObject getItemPrefab()
    {
        return itemPrefab;
    }


    public Sprite getFullBullet()
    {
        return fullBullet;
    }
    public Sprite getEmptyBullet()
    {
        return emptyBullet;
    }
    public GameObject getBulletPrefab()
    {
        return bulletPrefab;
    }

    
    public int getDamage()
    {
        return damage;
    }
    public int getRateOfFire()
    {
        return rateOfFire;
    }
    public int getCapacity()
    {
        return capacity;
    }
    public int getSpread()
    {
        return spread;
    }
}
