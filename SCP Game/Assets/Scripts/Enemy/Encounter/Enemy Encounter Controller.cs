using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEncounterController : MonoBehaviour
{
    AudioManager audioManager;
    public bool isBossBattle = false;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] float[] timeForSpawns;
    [SerializeField] GameObject[] nodes;
    [SerializeField] GameObject[] encounterBarPrefab;
    [SerializeField] List<GameObject> controlledEvent;
    [SerializeField] List<GameObject> controlledEventStopOnTrigger;
    GameObject player = null;
    float timeElapsed = 0;
    bool isTriggered = false;
    int index = 0;
    public int enemyCount;

    EncounterBar encounterBar;

    void Start()
    {
        enemyCount = enemies.Count;
        audioManager = AudioManager.Instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTriggered = true;
            if(!isBossBattle)
                audioManager.FightAudio();
            else
                audioManager.BossAudio();
            foreach(GameObject e in controlledEventStopOnTrigger)
            {
                e.GetComponent<Event>().EventStopped();
            }
            player = other.gameObject;
            for(int i = 0; i < enemies.Count; i++)
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

        if(enemyCount == 0)
        {
            Debug.Log("alldead!");
            foreach(GameObject e in controlledEvent)
            {
                e.GetComponent<Event>().EventTriggered();
            }
            audioManager.NeutralAudio();
            Destroy(this.gameObject);
        }

        if(index >= enemies.Count)
            return;
        timeElapsed += Time.deltaTime;
        if(index < timeForSpawns.Length && timeElapsed >= timeForSpawns[index])
        {
            timeElapsed = 0;
            enemies[index].SetActive(true);
            if(enemies[index].TryGetComponent<Enemy>(out Enemy e))
                enemies[index].GetComponent<Enemy>().setEncounter(this);
            else if(enemies[index].TryGetComponent<SCP106>(out SCP106 e2))
                e2.setEncounter(this);
            index++;
        }
    }

    GameObject[] getNodes()
    {
        return nodes;
    }

    public void Remove(GameObject e)
    {
        // for(int i = 0; i < enemies.Count; i++)
        // {
        //     if(enemies[i] == e)
        //     {
        //         enemies.RemoveAt(i);
        //         Destroy(e);
        //         return;
        //     }
        // }
        Destroy(e);
        enemyCount--;
    }
}
