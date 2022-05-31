using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunState defaultState;

    private float lastShot, fireRate;

    private Transform barrel;

    private GameObject projectile;

    private void Start()
    {
        barrel = transform.GetChild(1);

        lastShot = Time.timeSinceLevelLoad - fireRate;

        projectile = defaultState.projectile;

        fireRate = defaultState.fireRate;
    }

    public void Shoot(Quaternion direction, bool fromPlayer)
    {
        if (Time.timeSinceLevelLoad > lastShot + fireRate)
        {
            lastShot = Time.timeSinceLevelLoad;

            GameObject instance = Instantiate(projectile, barrel.position, direction);

            if (fromPlayer)
            {
                instance.layer = 7;
            }
            else
            {
                instance.layer = 6;
            }
        }
    }

    public void UpdateGun(GunState state)
    {
        projectile = state.projectile;

        fireRate = state.fireRate;
    }
}

[System.Serializable]
public class GunState
{
    public GameObject projectile;

    public float fireRate;

    public GunState(GameObject projectileObj, float fireRateNo)
    {
        projectile = projectileObj;

        fireRate = fireRateNo;
    }
}
