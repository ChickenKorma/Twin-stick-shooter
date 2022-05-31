using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [System.NonSerialized] public float health;

    [SerializeField] private float maxHealth;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        health = maxHealth;
    }

    // Reduces object health by the input damage and checks to see if it is dead, then applies correct animation trigger
    public void ApplyDamage(float damage)
    {
        health -= damage;

        if (health <= 0.0f)
        {
            Movement movement = GetComponent<Movement>();

            if(movement != null)
            {
                movement.active = false;
            }

            animator.SetTrigger("Death");
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }

    // Increases object health by input amount and then clamps beneath max health
    public void AddHealth(float heal)
    {
        health += heal;

        health = Mathf.Clamp(health, 0.0f, maxHealth);
    }
}
