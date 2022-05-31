using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed, damage;

    void Update()
    {
        // Move projectile forward
        transform.position += transform.right * speed * Time.deltaTime;
    }

    // Checks if collided object is destructible and applies damage, then destroys itself
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destructible destructible = collision.GetComponent<Destructible>();

        if (destructible != null)
        {
            destructible.ApplyDamage(damage);
        }

        Destroy(gameObject);
    }
}
