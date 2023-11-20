using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Main", fileName = "MailSO")]
public class MailSO : ScriptableObject
{
    public string headLine;
    public string sender;
    public string contents;
}
