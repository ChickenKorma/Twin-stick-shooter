using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float healthAdd;

    private Destructible player;

    private void Start()
    {
        player = transform.parent.GetComponent<Destructible>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Health"))
        {
            player.AddHealth(healthAdd);

            Destroy(collision.gameObject);
        }
    }
}
