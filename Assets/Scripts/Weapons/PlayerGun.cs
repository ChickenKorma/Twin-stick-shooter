using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public static PlayerGun Instance;

    public int currentGunLevel = 0;

    [SerializeField] private GunState[] gunLevels;

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

        player = GetComponent<Gun>();
    }

    private void Update()
    {
        // Checks for spacebar update, checks if player has enough health and applies damage while adding to current gun level, finally updates gun state
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerDestructible.health > 1 && currentGunLevel < gunLevels.Length - 1)
            {
                playerDestructible.ApplyDamage(1);

                currentGunLevel++;

                player.UpdateGun(gunLevels[currentGunLevel]);
            }
        }
    }
}
