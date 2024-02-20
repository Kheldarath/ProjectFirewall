using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 2;  

    public void HurtUnit(int damageTaken)
    {
        if (!IsDead())
        {
            health -= damageTaken;
            Debug.Log($"Oww i took {damageTaken} damage!");

            if (IsDead())
            {
                health = 0;
                KillUnit();
            }
        }
        else
            KillUnit();
        
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
