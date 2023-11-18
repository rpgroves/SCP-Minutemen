using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ButtonInteractable : MonoBehaviour, Minigame
{
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
            SendSignal(true);
        }
        else
        {
            this.GetComponentInParent<Image>().sprite = red;
            guiText.text = "Closed";
            SendSignal(false);
        }
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
