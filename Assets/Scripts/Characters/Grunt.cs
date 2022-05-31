using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonoBehaviour
{
    private Movement movement;

    private Melee melee;

    private Transform player;

    void Start()
    {
        movement = GetComponent<Movement>();

        melee = GetComponent<Melee>();

        player = Player.Instance.transform;
    }

    void Update()
    {
        // Finds direction towards player, calls move in that direction and hit if close enough
        Vector3 directionToPlayer = player.position - transform.position;      

        if(directionToPlayer.magnitude <= melee.hitRadius)
        {
            melee.Hit();
        }
        else
        {
            movement.Move(directionToPlayer);
        }
    }
}
