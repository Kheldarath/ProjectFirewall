using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 2;
    [SerializeField] ExplodeEffects effects;

    private void Start()
    {
        effects = GetComponent<ExplodeEffects>();
        
    }

    public void HurtUnit(int damageTaken)
    {
        
        if (!IsDead())
        {
            effects.PlayHitEffect(false);
            health -= damageTaken;
            Debug.Log($"Oww {gameObject.name} took {damageTaken} damage!");

            if (IsDead())
            {
                health = 0;
                effects.PlayHitEffect(true);
                KillUnit();
            }

        }
        else
        {
            effects.PlayHitEffect(false);
            KillUnit();
        }
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    public void KillUnit()
    {
        GameObject.Destroy(gameObject);
        Debug.Log("Oww I Am DEAD!");
    }

}
