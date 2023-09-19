using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemBox : MonoBehaviour
{
    [SerializeField] GameObject ItemBoxImage;
    [SerializeField] InventoryMenu inventoryMenu;
    InventoryObjectSO item;

    Canvas canvas;
    Camera mainCamera;

    void Awake()
    {
        canvas = transform.root.GetComponent<Canvas>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        
    }

    public void ClickBox()
    {
        inventoryMenu.UpdateItemMenu(item);
    }

    public void UpdateBox(InventoryObjectSO i)
    {
        item = i;
        ItemBoxImage.GetComponent<Image>().sprite = item.getSpriteBlack();
    }
}
