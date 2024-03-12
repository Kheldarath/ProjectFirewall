using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    /*This file will be attached to enemy prefabs so that we can add enemy behaviour to it such as shooting, 
     *impact events and so on
     */
    Health health;    

    void Awake()
    {
        health = GetComponent<Health>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Shot")
        {
            DamageDealer dmgDealer = coll.gameObject.GetComponent<DamageDealer>();
            health.HurtUnit(dmgDealer.GetDamage());

            if (coll.gameObject.tag == "Shot")
            {
                dmgDealer.KillProjectile();
            }
        }
    }
}
