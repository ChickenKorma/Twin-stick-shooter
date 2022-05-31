using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text healthText, gunText;

    private Destructible playerDestructible;

    private PlayerGun gun;

    void Start()
    {
        playerDestructible = Player.Instance.transform.GetComponent<Destructible>();

        gun = PlayerGun.Instance;
    }

    void Update()
    {
        healthText.text = "Health: " + playerDestructible.health;

        gunText.text = "Gun Power: " + gun.gunLevel;
    }
}
