using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] Sprite playerSprite;
    [SerializeField] Sprite itemBoxSprite;
    [SerializeField] List<InventoryMenuItemBox> itemBoxes;
    [SerializeField] List<InventoryMenuItemBox> gearBoxes;
    [SerializeField] List<InventoryMenuItemBox> weaponBoxes;

    [SerializeField] GameObject gearMenu;
    [SerializeField] GameObject itemMenu;
    [SerializeField] TextMeshProUGUI itemMenuName;
    [SerializeField] TextMeshProUGUI itemMenuDescription;

    [SerializeField] GameObject ButtonEquip;
    [SerializeField] GameObject ButtonUnequip;
    [SerializeField] GameObject ButtonUse;
    [SerializeField] GameObject ButtonDrop;

    PlayerInventory playerInventory;
    InventoryObjectSO loadedItem;

    int maxItems = 0;
    int maxGear = 0;
    int maxWeapons = 0;

    public void CreateInventory(PlayerInventory p, int i, int g, int w)
    {
        playerInventory = p;
        maxItems = i;
        maxGear = g;
        maxWeapons = w;

        PopulateInventory();
    }

    void PopulateInventory()
    {
        CloseItemMenu();

        List<InventoryObjectSO> inventory = playerInventory.GetInventory();
        List<InventoryObjectSO> gear = playerInventory.GetGear();
        List<WeaponSO> weapons = playerInventory.GetWeapons();

        playerInventory.GetComponentInParent<Player>().OnWeaponChange3();

        for(int index = 0; index < maxItems; index++)
        {
            if(index < inventory.Count)
                itemBoxes[index].UpdateBox(inventory[index]);
        }

        for(int index = 0; index < maxGear; index++)
        {
            if(index < gear.Count)
                gearBoxes[index].UpdateBox(gear[index]);
        }

        for(int index = 0; index < maxWeapons; index++)
        {
            if(index < weapons.Count)
                weaponBoxes[index].UpdateBox(weapons[index]);
        }
    }

    public void UpdateItemMenu(InventoryObjectSO i, bool isEquipped)
    {
        loadedItem = i;
        if(loadedItem.getItemType() == "fakeObject")
        {
            return;
        }

        itemMenu.SetActive(true);
        gearMenu.SetActive(false);

        ButtonEquip.SetActive(false);
        ButtonUnequip.SetActive(false);
        ButtonUse.SetActive(false);
        ButtonDrop.SetActive(false);

        if(loadedItem.getItemType() == "MainWeapon" || loadedItem.getItemType() == "SideWeapon")
        {
            if(isEquipped)
                ButtonUnequip.SetActive(true);
            else
            {
                ButtonEquip.SetActive(true);
                ButtonDrop.SetActive(true);
            }
        }
        else if(loadedItem.getItemType() == "Consumable")
        {
            ButtonUse.SetActive(true);
            ButtonDrop.SetActive(true);
        }
        else
        {
            ButtonDrop.SetActive(true);
        }

        itemMenuName.text = loadedItem.getItemName();
        itemMenuDescription.text = loadedItem.getItemDescription();
    }

    public void Equip()
    {
        if(loadedItem.getItemType() == "MainWeapon")
        {
            if(playerInventory.GetWeapons()[0].getItemType() != "fakeObject")
                return;
            playerInventory.EquipWeapon(1, loadedItem as WeaponSO);
            playerInventory.removeFromInventory(loadedItem);
            PopulateInventory();
        }
        if(loadedItem.getItemType() == "SideWeapon")
        {
            if(playerInventory.GetWeapons()[1].getItemType() != "fakeObject")
                return;
            playerInventory.EquipWeapon(2, loadedItem as WeaponSO);
            playerInventory.removeFromInventory(loadedItem);
            PopulateInventory();
        }
    }

    public void Unequip()
    {
        if(loadedItem.getItemType() == "MainWeapon")
        {
            playerInventory.removeFromWeapons(0);
            playerInventory.addToItems(loadedItem);
            PopulateInventory();
        }
        if(loadedItem.getItemType() == "SideWeapon")
        {
            playerInventory.removeFromWeapons(1);
            playerInventory.addToItems(loadedItem);
            PopulateInventory();
        }
    }

    public void UseItem()
    {
        if(loadedItem.getItemType() == "Consumable")
        {
            playerInventory.removeFromInventory(loadedItem);
            PopulateInventory();
        }
    }

    public void DropItem()
    {
        Instantiate(loadedItem.getItemPrefab(), playerInventory.gameObject.transform.position, new Quaternion(0.0f, 0.0f , 0.0f, 1));
        playerInventory.removeFromInventory(loadedItem);
        PopulateInventory();
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
