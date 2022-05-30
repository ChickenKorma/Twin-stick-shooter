using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private Animator animator;

    private float health;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        health = maxHealth;
    }

    // Reduces object health by the projectile damage and checks to see if it is dead
    public void ApplyDamage(float damage)
    {
        health -= damage;

        if (health <= 0.0f)
        {
            Movement movement = transform.GetComponent<Movement>();

            if(movement != null)
            {
                movement.active = false;
            }

            animator.SetTrigger("Death");
        }
    }
}
