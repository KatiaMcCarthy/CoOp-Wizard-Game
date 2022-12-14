using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is responcible for handleing any status effects on the player
[RequireComponent(typeof(Health))]
public class StatusManager : MonoBehaviour
{
    [SerializeField] private Health health;
    public bool iFrameEnabled { get; private set; }
    public bool OnFire { get; private set; }
    public bool OnBleed { get; private set; }
    public bool OnHeal { get; private set; }
    public bool OnStunned { get; private set; }
    public bool OnSlowed { get; private set; }

    public enum StatusType { Stun, Slow , Fire, Bleed, Heal};

    private float preCCSpeed;

    [SerializeField] private bool isSummon;

    public void UpdateIFrameStatus(bool value)
    {
        iFrameEnabled = value;
    }

    public void StartStaus(float tickDuration, int tickCount, float statusAmmount, StatusType statusType)
    {
        StartCoroutine(DoStatusEffect(tickDuration, tickCount, statusAmmount, statusType));
    } 

    //combine boht corountines, combine type

    IEnumerator DoStatusEffect(float tickDuration, int statusCount, float statusAmmount, StatusType statusType)
    {
        switch(statusType)
        {
            case StatusType.Fire:
                OnFire = true;
                break;
            case StatusType.Bleed:
                OnBleed = true;
                break;
            case StatusType.Heal:
                OnHeal = true;
                break;
            case StatusType.Slow:
                OnSlowed = true;
                break;
            case StatusType.Stun:
                OnStunned = true;
                break;
            default:
                break;
        }

        //fireEffect.emit = true;
        int currentCount = 0;
        while (currentCount < statusCount)
        {
            switch (statusType)
            {
                case StatusType.Fire:
                    GetComponent<Health>().TakeDamage(statusAmmount);
                    break;
                case StatusType.Bleed:
                    GetComponent<Health>().TakeDamage(statusAmmount);
                    break; 
                case StatusType.Heal:
                    GetComponent<Health>().TakeDamage(-statusAmmount);
                    break;
                case StatusType.Slow:
                    if(!isSummon)
                    GetComponentInParent<PlayerStats>().UpdateSpeed(preCCSpeed * statusAmmount);
                    break;
                case StatusType.Stun:
                    //GetComponentInParent<PlayerStats>().UpdateSpeed(0);
                    Debug.Log("stunned");
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds(tickDuration);
            currentCount++;
        }
        //fireEffect.emit = false;

        switch (statusType)
        {
            case StatusType.Fire:
                OnFire = false;
                break;
            case StatusType.Bleed:
                OnBleed = false;
                break;
            case StatusType.Heal:
                OnHeal = false;
                break;
            case StatusType.Slow:
                OnSlowed = false;
                if(!isSummon)
                GetComponentInParent<PlayerStats>().UpdateSpeed(preCCSpeed);
                break;
            case StatusType.Stun:
                OnStunned = false;
                Debug.Log("stun turned off");
                break;
            default:
                break;
        }
    }
}
