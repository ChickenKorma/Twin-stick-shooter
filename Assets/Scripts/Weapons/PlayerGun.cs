using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public static PlayerGun Instance;

    public int gunLevel = 0;

    [SerializeField] private GunState[] states;

    private Destructible playerDestructible;

    private Gun player;

    private void Awake()
    {
        // Set up singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        playerDestructible = transform.parent.GetComponent<Destructible>();

        player = transform.GetComponent<Gun>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(playerDestructible.health > 1 && gunLevel < states.Length - 1)
            {
                playerDestructible.ApplyDamage(1);

                gunLevel++;

                player.UpdateGun(states[gunLevel]);
            }
        }
    }
}
