using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] int ammo = 5;
    [SerializeField] int maxAmmo = 5;

    [SerializeField] Image[] bullets;
    [SerializeField] Sprite fullBullet;
    [SerializeField] Sprite emptyBullet;
    WeaponSO weapon;

    public void CreateBar(WeaponSO w, PlayerInventory p)
    {
        weapon = w;
        ammo = weapon.getCurrentAmmo();
        maxAmmo = weapon.getCapacity();
        fullBullet = weapon.getFullBullet();
        emptyBullet = weapon.getEmptyBullet();
        PrintAmmo();
    }

    public void Reload(int ammoRemainingTotal)
    {
        if(ammoRemainingTotal < maxAmmo)
            ammo = ammoRemainingTotal;
        else
            ammo = maxAmmo;
        PrintAmmo();
    }

    public void ShootRounds(int roundsPerShot)
    {
        if(ammo - roundsPerShot >= 0)
            ammo -= roundsPerShot;
        else
            ammo = 0;
        PrintAmmo();
    }

    public int getMaxAmmo()
    {
        return maxAmmo;
    }

    public void setMaxAmmo(int ma)
    {
        maxAmmo = ma;
        PrintAmmo();
    }

    void PrintAmmo()
    {
        if(maxAmmo == 0)
        {
            for(int i = 0; i < bullets.Length; i++)
                bullets[i].enabled = false;
        }
        else
        {
            for(int i = 0; i < bullets.Length; i++)
            {
                if(i >= maxAmmo)
                    bullets[i].enabled = false;
                else
                    bullets[i].enabled = true;
                if(i < ammo)
                    bullets[i].sprite = fullBullet;
                else
                    bullets[i].sprite = emptyBullet;
            }
        }
    }
}
