using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "File", fileName = "FileSO")]
public class FileSO : ScriptableObject
{
    public string fileName;
    public string fileContents;
}
