using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float heal;

    private Destructible playerDestructible;

    private void Start()
    {
        playerDestructible = transform.parent.GetComponent<Destructible>();
    }

    // Checks type of pickup and calls appropriate function, then destroys itself
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Health"))
        {
            playerDestructible.AddHealth(heal);

            Destroy(collision.gameObject);
        }
    }
}
