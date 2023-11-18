using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "ItemSO")]
public class ItemSO : ScriptableObject, InventoryObjectSO
{
    [SerializeField] string itemName;
    [SerializeField] string itemType;
    [TextArea()]
    [SerializeField] string itemDescription;
    [SerializeField] Sprite spriteBlack;
    [SerializeField] Sprite spriteGlow;
    [SerializeField] GameObject itemPrefab;

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
}
