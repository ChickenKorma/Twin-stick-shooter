using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunState defaultState;

    private GameObject projectile;

    private Transform barrel;

    private float lastShot, fireRate;

    private void Start()
    {
        barrel = transform.GetChild(1);

        lastShot = Time.timeSinceLevelLoad - fireRate;

        projectile = defaultState.projectile;
        fireRate = defaultState.fireRate;
    }

    // Checks if gun can fire again, instantiates the projectile game object and sets it to the player or enemy projectiles layer
    public void Shoot(Quaternion direction, bool fromPlayer)
    {
        if (Time.timeSinceLevelLoad > lastShot + fireRate)
        {
            lastShot = Time.timeSinceLevelLoad;

            GameObject projectileInstance = Instantiate(projectile, barrel.position, direction);

            if (fromPlayer)
            {
                projectileInstance.layer = 7;
            }
            else
            {
                projectileInstance.layer = 6;
            }
        }
    }

    // Updates the gun information based on input GunState
    public void UpdateGun(GunState newState)
    {
        projectile = newState.projectile;

        fireRate = newState.fireRate;
    }
}

// Custom class to hold all gun information
[System.Serializable]
public class GunState
{
    public GameObject projectile;

    public float fireRate;

    public GunState(GameObject newProjectile, float newFireRate)
    {
        projectile = newProjectile;

        fireRate = newFireRate;
    }
}
