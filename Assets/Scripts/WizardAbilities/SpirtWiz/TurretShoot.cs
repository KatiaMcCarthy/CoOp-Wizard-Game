using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private SummonStats stats;
    [SerializeField] private TurretAim aim;
    private float attackTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= attackTime && aim.target != null)
        {
            Shoot();

            attackTime = Time.time + stats.SummonAttackSpeed;
        }
    }


    //modify for animations

    private void Shoot()
    {
        GameObject shot = Instantiate(projectile, firePoint.position, firePoint.rotation);
        shot.GetComponent<Projectile>().SetPlayer(stats.OwnerID);
        shot.GetComponent<Projectile>().damage = stats.SummonDamage;
    }
}