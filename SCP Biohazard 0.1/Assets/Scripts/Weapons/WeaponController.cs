using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject fireLocation;
    WeaponSO weapon;
    
    public void HandleFire(bool isFacingRight)
    {
        if(weapon != null && weapon.getCurrentAmmo() != 0)
        {
            WeaponProjectile wp = Instantiate(weapon.getBulletPrefab(), fireLocation.transform.position, fireLocation.transform.rotation).GetComponent<WeaponProjectile>();
            wp.StartMoving(weapon.getDamage(), isFacingRight);
            weapon.DecrementCurrentAmmo(weapon.getRateOfFire());
        }
    }

    public void ChangeWeapon(WeaponSO w)
    {
        weapon = w;
        this.GetComponent<SpriteRenderer>().sprite = weapon.getSpriteBlack();
    }
}
