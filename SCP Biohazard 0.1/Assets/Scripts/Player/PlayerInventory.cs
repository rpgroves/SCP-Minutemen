using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPrefab;

    List<GameObject> InteractablesInRange = new List<GameObject>();
    List<GameObject> ItemsInRange = new List<GameObject>();
    List<GameObject> NPCsInRange = new List<GameObject>();

    GameObject weapon1;
    GameObject weapon2;

    List<InventoryObjectSO> inventory = new List<InventoryObjectSO>();

    int maxItems = 15;

    public void Backpack()
    {
        InventoryMenu inventoryMenu = Instantiate(inventoryPrefab, GameObject.Find("Canvas").transform).GetComponent<InventoryMenu>();
        inventoryMenu.CreateInventory(this, maxItems);
    }

    public void EquipWeapon(int weaponNum, GameObject weapon)
    {

    }
    
    public void HandleInteract()
    {
        if(ItemsInRange.Count != 0)
        {
            GameObject i = ItemsInRange[0];
            if(inventory.Count < maxItems)
            {
                inventory.Add(i.GetComponent<InventoryObject>().GetSO());
                ItemsInRange.Remove(i);
                Destroy(i);
            }
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

    void InventoryToString()
    {
        foreach(InventoryObjectSO i in inventory)
        {
            Debug.Log(i.getItemName());
        }
    }
}
