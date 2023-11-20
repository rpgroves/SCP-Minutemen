using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEncounterController : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] float[] timeForSpawns;
    [SerializeField] GameObject[] nodes;
    [SerializeField] GameObject[] encounterBarPrefab;
    [SerializeField] List<GameObject> controlledEvent;
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
                if(enemies[index].TryGetComponent<Enemy>(out Enemy e))
                    enemies[i].GetComponent<Enemy>().setTarget(other.gameObject);
                else if(enemies[index].TryGetComponent<SCP106>(out SCP106 e2))
                    e2.setTarget(other.gameObject);
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
            if(enemies[index].TryGetComponent<Enemy>(out Enemy e))
                enemies[index].GetComponent<Enemy>().setEncounter(this);
            else if(enemies[index].TryGetComponent<SCP106>(out SCP106 e2))
                e2.setEncounter(this);
            index++;
        }
        if(controlledEvent.Count == 0)
        {
            foreach(GameObject e in controlledEvent)
            {
                e.GetComponent<Event>().EventTriggered();
            }
        }
    }

    GameObject[] getNodes()
    {
        return nodes;
    }
}
