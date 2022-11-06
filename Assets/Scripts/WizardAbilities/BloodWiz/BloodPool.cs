using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPool : MonoBehaviour
{
    [SerializeField] private float healPerTick;
    [SerializeField] private float duration;
    [SerializeField] private int tickCount;
    [SerializeField] private StatusManager.StatusType statusType;

    private bool isPlayerOne;
    private bool isPlayerTwo;
    private bool isPlayerThree;
    private bool isPlayerFour;
    private bool isPlayerFive;
    private bool isPlayerSix;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectPlayerCollsion(collision);
    }

    private void DetectPlayerCollsion(Collider2D collision)
    {
        if (collision.CompareTag("Player1") && isPlayerOne)
        {
            Debug.Log("player one on pool");
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, healPerTick, statusType);
        }

        if (collision.CompareTag("Player2") && isPlayerTwo)
        {
            Debug.Log("player two on pool");
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, healPerTick, statusType);
        }

        if (collision.CompareTag("Player3") && isPlayerThree)
        {
            Debug.Log("player three on pool");
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, healPerTick, statusType);
        }

        if (collision.CompareTag("Player4") && isPlayerFour)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, healPerTick, statusType);
        }

        if (collision.CompareTag("Player5") && isPlayerFive)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, healPerTick, statusType);
        }

        if (collision.CompareTag("Player6") && isPlayerSix)
        {
            collision.GetComponent<StatusManager>().StartStaus(duration, tickCount, healPerTick, statusType);
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
