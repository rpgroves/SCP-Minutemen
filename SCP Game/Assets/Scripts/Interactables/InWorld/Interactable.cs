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
    [SerializeField] string fileText = "";
    [SerializeField] bool isBroken = false;
    Canvas canvas;
    bool isSecondState = false;
    bool isActivated = false;

    [SerializeField] Sprite spriteBlack;
    [SerializeField] Sprite spriteGlow;
    [SerializeField] Sprite spriteSecondBlack;
    [SerializeField] Sprite spriteSecondGlow;
    [SerializeField] string code = "";
    [SerializeField] string requiredItem = "";
    [SerializeField] Sprite cardSprite;

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

    public bool PlayerInteraction(List<InventoryObjectSO> inventory)
    {
        if(isBroken)
        {
            Player.Instance.SetText("This seems to be broken.");
            return false;
        }

        //if condition not met
        if(requiredItem != "")
        {
            bool foundItem = false;
            foreach(InventoryObjectSO i in inventory)
            {
                if(i.getItemName() == requiredItem)
                {
                    foundItem = true;
                    break;
                }
            }
            if(!foundItem)
            {
                Player.Instance.SetText("I need a " + requiredItem + " to use this.");
                return false;
            }
        }

        GameObject gameOB = Instantiate(InteractableMinigame, canvas.transform);
        Minigame game = gameOB.GetComponent<Minigame>();
        if(gameOB.GetComponent<KeycardSwipe>())
        {
            gameOB.GetComponent<KeycardSwipe>().setCardSprite(cardSprite);
        }
        game.MinigameTriggered(isActivated);
        game.setInteractable(this);
        if (gameOB.TryGetComponent<Keypad>(out Keypad keypad))
        {
            keypad.UpdateCode(code);
        }
        if (gameOB.TryGetComponent<Switch>(out Switch sw))
        {
            sw.UpdateCode(code);
        }
        if (gameOB.TryGetComponent<Laptop>(out Laptop laptop))
        {
            laptop.UpdateCode(code);
        }
        return true;
    }

    public bool PlayerInteraction()
    {
        GameObject gameOB = Instantiate(InteractableMinigame, canvas.transform);
        Minigame game = gameOB.GetComponent<Minigame>();
        game.MinigameTriggered(isActivated);
        game.setInteractable(this);
        if (gameOB.TryGetComponent<Keypad>(out Keypad keypad))
        {
            keypad.UpdateCode(code);
        }
        return true;
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
