using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonStats : MonoBehaviour
{
    public int OwnerID { get; private set; }
    public float SummonAttackRange { get; private set; }
    public float SummonAttackSpeed { get; private set; }
    public float SummonHealth { get; private set; }
    public float SummonDamage { get; private set; }
    public float SummonSpeed { get; private set; }

    public void UpdateHealth(float ammount, bool shouldHeal)
    {
        SummonHealth = ammount;

        if (shouldHeal)
        {
            this.GetComponentInChildren<Health>().SetMaxHealth(SummonHealth);
        }
    }

    public void UpdateSpeed(float ammount)
    {
        SummonSpeed = ammount;

        //this.GetComponentInChildren<PlayerMovement>().UpdateMovementValues();
    }

    public void UpdateAttackSpeed(float ammount)
    {
        SummonAttackSpeed = ammount;
    }

    public void UpdateAttackRange(float ammount)
    {
        SummonAttackRange = ammount;
    }

    public void UpdateBaseDamage(float ammount)
    {
        SummonDamage = ammount;
    }

    public void UpdateOwnerID(int playerID)
    {
        OwnerID = playerID;
    }
}
