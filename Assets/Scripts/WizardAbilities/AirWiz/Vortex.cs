using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{

    //every x time, pulse, pulling anyone in range towards the center
    [SerializeField] private float tickRate;
    [SerializeField] private LayerMask targetsToHit;
    [SerializeField] private float vortexRadius;
    [SerializeField] private float knockbackStrength;
    [SerializeField] private float knockbackDuration;

    private float vortexTime;


    private void Update()
    {
        if (Time.time >= vortexTime)
        {
            Pull();
            vortexTime = Time.time + tickRate;
        }
    }

    private void Pull()
    {
        Collider2D[] enemiesToHit = Physics2D.OverlapCircleAll(transform.position, vortexRadius, targetsToHit);

        foreach (var enemy in enemiesToHit)
        {
            //pullit towards the center
            Vector2 dir = enemy.transform.position - transform.position;
            dir = -dir.normalized;

            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            enemy.GetComponent<Rigidbody2D>().inertia = 0;

            //stuns the player while they are knockedback
            enemy.GetComponent<StatusManager>().StartStaus(dotDuration: knockbackDuration, tickCount: 1, statusAmmount: 0, StatusManager.StatusType.Stun);

            enemy.GetComponent<Rigidbody2D>().AddForce(dir * knockbackStrength, ForceMode2D.Impulse);

            Debug.Log("should apply knockback");
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, vortexRadius);
    }
}