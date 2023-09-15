using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPrefab;

    List<GameObject> InteractablesInRange = new List<GameObject>();
    List<GameObject> ItemsInRange = new List<GameObject>();
    List<GameObject> NPCsInRange = new List<GameObject>();

    List<ItemSO> inventory = new List<ItemSO>();

    int maxItems = 15;

    public void Backpack()
    {
        InventoryMenu inventoryMenu = Instantiate(inventoryPrefab, GameObject.Find("Canvas").transform).GetComponent<InventoryMenu>();
        inventoryMenu.CreateInventory(this, maxItems);
    }
    
    public void HandleInteract()
    {
        if(ItemsInRange.Count != 0)
        {
            GameObject i = ItemsInRange[0];
            if(inventory.Count < maxItems)
            {
                inventory.Add(i.GetComponent<Item>().GetItemSO());
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

    public List<ItemSO> GetInventory()
    {
        return inventory;
    }

    void InventoryToString()
    {
        foreach(ItemSO i in inventory)
        {
            Debug.Log(i.getItemName());
        }
    }
}
