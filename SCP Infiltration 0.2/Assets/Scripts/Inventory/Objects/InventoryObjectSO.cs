using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InventoryObjectSO
{
    string getItemName();
    string getItemType();
    string getItemDescription();
    Sprite getSpriteBlack();
    Sprite getSpriteGlow();
}
