using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] Image imageLeft;
    [SerializeField] Image imageRight;
    [SerializeField] GameObject me;
    
    public TextMeshProUGUI GetTextComponent()
    {
        return textComponent;
    }

    public void SetImageLeft(Sprite i)
    {
        imageLeft.sprite = i;
    }

    public void SetImageRight(Sprite i)
    {
        imageRight.sprite = i;
    }

    public void DialogueEnd()
    {
        Destroy(me);
    }
}
