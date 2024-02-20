using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] bool isBullet = false;
    public int GetDamage()
    {
        return damage;
    }

    public void KillProjectile()
    {
        if (isBullet)
        {
            Destroy(gameObject);
        }
    }

}
