using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] Sprite playerSprite;
    [SerializeField] Sprite itemBoxSprite;
    [SerializeField] ItemSO emptyItem;
    [SerializeField] List<InventoryMenuItemBox> itemBoxes;
    [SerializeField] List<InventoryMenuItemBox> gearBoxes;
    [SerializeField] List<InventoryMenuItemBox> weaponBoxes;
    [SerializeField] GameObject gearMenu;
    
    [SerializeField] GameObject itemMenu;
    [SerializeField] TextMeshProUGUI itemMenuName;
    [SerializeField] TextMeshProUGUI itemMenuDescription;

    PlayerInventory playerInventory;
    int maxItems = 0;
    bool isItemMenuOpen = false;

    void Start()
    {
        itemMenu.SetActive(false);
    }

    public void CreateInventory(PlayerInventory p, int i)
    {
        maxItems = i;
        playerInventory = p;

        List<InventoryObjectSO> inventory = playerInventory.GetInventory();
        for(int index = 0; index < maxItems; index++)
        {
            if(index < inventory.Count)
                itemBoxes[index].UpdateBox(inventory[index]);
            else
                itemBoxes[index].UpdateBox(emptyItem);
        }
    }

    public void UpdateItemMenu(InventoryObjectSO i)
    {
        if(!isItemMenuOpen)
        {
            itemMenu.SetActive(true);
            gearMenu.SetActive(false);

            itemMenuName.text = i.getItemName();
            itemMenuDescription.text = i.getItemDescription();
        }
    }

    public void CloseItemMenu()
    {
        itemMenu.SetActive(false);
        gearMenu.SetActive(true);
    }

    public void menuStopped()
    {
        Destroy(gameObject);
    }
}
