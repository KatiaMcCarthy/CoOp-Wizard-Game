using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Drain : MonoBehaviour
{
    [SerializeField] private float drainStrength;
    [SerializeField] private float drainRadius;
    private LayerMask drainTargets;

    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilMoveAction;

    [SerializeField] private float cooldown;
    private float drainTime;

    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponentInParent<PlayerStats>();
        playerInput = GetComponentInParent<PlayerInput>();
        abilMoveAction = playerInput.actions["AbilMove"];
    }

    private void Update()
    {
        if (stats.IsDead) { return; }

        if (abilMoveAction.ReadValue<float>() == 1 && Time.time >= drainTime)
        {
            Debug.Log("drain");
            //trigger animation
            DrainEffect();

            drainTime = Time.time + cooldown;
        }
    }

    private void DrainEffect()
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

        drainTargets = bitMask;

        Collider2D[] enemiesToHit = Physics2D.OverlapCircleAll(transform.position, drainRadius, drainTargets);

        foreach (var enemy in enemiesToHit)
        {
            enemy.GetComponent<StatusManager>().StartStaus(1, 1, drainStrength, StatusManager.StatusType.Bleed);

            //heal us for the same ammount
            GetComponent<Health>().TakeDamage(-drainStrength);
        }
    }
}
