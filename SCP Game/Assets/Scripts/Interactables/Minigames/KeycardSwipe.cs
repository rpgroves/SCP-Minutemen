using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeycardSwipe : MonoBehaviour, Minigame
{
    [SerializeField] TextMeshProUGUI guiText;
    [SerializeField] Sprite red;
    [SerializeField] Sprite green;
    [SerializeField] GameObject cover;
    [SerializeField] Image card;
    Interactable myInteractable = null;
    Sprite cardSprite;

    void Start()
    {
        card.sprite = cardSprite;
    }
    public void KeySwipped() 
    {
        if(cover.GetComponent<Image>().sprite == red)
        {
            cover.GetComponent<Image>().sprite = green;
            guiText.text = "Open";
            SendSignal(true);
        }
        else
        {
            cover.GetComponent<Image>().sprite = red;
            guiText.text = "Closed";
            SendSignal(false);
        }
    }

    public void MinigameTriggered(bool isActivated)
    {
        if(isActivated)
        {
            cover.GetComponent<Image>().sprite = green;
            guiText.text = "Open";
        }
        if(!isActivated)
        {
            cover.GetComponent<Image>().sprite = red;
            guiText.text = "Closed";
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
    public void setCardSprite(Sprite s)
    {
        cardSprite = s;
    }
}
