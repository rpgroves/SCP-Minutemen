using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardSwipeReader : MonoBehaviour
{
    [SerializeField] GameObject keycardSwipe;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Keycard")
        {
            keycardSwipe.GetComponent<KeycardSwipe>().KeySwipped();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
