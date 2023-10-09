using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeypadButton : MonoBehaviour
{
    [SerializeField] bool canBeUnswitchedManually = false;
    [SerializeField] string input;
    [SerializeField] Sprite spriteUp;
    [SerializeField] Sprite spritePressed;

    bool used = false;

    public void isPressed()
    {
        if(!used)
        {
            this.GetComponentInParent<Image>().sprite = spritePressed;
            used = true;
        }
        else if(canBeUnswitchedManually)
        {
            this.GetComponentInParent<Image>().sprite = spriteUp;
            used = false;
        }
    }

    public void isUnPressed()
    {
        this.GetComponentInParent<Image>().sprite = spriteUp;
        used = false;
    }

    public bool isUsed()
    {
        return used;
    }

    public string getInput()
    {
        return input;
    }
}
