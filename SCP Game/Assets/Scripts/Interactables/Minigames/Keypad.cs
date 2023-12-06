using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Keypad : MonoBehaviour, Minigame
{
    public AudioSource source;
    public AudioClip clip1;
    public AudioClip clip2;
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

    public void UpdateCode(string code)
    {
        passcode = code;
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
                source.clip = clip1;
                source.Play();
            }
            else
            {
                this.GetComponentInParent<Image>().sprite = red;
                SendSignal(false);
                source.clip = clip2;
                source.Play();
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
