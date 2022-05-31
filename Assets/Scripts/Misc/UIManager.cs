using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text healthText, gunLevelText;

    private Destructible playerDestructible;

    private PlayerGun playerGun;

    void Start()
    {
        playerDestructible = Player.Instance.transform.GetComponent<Destructible>();

        playerGun = PlayerGun.Instance;
    }

    void Update()
    {
        healthText.text = "Health: " + playerDestructible.health;

        gunLevelText.text = "Gun Power: " + playerGun.currentGunLevel;
    }
}
