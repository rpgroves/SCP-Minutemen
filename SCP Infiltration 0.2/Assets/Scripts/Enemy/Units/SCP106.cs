using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP106 : MonoBehaviour
{
    [SerializeField] GameObject regularFire;
    [SerializeField] GameObject roundShot1;
    [SerializeField] GameObject roundShot2;
    [SerializeField] int shotCountLimit = 0;
    int shotCountCurrent = 0;
    EnemyEncounterController encounter;
    GameObject target;
    NavMeshAgent agent;
    float shotTimer = 0.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        HandleAim();
        shotTimer += Time.deltaTime;
        if(shotTimer > 3.0f)
        {
            shotTimer = 0.0f;
            Shoot();
        }

        if(target == null)
        {
            agent.SetDestination(this.gameObject.transform.position);
        }
        if(target != null)
        {
            agent.SetDestination(target.transform.position);
        }
    }

    void HandleAim()
    {
        if(target != null)
        {
            if((((Vector2)target.transform.position - (Vector2)transform.position).normalized).x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                regularFire.transform.right = (-((Vector2)target.transform.position - (Vector2)transform.position).normalized);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                regularFire.transform.right = (((Vector2)target.transform.position - (Vector2)transform.position).normalized);
            }
        }
    }

    void Shoot()
    {
        Debug.Log("shooting!");
    }

    public void setTarget(GameObject t)
    {
        target = t;
    }

    public void setEncounter(EnemyEncounterController e)
    {
        encounter = e;
    }
}
