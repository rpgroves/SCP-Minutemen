using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    PlayerMovement playerMovement;
    PlayerInventory playerInventory;
    PlayerHealth playerHealth;
    [SerializeField] GameObject weaponParentObject;
    WeaponParent weaponParent;

    void Start()
    {
        playerMovement = this.GetComponentInParent<PlayerMovement>();
        playerInventory = this.GetComponentInParent<PlayerInventory>();
        playerHealth = this.GetComponentInParent<PlayerHealth>();
        weaponParent = weaponParentObject.GetComponent<WeaponParent>();
        weaponParentObject.SetActive(false);
    }

    void Update()
    {
        playerMovement.HandleMovement(rawInput);
        HandleWeaponPosition();
    }

    void HandleWeaponPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        weaponParent.PointerPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnReload()
    {
        Debug.Log("reloading!");
    }

    void OnBackpack()
    {
        playerInventory.Backpack();
    }

    void OnInteract()
    {
        playerInventory.HandleInteract();
    }

    void OnRun()
    {
        playerMovement.Run();
    }

    void OnWeaponChange1()
    {
        WeaponSO w = playerInventory.getWeapon(1);
        if(w.getItemType() != "fakeObject")
        {
            weaponParentObject.SetActive(true);
            weaponParent.ChangeWeapon(w);
        }
    }

    void OnWeaponChange2()
    {
        WeaponSO w = playerInventory.getWeapon(2);
        if(w.getItemType() != "fakeObject")
        {
            weaponParentObject.SetActive(true);
            weaponParent.ChangeWeapon(w);
        }
    }

    public void OnWeaponChange3()
    {
        weaponParentObject.SetActive(false);
    }
}
