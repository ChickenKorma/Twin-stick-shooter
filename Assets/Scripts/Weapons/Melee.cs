using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private float damage, hitRadius, hitRate;

    private float lastHit;

    void Start()
    {
        lastHit = Time.timeSinceLevelLoad - hitRate;
    }

    public void Hit()
    {
        if(Time.timeSinceLevelLoad > lastHit + hitRate)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, hitRadius);

            foreach(Collider2D collider in colliders)
            {
                Destructible destructible = collider.GetComponent<Destructible>();

                if (destructible != null)
                {
                    destructible.ApplyDamage(damage);
                }
            }
        }
    }
}
