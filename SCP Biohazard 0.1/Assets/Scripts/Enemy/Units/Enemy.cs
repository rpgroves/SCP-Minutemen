using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject weaponParentObject;
    [SerializeField] WeaponSO weapon;
    EnemyEncounterController encounter;
    EnemyEncounterNode node;
    WeaponParent weaponParent;

    GameObject target;

    float shotTimer = 0.0f;

    void Start()
    {
        weaponParent = weaponParentObject.GetComponent<WeaponParent>();
        weaponParentObject.SetActive(true);
        weaponParent.ChangeWeapon(weapon);
    }

    void Update()
    {
        HandleWeaponRotation();
        shotTimer += Time.deltaTime;
        if(shotTimer > 3.0f)
        {
            shotTimer = 0.0f;
            Debug.Log("shooting!");
            weaponParent.HandleFire();
        }
    }

    void HandleWeaponRotation()
    {
        if(target != null)
        {
            weaponParent.PointerPosition = target.transform.position;
            if(((weaponParent.PointerPosition - (Vector2)transform.position).normalized).x < 0)
            {
                weaponParent.Rotate(-(weaponParent.PointerPosition - (Vector2)transform.position).normalized, false);
            }
            else
            {
                weaponParent.Rotate((weaponParent.PointerPosition - (Vector2)transform.position).normalized, true);
            }
        }
    }

    public void setNode(EnemyEncounterNode n)
    {
        node = n;
    }

    public void setEncounter(EnemyEncounterController e)
    {
        encounter = e;
    }

    public void setTarget(GameObject t)
    {
        target = t;
    }
}
