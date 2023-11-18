using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] GameObject me;
    
    public TextMeshProUGUI GetTextComponent()
    {
        return textComponent;
    }

    public void DialogueEnd()
    {
        Destroy(me);
    }
}
