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

    [SerializeField] private float dotTickDuration;
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
        var bitMask = ~((1 << GetComponentInParent<PlayerStats>().PlayerID + 5)
           | (1 << 0)
           | (1 << 1)
           | (1 << 2)
           | (1 << 3)
           | (1 << 4)
           | (1 << 5)
           | (1 << 12)
           | (1 << 13)
           | (1 << 14)
           | (1 << 15)
           | (1 << 16)
           | (1 << 17)
           | (1 << 18))
           ;

        targetsToHit = bitMask;

        Collider2D[] enemiesToHit = Physics2D.OverlapCircleAll(mouseLocation.position, autolockRadius, targetsToHit);

        foreach (var enemy in enemiesToHit)
        {
            //for target
            if (enemy.GetComponentInParent<PlayerStats>() != null)
            {
                if (enemy.GetComponentInParent<PlayerStats>().PlayerID == this.GetComponentInParent<PlayerStats>().PlayerID)
                {
                    return;
                }
            }

            enemy.GetComponent<StatusManager>().StartStaus(dotTickDuration, dotTickCount, tickDamage, StatusManager.StatusType.Bleed);     
        }
    }
}
