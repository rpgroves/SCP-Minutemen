using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveStationInteractable : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip1;
    [SerializeField] TextMeshProUGUI loadStatusText;
    [SerializeField] float loadTime;
    Slider slider;
    float timer = 0.0f;
    bool isLoading = false;
    Interactable myInteractable = null;
    void Start()
    {
        loadStatusText.text = "...";
    }

    void Update()
    {
        if(isLoading && timer < loadTime)
        {
            timer += Time.deltaTime;
            slider.value = timer/loadTime;
        }
        else if (isLoading)
        {
            isLoading = false;
            GameManager.Instance.Save(Player.Instance.GetInventory(), true);
            loadStatusText.text = "Saved!";
            source.clip = clip1;
            source.Play();
        }
    }

    public void Save()
    {
        slider = GetComponentInChildren<Slider>();
        isLoading = true;
        loadStatusText.text = "Saving...";
    }

    public void MinigameTriggered(bool isActivated)
    {
        
    }
    public void MinigameStopped()
    {
        Destroy(gameObject);
    }
    public void SendSignal(bool wasWon)
    {
        
    }
    public void setInteractable(Interactable i)
    {
        myInteractable = i;
    }
}
