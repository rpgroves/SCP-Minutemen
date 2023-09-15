using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] Sprite playerSprite;
    [SerializeField] Sprite itemBoxSprite;
    [SerializeField] List<InventoryMenuItemBox> itemBoxes;
    [SerializeField] List<InventoryMenuItemBox> gearBoxes;

    [SerializeField] ItemSO emptyItem;

    PlayerInventory playerInventory;
    int maxItems = 0;

    public void CreateInventory(PlayerInventory p, int i)
    {
        maxItems = i;
        playerInventory = p;

        List<ItemSO> inventory = playerInventory.GetInventory();
        for(int index = 0; index < maxItems; index++)
        {
            if(index < inventory.Count)
                itemBoxes[index].UpdateBox(inventory[index]);
            else
                itemBoxes[index].UpdateBox(emptyItem);
        }
    }

    public void menuStopped()
    {
        Destroy(gameObject);
    }
}
