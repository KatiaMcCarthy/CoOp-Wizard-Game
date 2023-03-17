using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction shootAction;
    private PlayerStats stats;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectile;

    private float attackTime;

    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        stats = GetComponentInParent<PlayerStats>();
        shootAction = playerInput.actions["Shoot"];
    }

    // Update is called once per frame
    void Update()
    {
        if (!stats.IsDead)
        {
            if (shootAction.ReadValue<float>() == 1 && Time.time >= attackTime)
            {
                Debug.Log("shoot");

                Shoot();

                attackTime = Time.time + stats.AttackSpeed;
            }
        }
    }


    //modify for animations

    private void Shoot()
    {
       GameObject shot = Instantiate(projectile, firePoint.position, firePoint.rotation);
        shot.GetComponent<Projectile>().SetPlayer(stats.PlayerID);
        shot.GetComponent<Projectile>().damage = stats.BaseDamage;
    }
}
