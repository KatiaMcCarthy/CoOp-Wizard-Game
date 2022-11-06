using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    public float damage;

    public bool IsPlayerOne { get; private set; }
    public bool IsPlayerTwo { get; private set; }
    public bool IsPlayerThree { get; private set; }
    public bool IsPlayerFour { get; private set; }
    public bool IsPlayerFive { get; private set; }
    public bool IsPlayerSix { get; private set; }

    private bool augmented;
    private bool slowed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.transform.up * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectPlayerCollision(collision);
    }

    private void DetectPlayerCollision(Collider2D collision)
    {
        if (collision.CompareTag("Player1") && !IsPlayerOne)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Player2") && !IsPlayerTwo)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Player3") && !IsPlayerThree)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Player4") && !IsPlayerFour)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Player5") && !IsPlayerFive)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Player6") && !IsPlayerSix)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    public void SetPlayer(int number)
    {
        switch (number)
        {
            case 1:
                ResetPlayerAllegiance();
                IsPlayerOne = true;
                break;
            case 2:
                ResetPlayerAllegiance();
                IsPlayerTwo = true;
                break;  
            case 3:
                ResetPlayerAllegiance();
                IsPlayerThree = true;
                break;            
            case 4:
                ResetPlayerAllegiance();
                IsPlayerFour = true;
                break;            
            case 5:
                ResetPlayerAllegiance();
                IsPlayerFive = true;
                break;            
            case 6:
                ResetPlayerAllegiance();
                IsPlayerSix = true;
                break;
            default:
                break;
        }
    }

    private void ResetPlayerAllegiance()
    {
        IsPlayerOne = false;
        IsPlayerTwo = false;
        IsPlayerThree = false;
        IsPlayerFour = false;
        IsPlayerFive = false;
        IsPlayerSix = false;
    }


    public void AugmentProjectile(float ammount)
    {
        if (!augmented)
        {
            damage = damage * ammount;
            speed = speed * ammount;
            augmented = true;
        }
    }

    public void SlowProjectile(float ammount)
    {
        if (!slowed)
        {
            speed = speed * ammount;
            slowed = true;
        }
    }
}
