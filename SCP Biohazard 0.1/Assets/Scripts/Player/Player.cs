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

    void Start()
    {
        playerMovement = this.GetComponentInParent<PlayerMovement>();
        playerInventory = this.GetComponentInParent<PlayerInventory>();
        playerHealth = this.GetComponentInParent<PlayerHealth>();
    }

    void Update()
    {
        playerMovement.HandleMovement(rawInput);
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
}
