using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float hitRadius;

    [SerializeField] private AnimationClip hitAnimation;

    [SerializeField] private float damage, animationBuffer;

    private Animator animator;

    private float lastHit, hitRate;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        hitRate = hitAnimation.length + animationBuffer;

        lastHit = Time.timeSinceLevelLoad - hitRate;
    }

    // Checks if melee hit can occur, gets nearby destructibles by circle cast and applies damage
    public void Hit()
    {
        if(Time.timeSinceLevelLoad > lastHit + hitRate)
        {
            lastHit = Time.timeSinceLevelLoad;

            Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, hitRadius);

            foreach(Collider2D collider in nearbyColliders)
            {
                Destructible destructible = collider.GetComponent<Destructible>();

                if (destructible != null && ((collider.gameObject.layer != gameObject.layer) || gameObject.layer == 12))
                {
                    destructible.ApplyDamage(damage);
                }
            }

            if(gameObject.layer != 12)
            {
                animator.SetTrigger("Melee Hit");
            }
        }
    }
}
