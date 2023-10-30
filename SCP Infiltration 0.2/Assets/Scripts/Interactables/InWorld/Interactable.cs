using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] bool hasTwoStates;
    [SerializeField] GameObject me;
    [SerializeField] GameObject InteractableHandler;

    [SerializeField] GameObject InteractableMinigame;
    Canvas canvas;
    bool isSecondState = false;
    bool isActivated = false;

    [SerializeField] Sprite spriteBlack;
    [SerializeField] Sprite spriteGlow;
    [SerializeField] Sprite spriteSecondBlack;
    [SerializeField] Sprite spriteSecondGlow;
    [SerializeField] string code = "";

    void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(isSecondState)
                this.GetComponentInParent<SpriteRenderer>().sprite = spriteSecondGlow;
            else
                this.GetComponentInParent<SpriteRenderer>().sprite = spriteGlow;
            other.GetComponentInParent<PlayerInventory>().setInteractable(me);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(isSecondState && hasTwoStates)
                this.GetComponentInParent<SpriteRenderer>().sprite = spriteSecondBlack;
            else
                this.GetComponentInParent<SpriteRenderer>().sprite = spriteBlack;
            other.GetComponentInParent<PlayerInventory>().unsetInteractable(me);
        }
    }

    public void PlayerInteraction()
    {
        
        GameObject gameOB = Instantiate(InteractableMinigame, canvas.transform);
        Minigame game = gameOB.GetComponent<Minigame>();
        game.MinigameTriggered(isActivated);
        game.setInteractable(this);
        if (gameOB.TryGetComponent<Keypad>(out Keypad keypad))
        {
            keypad.UpdateCode(code);
        }
    }

    public void MinigameSwitched(bool wasWon)
    {
        if(hasTwoStates)
        {
            if(isSecondState && !wasWon)
            {
                this.GetComponentInParent<SpriteRenderer>().sprite = spriteGlow;
                isSecondState = false;
            }
            else if (!isSecondState && wasWon)
            {
                this.GetComponentInParent<SpriteRenderer>().sprite = spriteSecondGlow;
                isSecondState = true;
            }
        }
        InteractableHandler.GetComponent<InteractableHandler>().updateStatus(me);
        isActivated = !isActivated;
    }
}
