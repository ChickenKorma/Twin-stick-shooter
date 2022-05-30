using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonoBehaviour
{
    [SerializeField] private float damage;

    private Movement Movement;

    private Transform player;

    void Start()
    {
        Movement = GetComponent<Movement>();

        player = Player.Instance.transform;
    }

    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        Movement.Move(directionToPlayer);
    }
}
