using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//all abilities and moves reffernce this script for moves
public class PlayerStats : MonoBehaviour
{
    public float Health { get; private set; }
    public float BaseDamage { get; private set; }  //differnt moves will multiply this ammont
    public float Speed { get; private set; }
    public float AttackSpeed { get; private set; }
    public int PlayerID { get; private set; }
    public int TeamID { get; private set; }

    public bool IsDead { get; private set; }

    public void UpdateDeathStatus(bool status)
    {
        IsDead = status;
    }

    public void UpdateHealth(float ammount, bool shouldHeal)
    {
        Health = ammount;

        if(shouldHeal)
        {
            this.GetComponentInChildren<Health>().SetMaxHealth(Health);
        }
    }

    public void UpdateSpeed(float ammount)
    {
        Speed = ammount;

        //this.GetComponentInChildren<PlayerMovement>().UpdateMovementValues();
    }

    public void UpdateAttackSpeed(float ammount)
    {
        AttackSpeed = ammount;

        //this.GetComponentInChildren<PlayerMovement>().UpdateMovementValues();
    }

    public void UpdateBaseDamage(float ammount)
    {
        BaseDamage = ammount;
    }

    public void UpdatePlayerID(int ammount)
    {
        PlayerID = ammount;
    }
    public void UpdateTeamID(int ammount)
    {
        TeamID = ammount;
    }




}
