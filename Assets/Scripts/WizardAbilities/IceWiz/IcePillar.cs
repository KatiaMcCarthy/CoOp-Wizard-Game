using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePillar : MonoBehaviour
{
    [SerializeField] private float slowPerTick;
    [SerializeField] private float duration;
    [SerializeField] private int tickCount;
    [SerializeField] private StatusManager.StatusType ccType;

    [Tooltip("Projectile Slow Factor")]
    [SerializeField] private float slowAmmount;

    private bool hasBuffed;

    private bool isPlayerOne;
    private bool isPlayerTwo;
    private bool isPlayerThree;
    private bool isPlayerFour;
    private bool isPlayerFive;
    private bool isPlayerSix;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectPlayerCollsion(collision);

        DetectProjectileCollsion(collision);
    }

    private void DetectProjectileCollsion(Collider2D collision)
    {
        //only slows the projectile if it is not ours

        if (collision.CompareTag("Projectile") && collision.GetComponent<Projectile>().IsPlayerOne && !isPlayerOne)
        {
            if (!hasBuffed)
                collision.GetComponent<Projectile>().SlowProjectile(slowAmmount);
        }

        if (collision.CompareTag("Projectile") && collision.GetComponent<Projectile>().IsPlayerTwo && !isPlayerTwo)
        {
            if (!hasBuffed)
                collision.GetComponent<Projectile>().SlowProjectile(slowAmmount);
        }
        
        if (collision.CompareTag("Projectile") && collision.GetComponent<Projectile>().IsPlayerThree && !isPlayerThree)
        {
            if (!hasBuffed)
                collision.GetComponent<Projectile>().SlowProjectile(slowAmmount);
        }
        
        if (collision.CompareTag("Projectile") && collision.GetComponent<Projectile>().IsPlayerFour && !isPlayerFour)
        {
            if (!hasBuffed)
                collision.GetComponent<Projectile>().SlowProjectile(slowAmmount);
        }
        
        if (collision.CompareTag("Projectile") && collision.GetComponent<Projectile>().IsPlayerFive && !isPlayerFive) 
        {
            if (!hasBuffed)
                collision.GetComponent<Projectile>().SlowProjectile(slowAmmount);
        }
        
        if (collision.CompareTag("Projectile") && collision.GetComponent<Projectile>().IsPlayerSix && !isPlayerSix)  
        {
            if (!hasBuffed)
                collision.GetComponent<Projectile>().SlowProjectile(slowAmmount);
        }


    }

    private void DetectPlayerCollsion(Collider2D collision)
    {
        if (collision.CompareTag("Player1") && !isPlayerOne)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, slowPerTick, ccType);
        }

        if (collision.CompareTag("Player2") && !isPlayerTwo)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, slowPerTick, ccType);
        }

        if (collision.CompareTag("Player3") && !isPlayerThree)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, slowPerTick, ccType);
        }

        if (collision.CompareTag("Player4") && !isPlayerFour)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, slowPerTick, ccType);
        }

        if (collision.CompareTag("Player5") && !isPlayerFive)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, slowPerTick, ccType);
        }

        if (collision.CompareTag("Player6") && !isPlayerSix)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, slowPerTick, ccType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            hasBuffed = false;
        }
    }

    public void SetPlayer(int number)
    {
        switch (number)
        {
            case 1:
                ResetPlayerAllegiance();
                isPlayerOne = true;
                break;
            case 2:
                ResetPlayerAllegiance();
                isPlayerTwo = true;
                break;
            case 3:
                ResetPlayerAllegiance();
                isPlayerThree = true;
                break;
            case 4:
                ResetPlayerAllegiance();
                isPlayerFour = true;
                break;
            case 5:
                ResetPlayerAllegiance();
                isPlayerFive = true;
                break;
            case 6:
                ResetPlayerAllegiance();
                isPlayerSix = true;
                break;
            default:
                break;
        }
    }

    private void ResetPlayerAllegiance()
    {
        isPlayerOne = false;
        isPlayerTwo = false;
        isPlayerThree = false;
        isPlayerFour = false;
        isPlayerFive = false;
        isPlayerSix = false;
    }
}
