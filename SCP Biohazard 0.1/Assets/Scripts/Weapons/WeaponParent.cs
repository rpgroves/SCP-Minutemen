using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    [SerializeField] WeaponController weapon;
    bool isFacingRight;
    public Vector2 PointerPosition;

    public void Rotate(Vector3 v, bool IFR)
    {
        isFacingRight = IFR;
        if(isFacingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.right = v;
        
    }

    public void ChangeWeapon(WeaponSO w)
    {
        weapon.ChangeWeapon(w);
    }

    public void HandleFire()
    {
        weapon.HandleFire(isFacingRight);
    }
}
