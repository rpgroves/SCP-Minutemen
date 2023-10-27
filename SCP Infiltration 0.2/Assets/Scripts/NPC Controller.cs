using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] GameObject me;

    [SerializeField] GameObject bubble;
    [SerializeField] Sprite bubbleRegular;
    [SerializeField] Sprite bubbleGlow;
    
    void Start()
    {
        
    }

    
    public void PlayerInteraction()
    {
        if(this.GetComponentInParent<Dialogue>() != null)
        {
            this.GetComponentInParent<Dialogue>().StartDialogue();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(bubble.GetComponent<SpriteRenderer>().sprite != bubbleRegular)
                bubble.GetComponent<SpriteRenderer>().sprite = bubbleRegular;
            else
                bubble.GetComponent<SpriteRenderer>().sprite = bubbleGlow;
            other.GetComponentInParent<PlayerInventory>().setNPC(me);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(bubble.GetComponent<SpriteRenderer>().sprite != bubbleGlow)
                bubble.GetComponent<SpriteRenderer>().sprite = bubbleGlow;
            else
                bubble.GetComponent<SpriteRenderer>().sprite = bubbleRegular;
            other.GetComponentInParent<PlayerInventory>().unsetNPC(me);
        }
    }
}
