using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    [SerializeField] List<InventoryObjectSO> inventory;
    [SerializeField] List<InventoryObjectSO> gear;
    [SerializeField] List<WeaponSO> weapons;
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        int numGameManagers = FindObjectsOfType<GameManager>().Length;
        if(numGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
    }

    public void SetupInventory(PlayerInventory PI)
    {
        if(inventory != null && PI != null)
        {
            PI.SetInventory(inventory);
            PI.SetGear(gear);
            PI.SetWeapons(weapons);
        }
    }

    public void Save(PlayerInventory PI)
    {
        inventory = new List<InventoryObjectSO>(PI.GetInventory());
        gear = new List<InventoryObjectSO>(PI.GetGear());
        weapons = new List<WeaponSO>(PI.GetWeapons());
    }

    public void LoadSceneRegular(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadScene(int index, Player player)
    {
        if(player != null)
            Save(player.GetInventory());
        SceneManager.LoadScene(index);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
