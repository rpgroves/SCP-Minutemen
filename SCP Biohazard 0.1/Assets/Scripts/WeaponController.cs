using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    WeaponSO weapon;
    
    public void HandleFire()
    {

    }

    public void ChangeWeapon(WeaponSO w)
    {
        weapon = w;
        this.GetComponent<SpriteRenderer>().sprite = weapon.getSpriteBlack();
    }
}
