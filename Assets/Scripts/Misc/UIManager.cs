using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text healthText;

    private Destructible playerDestructible;

    void Start()
    {
        playerDestructible = Player.Instance.transform.GetComponent<Destructible>();
    }

    void Update()
    {
        healthText.text = "Health: " + playerDestructible.health;
    }
}
