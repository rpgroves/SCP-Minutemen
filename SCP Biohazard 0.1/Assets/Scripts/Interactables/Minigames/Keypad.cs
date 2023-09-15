using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Keypad : MonoBehaviour, Minigame
{
    [SerializeField] string passcode;
    [SerializeField] GameObject[] buttons;
    [SerializeField] TextMeshProUGUI guiText;
    [SerializeField] Sprite red;
    [SerializeField] Sprite green;
    Interactable myInteractable = null;

    // Start is called before the first frame update
    void Start()
    {
        guiText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressButton(string buttonInput) 
    {
        if(buttonInput != "Enter" && buttonInput != "Backspace")
            guiText.text = guiText.text + buttonInput;
        if(buttonInput == "Enter")
        {
            if(guiText.text == passcode)
            {
                this.GetComponentInParent<Image>().sprite = green;
                SendSignal(true);
            }
            else
            {
                this.GetComponentInParent<Image>().sprite = red;
                SendSignal(false);
            }
            KeypadReset(false);
        }
        if(buttonInput == "Backspace")
            KeypadReset(true);
    }

    void KeypadReset(bool clearText)
    {
        if(clearText)
            guiText.text = "";
        foreach(GameObject b in buttons)
        {
            b.GetComponent<Button>().isUnPressed();
        }
    }

    public void MinigameTriggered(bool isActivated)
    {
        if(isActivated)
            this.GetComponentInParent<Image>().sprite = green;
    }
    public void MinigameStopped()
    {
        Destroy(gameObject);
    }

    public void SendSignal(bool wasWon)
    {
        Debug.Log("Sending signal...");
        myInteractable.MinigameSwitched(wasWon);
    }

    public void setInteractable(Interactable i)
    {
        myInteractable = i;
    }
}
