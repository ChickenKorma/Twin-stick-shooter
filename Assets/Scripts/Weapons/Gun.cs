using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    [SerializeField] private float shootRate;

    private Transform barrel;

    private float lastShot;

    private void Start()
    {
        barrel = transform.GetChild(1);

        lastShot = Time.timeSinceLevelLoad - shootRate;
    }

    public void Shoot(Quaternion direction, bool fromPlayer)
    {
        if(Time.timeSinceLevelLoad > lastShot + shootRate)
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
}
