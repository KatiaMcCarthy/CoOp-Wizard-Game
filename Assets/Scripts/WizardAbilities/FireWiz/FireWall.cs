using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    [SerializeField] private float damagePerTick;
    [SerializeField] private float duration;
    [SerializeField] private int tickCount;
    [SerializeField] private StatusManager.StatusType damageType;

    [SerializeField] private float augmentAmmount;

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
        if (collision.CompareTag("Projectile") && isPlayerOne)
        {
            if(!hasBuffed)
            collision.GetComponent<Projectile>().AugmentProjectile(augmentAmmount);
        }

        if (collision.CompareTag("Projectile") && isPlayerTwo)
        {
            if (!hasBuffed)
                collision.GetComponent<Projectile>().AugmentProjectile(augmentAmmount);
        }
       
        if (collision.CompareTag("Projectile") && isPlayerThree)
        {
            if (!hasBuffed)
                collision.GetComponent<Projectile>().AugmentProjectile(augmentAmmount);
        }

        if (collision.CompareTag("Projectile") && isPlayerFour)
        {
            if (!hasBuffed)
                collision.GetComponent<Projectile>().AugmentProjectile(augmentAmmount);
        }

        if (collision.CompareTag("Projectile") && isPlayerFive)
        {
            if (!hasBuffed)
                collision.GetComponent<Projectile>().AugmentProjectile(augmentAmmount);
        }

        if (collision.CompareTag("Projectile") && isPlayerSix)
        {
            if (!hasBuffed)
                collision.GetComponent<Projectile>().AugmentProjectile(augmentAmmount);
        }
        
    }

    private void DetectPlayerCollsion(Collider2D collision)
    {
        if (collision.CompareTag("Player1") && !isPlayerOne)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, damagePerTick, damageType);
        }

        if (collision.CompareTag("Player2") && !isPlayerTwo)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, damagePerTick, damageType);
        }

        if (collision.CompareTag("Player3") && !isPlayerThree)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, damagePerTick, damageType);
        }

        if (collision.CompareTag("Player4") && !isPlayerFour)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, damagePerTick, damageType);
        }

        if (collision.CompareTag("Player5") && !isPlayerFive)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, damagePerTick, damageType);
        }

        if (collision.CompareTag("Player6") && !isPlayerSix)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, damagePerTick, damageType);
        } 
        
        if (collision.CompareTag("Target"))
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, damagePerTick, damageType);
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
