using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloDialogue : MonoBehaviour
{
    [SerializeField] GameObject me;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(this.GetComponentInParent<Dialogue>() != null)
            {
                this.GetComponentInParent<Dialogue>().StartDialogue();
            }
        }
        Destroy(this);
    }
}
