using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject fireLocation;
    WeaponSO weapon;

    int ammo = 0;

    public void HandleReload(int a)
    {
        ammo = weapon.getCapacity();
    }
    
    public void HandleFire(bool isFacingRight)
    {
        if(weapon != null && ammo != 0)
        {
            float timer = 0.0f;
            for(int i = 0; i < weapon.getRateOfFire(); i++)
            {
                WeaponProjectile wp = Instantiate(weapon.getBulletPrefab(), fireLocation.transform.position, fireLocation.transform.rotation).GetComponent<WeaponProjectile>();
                wp.StartMoving(weapon.getDamage(), isFacingRight);
                DecrementCurrentAmmo(1);
            }
        }
    }

    public void ChangeWeapon(WeaponSO w)
    {
        weapon = w;
        this.GetComponent<SpriteRenderer>().sprite = weapon.getSpriteBlack();
    }

    void DecrementCurrentAmmo(int shotsFired)
    {
        ammo = ammo - shotsFired;
        if(ammo <= 0)
            ammo = 0;
    }
}
