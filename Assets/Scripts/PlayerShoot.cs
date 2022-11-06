using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction shootAction;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectile;
    private float attackTime;


    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        shootAction = playerInput.actions["Shoot"];
    }

    // Update is called once per frame
    void Update()
    {
        if(shootAction.ReadValue<float>() == 1 && Time.time >= attackTime)
        {
            Debug.Log("shoot");

            Shoot();

            attackTime = Time.time + this.GetComponentInParent<PlayerStats>().AttackSpeed;
        }
    }


    //modify for animations

    private void Shoot()
    {
       GameObject shot = Instantiate(projectile, firePoint.position, firePoint.rotation);
        shot.GetComponent<Projectile>().SetPlayer(this.GetComponentInParent<PlayerStats>().PlayerID);
        shot.GetComponent<Projectile>().damage = this.GetComponentInParent<PlayerStats>().BaseDamage;
    }
}
