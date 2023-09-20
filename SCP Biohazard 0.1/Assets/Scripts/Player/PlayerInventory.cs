using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPrefab;

    List<GameObject> InteractablesInRange = new List<GameObject>();
    List<GameObject> ItemsInRange = new List<GameObject>();
    List<GameObject> NPCsInRange = new List<GameObject>();

    [SerializeField] WeaponSO weaponEmpty;
    [SerializeField] ItemSO emptyItem;

    List<InventoryObjectSO> inventory = new List<InventoryObjectSO>();
    List<InventoryObjectSO> gear = new List<InventoryObjectSO>();
    List<WeaponSO> weapons = new List<WeaponSO>();

    int maxItems = 15;
    int maxGear = 3;
    int maxWeapons = 2;

    void Start()
    {
        weapons.Add(weaponEmpty);
        weapons.Add(weaponEmpty);
        weapons.Add(weaponEmpty);
        for(int index = 0; index < maxItems; index++)
            inventory.Add(emptyItem);
    }

    public void Backpack()
    {
        InventoryMenu inventoryMenu = Instantiate(inventoryPrefab, GameObject.Find("Canvas").transform).GetComponent<InventoryMenu>();
        inventoryMenu.CreateInventory(this, maxItems, maxGear, maxWeapons);
    }

    public void EquipWeapon(int weaponNum, WeaponSO weapon)
    {
        weapons[weaponNum - 1] = weapon;
    }

    public WeaponSO getWeapon(int num)
    {
        return weapons[num - 1];
    }
    
    public void HandleInteract()
    {
        if(ItemsInRange.Count != 0)
        {
            GameObject i = ItemsInRange[0];
            for(int index = 0; index < maxItems; index++)
            {
                if(inventory[index].getItemType() == "fakeObject")
                {
                    inventory[index] = i.GetComponent<InventoryObject>().GetSO();
                    ItemsInRange.Remove(i);
                    Destroy(i);
                    return;
                }
            }
            Debug.Log("inventory full!");
        }
        else if(InteractablesInRange.Count != 0)
        {
            InteractablesInRange[0].GetComponent<Interactable>().PlayerInteraction();
        }
        else if(NPCsInRange.Count != 0)
        {
            NPCsInRange[0].GetComponent<NPCController>().PlayerInteraction();
        }
    }

    public void setInteractable(GameObject ob)
    {
        InteractablesInRange.Add(ob);
    }

    public void unsetInteractable(GameObject ob)
    {
        InteractablesInRange.Remove(ob);
    }

    public void setItem(GameObject ob)
    {
        ItemsInRange.Add(ob);
    }

    public void unsetItem(GameObject ob)
    {
        ItemsInRange.Remove(ob);
    }

    public void setNPC(GameObject ob)
    {
        NPCsInRange.Add(ob);
    }

    public void unsetNPC(GameObject ob)
    {
        NPCsInRange.Remove(ob);
    }

    public List<InventoryObjectSO> GetInventory()
    {
        return inventory;
    }

    public List<InventoryObjectSO> GetGear()
    {
        return gear;
    }

    public List<WeaponSO> GetWeapons()
    {
        return weapons;
    }

    public void removeFromInventory(InventoryObjectSO i)
    {
        inventory.Remove(i);
        inventory.Add(emptyItem);
    }

    public void removeFromGear(InventoryObjectSO i)
    {
        gear.Remove(i);
    }

    public void removeFromWeapons(int i)
    {
        weapons[i] = weaponEmpty;
    }

    public void addToItems(InventoryObjectSO i)
    {
        for(int index = 0; index < maxItems; index++)
        {
            if(inventory[index].getItemType() == "fakeObject")
            {
                inventory[index] = i;
                return;
            }
        }
    }
}
