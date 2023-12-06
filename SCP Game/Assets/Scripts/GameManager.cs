using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public GameObject playerPrefab;
    AudioManager audioManager;
    List<InventoryObjectSO> inventory;
    List<InventoryObjectSO> gear;
    List<WeaponSO> weapons;
    Vector3 playerPosition;
    bool saveStationSave = false;
    bool isPlayerInPosition = false;
    bool reloaded = false;
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

    void Start()
    {
        audioManager = AudioManager.Instance;
    }

    void Update()
    {
        if(reloaded)
            CheckPosition();
    }

    void CheckPosition()
    {
        if(!isPlayerInPosition && saveStationSave)
        {
            isPlayerInPosition = true;
            //Destroy(Player.Instance);
            //Player.Instance = Instantiate(playerPrefab, playerPosition, Quaternion.identity).GetComponent<Player>();
            StartCoroutine(MovePlayer());
        }
    }

    IEnumerator MovePlayer()
    {
        yield return new WaitForSeconds(0.1f);
        Player.Instance.gameObject.transform.position = (playerPosition);
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

    public void Save(PlayerInventory PI, bool saveStation)
    {
        inventory = new List<InventoryObjectSO>(PI.GetInventory());
        gear = new List<InventoryObjectSO>(PI.GetGear());
        weapons = new List<WeaponSO>(PI.GetWeapons());
        playerPosition = PI.gameObject.transform.position;
        saveStationSave = saveStation;
    }

    public void LoadSceneRegular(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadScene(int index, Player player)
    {
        if(player != null)
            Save(player.GetInventory(), false);
        SceneManager.LoadScene(index);
    }

    public void ReloadScene()
    {
        reloaded = true;
        isPlayerInPosition = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
