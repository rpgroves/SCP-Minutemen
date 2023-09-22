using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    [SerializeField] GameObject me;
    [SerializeField] float projectileSpeed = 5.0f;
    int damage;

    public void StartMoving(int d, bool isFacingRight)
    {
        damage = d;
        Vector3 v = this.transform.right;
        v *= projectileSpeed;
        if(isFacingRight)
            this.GetComponentInParent<Rigidbody2D>().AddForce(v);
        else
            this.GetComponentInParent<Rigidbody2D>().AddForce(-v);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponentInParent<PlayerHealth>())
                other.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage();
        }
        else if(other.gameObject.tag == "Entity")
        {
            if(other.gameObject.GetComponentInParent<EnemyHealth>())
                other.gameObject.GetComponentInParent<EnemyHealth>().TakeDamage(damage);
        }
        Destroy(me);
    }
}
