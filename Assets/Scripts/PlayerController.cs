using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private InputAction movementAction;

    
    [SerializeField] private float speed;
    private Vector2 movementDirection;
    private Rigidbody2D rb2d;
    private PlayerStats stats;

    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        stats = GetComponentInParent<PlayerStats>();
        movementAction = playerInput.actions["Movement"];
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stats.IsDead)
        {
            if (speed != stats.Speed)
            {
                speed = stats.Speed;
            }

            movementDirection = movementAction.ReadValue<Vector2>().normalized;
        }
    }

    private void FixedUpdate()
    {
        if (!stats.IsDead)
        {
            if (!GetComponent<StatusManager>().OnStunned)
            {
                rb2d.velocity = movementDirection * speed * Time.deltaTime;
            }
        }
    }
}
