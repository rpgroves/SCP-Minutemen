using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP106 : MonoBehaviour
{
    [SerializeField] GameObject regularFire;
    [SerializeField] GameObject regularFireEmitter;
    [SerializeField] GameObject roundShot;
    [SerializeField] GameObject[] roundShotEmitters;
    [SerializeField] GameObject defensiveCircle;
    [SerializeField] int shotCountLimit = 0;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float rotationMultiplier = 2.0f;
    [SerializeField] bool isUsingBarrier = false;
    [SerializeField] bool isTeleporter = false;
    EnemyHealth myHealth;
    int shotCountCurrent = 0;
    EnemyEncounterController encounter;
    GameObject target;
    NavMeshAgent agent;
    float shotTimer = 0.0f;
    float burstTimer = 0.0f;
    float burstTimer2 = 0.0f;
    bool secondBurst = false;
    bool isFacingRight = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        myHealth = GetComponent<EnemyHealth>();
        defensiveCircle.SetActive(isUsingBarrier);
    }

    void Update()
    {
        HandleAim();
        shotTimer += Time.deltaTime;
        burstTimer += Time.deltaTime;
        if(secondBurst)
            burstTimer2 += Time.deltaTime;
        if(shotTimer > 3.0f)
        {
            shotTimer = 0.0f;
            Shoot();
        }
        if(burstTimer > 6.0f)
        {
            roundShot.transform.Rotate(0.0f, 0.0f, 22.5f);
            burstTimer = 0.0f;
            ShootBurst();
            secondBurst = true;
        }
        if(burstTimer2 > 1.0f)
        {
            roundShot.transform.Rotate(0.0f, 0.0f, -22.5f);
            burstTimer2 = 0.0f;
            ShootBurst();
            secondBurst = false;
        }

        if(target == null)
        {
            agent.SetDestination(this.gameObject.transform.position);
        }
        if(target != null)
        {
            agent.SetDestination(target.transform.position);
        }
        defensiveCircle.transform.Rotate(0.0f, 0.0f, Time.deltaTime * rotationMultiplier);

        if(isTeleporter && myHealth.GetHealth() < (myHealth.GetMaxHealth() / 2))
        {
            GameManager.Instance.LoadScene(3, Player.Instance);
        }
    }

    void HandleAim()
    {
        if(target != null)
        {
            if((((Vector2)target.transform.position - (Vector2)transform.position).normalized).x < 0)
            {
                isFacingRight = false;
                transform.localScale = new Vector3(-1, 1, 1);
                regularFire.transform.right = (-((Vector2)target.transform.position - (Vector2)transform.position).normalized);
            }
            else
            {
                isFacingRight = true;
                transform.localScale = new Vector3(1, 1, 1);
                regularFire.transform.right = (((Vector2)target.transform.position - (Vector2)transform.position).normalized);
            }
        }
    }

    void Shoot()
    {
        //Debug.Log("shooting!");
        WeaponProjectile wp = Instantiate(bulletPrefab, regularFireEmitter.transform.position, regularFireEmitter.transform.rotation).GetComponent<WeaponProjectile>();
        wp.StartMoving(1, isFacingRight);
    }

    void ShootBurst()
    {
        //Debug.Log("shooting burst!");
        for(int i = 0; i < roundShotEmitters.Length; i++)
        {
            WeaponProjectile wp = Instantiate(bulletPrefab, roundShotEmitters[i].transform.position, roundShotEmitters[i].transform.rotation).GetComponent<WeaponProjectile>();
            wp.StartMoving(1, isFacingRight);
        }
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
