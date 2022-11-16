using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityKnockback : MonoBehaviour
{
    [SerializeField] private float knockbackStrength;
    [SerializeField] private float knockbackRadius;
    [SerializeField] private float knockbackDuration;
    [SerializeField] private LayerMask knockbackTargets;
    
    private Transform mouseLocation;
    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilMoveAction;

    [SerializeField] private float cooldown;
    private float knockbackTime;

    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponentInParent<PlayerStats>();
        playerInput = GetComponentInParent<PlayerInput>();
        abilMoveAction = playerInput.actions["AbilMove"];
    }

    private void Update()
    {
        if (abilMoveAction.ReadValue<float>() == 1 && Time.time >= knockbackTime)
        {
            Debug.Log("knockback");
            mouseLocation = GetComponentInParent<MouseIcon>().Icon;
            //trigger animation
            KnockbackEffect();

            knockbackTime = Time.time + cooldown;
        }
    }

    private void KnockbackEffect()
    {
        Collider2D[] enemiesToHit = Physics2D.OverlapCircleAll(mouseLocation.position, knockbackRadius, knockbackTargets);

        foreach (var enemy in enemiesToHit)
        {
            // knock them back basied on thier location in relationship to mouse location
            Vector2 dir = enemy.transform.position - mouseLocation.position;
            dir = dir.normalized;

            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            enemy.GetComponent<Rigidbody2D>().inertia = 0;

            //stuns the player while they are knockedback
            enemy.GetComponent<StatusManager>().StartStaus(dotDuration: knockbackDuration, tickCount: 1, statusAmmount: 0, StatusManager.StatusType.Stun);

            enemy.GetComponent<Rigidbody2D>().AddForce(dir * knockbackStrength, ForceMode2D.Impulse);

            Debug.Log("should apply knockback");
        }
    }
}