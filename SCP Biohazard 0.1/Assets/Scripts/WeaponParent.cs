using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    [SerializeField] WeaponController weapon;
    
    void Update()
    {
        transform.right = (PointerPosition - (Vector2)transform.position).normalized;
    }

    public void ChangeWeapon(WeaponSO w)
    {
        weapon.ChangeWeapon(w);
    }

    public void HandleFire()
    {
        weapon.HandleFire();
    }

    public Vector2 PointerPosition { get; set; }
}
