using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue", fileName = "DialogueSO")]
public class DialogueSO : ScriptableObject
{
    [TextArea()]
    [SerializeField] string[] lines;

    public string[] GetLines()
    {
        return lines;
    }
}
