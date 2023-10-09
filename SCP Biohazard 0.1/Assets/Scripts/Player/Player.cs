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
        HandleWeaponRotation();
    }

    void HandleWeaponPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        weaponParent.PointerPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }

    void HandleWeaponRotation()
    {
        if(((weaponParent.PointerPosition - (Vector2)transform.position).normalized).x < 0)
        {
            weaponParent.Rotate(-(weaponParent.PointerPosition - (Vector2)transform.position).normalized, false);
        }
        else
        {
            weaponParent.Rotate((weaponParent.PointerPosition - (Vector2)transform.position).normalized, true);
        }
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire()
    {
        playerInventory.ShootBullet();
        weaponParent.HandleFire();
    }

    void OnReload()
    {
        weaponParent.Reload(playerInventory.Reload());
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
            playerInventory.UseWeapon(w);
        }
    }

    void OnWeaponChange2()
    {
        WeaponSO w = playerInventory.getWeapon(2);
        if(w.getItemType() != "fakeObject")
        {
            weaponParentObject.SetActive(true);
            weaponParent.ChangeWeapon(w);
            playerInventory.UseWeapon(w);
        }
    }

    public void OnWeaponChange3()
    {
        weaponParentObject.SetActive(false);
        playerInventory.UseWeapon(playerInventory.getWeapon(3));
    }
}
