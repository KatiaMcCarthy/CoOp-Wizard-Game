using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityBasicAttack : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction shootAction;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float autolockRadius;

    [SerializeField] private float dotDuration;
    [SerializeField] private int dotTickCount;
    [SerializeField] private float tickDamage;
    [SerializeField] private LayerMask targetsToHit;


    private Transform mouseLocation;
    private float attackTime;

    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        shootAction = playerInput.actions["Shoot"];
    }

    // Update is called once per frame
    void Update()
    {
        if (shootAction.ReadValue<float>() == 1 && Time.time >= attackTime)
        {
            Debug.Log("shoot");
            mouseLocation = GetComponentInParent<MouseIcon>().Icon;
            Shoot();

            attackTime = Time.time + this.GetComponentInParent<PlayerStats>().AttackSpeed;
        }
    }


    //modify for animations

    private void Shoot()
    {
        Collider2D[] enemiesToHit = Physics2D.OverlapCircleAll(mouseLocation.position, autolockRadius, targetsToHit);

        foreach (var enemy in enemiesToHit)
        {
            if(enemy.GetComponentInParent<PlayerStats>().PlayerID == this.GetComponentInParent<PlayerStats>().PlayerID)
            {
                return;
            }

            enemy.GetComponent<StatusManager>().StartStaus(dotDuration, dotTickCount, tickDamage, StatusManager.StatusType.Bleed);     
        }
    }
}
