using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void LoadSceneRegular(int index)
    {
        GameManager.Instance.LoadSceneRegular(index);
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
