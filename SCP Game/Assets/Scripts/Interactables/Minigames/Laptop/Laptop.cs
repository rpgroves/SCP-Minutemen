using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Laptop : MonoBehaviour, Minigame
{
    [SerializeField] GameObject passwordScreen;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject functionScreen;
    [SerializeField] GameObject backButton;
    [SerializeField] string password;
    [SerializeField] float loadTime;
    [SerializeField] List<FileSO> files;
    [SerializeField] GameObject actionItemPrefab;
    float timer = 0.0f;
    bool isUnlocked = false;
    Interactable myInteractable = null;
    Slider slider;
    bool isLoading = false;
    bool isBooting = false;

    void Start()
    {
        passwordScreen.SetActive(true);
        loadingScreen.SetActive(false);
        functionScreen.SetActive(false);

        if(isUnlocked)
            Load();
    }
    void Update()
    {
        if(isLoading && timer < loadTime)
        {
            timer += Time.deltaTime;
            slider.value = timer/loadTime;
        }
        else
        {
            timer = 0;
            isLoading = false;
            if(isBooting)
            {
                isBooting = false;
                passwordScreen.SetActive(false);
                loadingScreen.SetActive(false);
                functionScreen.SetActive(true);
                backButton.SetActive(false);
            }
        }
    }
    public void CheckPassword(TMP_InputField i)
    {
        if(i.text == password)
        {
            SendSignal(true);
            Load();
        }
    }
    void Load()
    {
        passwordScreen.SetActive(false);
        loadingScreen.SetActive(true);
        functionScreen.SetActive(false);

        slider = loadingScreen.GetComponentInChildren<Slider>();
        isLoading = true;
        isBooting = true;
    }
    public void PopulateFiles()
    {
        float offset = 0.0f;
        foreach(FileSO f in files)
        {
            
        }
    }
    public void UpdateCode(string s)
    {
        password = s;
    }
    public void MinigameTriggered(bool isActivated)
    {
        isUnlocked = isActivated;
    }
    public void MinigameStopped()
    {
        Destroy(gameObject);
    }
    public void SendSignal(bool wasWon)
    {
        //myInteractable.MinigameSwitched(wasWon);
    }
    public void setInteractable(Interactable i)
    {
        myInteractable = i;
    }
}
