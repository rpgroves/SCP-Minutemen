using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    PlayerMovement playerMovement;
    PlayerInventory playerInventory;
    PlayerHealth playerHealth;
    [SerializeField] GameObject weaponParentObject;
    WeaponParent weaponParent;
    bool isPlayerInControl = true;
    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] TextMeshProUGUI text2;
    bool isClearingText = false;
    float timer = 0.0f;
    [SerializeField] float textClearTimer = 1.5f;
    public static Player Instance { get; private set; }

    void Awake()
    {
        int numPlayers = FindObjectsOfType<Player>().Length;
        if(numPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        text1.text = "";
        text2.text = "";
        
        playerMovement = this.GetComponentInParent<PlayerMovement>();
        playerInventory = this.GetComponentInParent<PlayerInventory>();
        playerHealth = this.GetComponentInParent<PlayerHealth>();
        weaponParent = weaponParentObject.GetComponent<WeaponParent>();
        weaponParentObject.SetActive(false);

        GameManager.Instance.SetupInventory(playerInventory);
    }

    void Update()
    {
        if(isClearingText)
        {
            if(timer > textClearTimer)
            {
                timer = 0.0f;
                isClearingText = false;
                text1.text = "";
                text2.text = "";
            }
            else
                timer += Time.deltaTime;
        }
        if(isPlayerInControl)
        {
            playerMovement.HandleMovement(rawInput);
            HandleWeaponPosition();
            HandleWeaponRotation();
        }
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

    public void HandlePlayerDeath()
    {
        playerMovement.HandlePlayerDeath();
        OnWeaponChange3();
        isPlayerInControl = false;
        GameManager.Instance.ReloadScene();
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

    public PlayerInventory GetInventory()
    {
        return playerInventory;
    }

    public void SetText(string s)
    {
        text1.text = s;
        text2.text = s;
        isClearingText = true;
    }
}
