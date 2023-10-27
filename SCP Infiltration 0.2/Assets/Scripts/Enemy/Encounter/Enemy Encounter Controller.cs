using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEncounterController : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] float[] timeForSpawns;
    [SerializeField] GameObject[] nodes;
    [SerializeField] GameObject[] encounterBarPrefab;
    GameObject player = null;
    float timeElapsed = 0;
    bool isTriggered = false;
    int index = 0;

    EncounterBar encounterBar;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTriggered = true;
            //encounterBar = Instantiate(encounterBarPrefab, canvas.transform);
            //encounterBar.InitializeEncounterBar();
            player = other.gameObject;
            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Enemy>().setTarget(other.gameObject);
            }
        }
    }

    void Update()
    {
        if(!isTriggered)
            return;
        if(index >= enemies.Length)
            return;
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= timeForSpawns[index])
        {
            timeElapsed = 0;
            enemies[index].SetActive(true);
            enemies[index].GetComponent<Enemy>().setEncounter(this);
            index++;
        }
    }

    GameObject[] getNodes()
    {
        return nodes;
    }
}
