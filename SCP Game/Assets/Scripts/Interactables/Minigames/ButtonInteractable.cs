using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ButtonInteractable : MonoBehaviour, Minigame
{
    public AudioSource source;
    public AudioClip clip1;
    public AudioClip clip2;
    [SerializeField] GameObject button;
    [SerializeField] TextMeshProUGUI guiText;
    [SerializeField] Sprite red;
    [SerializeField] Sprite green;
    Interactable myInteractable = null;
    
    void Start()
    {
        guiText.text = "Closed";
    }

    public void PressButton(string buttonInput) 
    {
        if(this.GetComponentInParent<Image>().sprite == red)
        {
            this.GetComponentInParent<Image>().sprite = green;
            guiText.text = "Open";
            source.clip = clip1;
            SendSignal(true);
        }
        else
        {
            this.GetComponentInParent<Image>().sprite = red;
            guiText.text = "Closed";
            source.clip = clip2;
            SendSignal(false);
        }
        source.Play();
    }

    public void MinigameTriggered(bool isActivated)
    {
        if(isActivated)
        {
            button.GetComponent<Button>().isPressed();
            this.GetComponentInParent<Image>().sprite = green;
            guiText.text = "Open";
        }
    }
    public void MinigameStopped()
    {
        Destroy(gameObject);
    }

    public void SendSignal(bool wasWon)
    {
        myInteractable.MinigameSwitched(wasWon);
    }
    public void setInteractable(Interactable i)
    {
        myInteractable = i;
    }
}
