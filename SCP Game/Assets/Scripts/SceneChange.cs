using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] int sceneIndex;

    void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.LoadScene(sceneIndex);
    }
}
