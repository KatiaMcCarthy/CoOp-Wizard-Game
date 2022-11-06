using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IceDash : MonoBehaviour
{
    [SerializeField] private float movementSpeedBuff;
    [SerializeField] private float duration;

    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilMoveAction;

    [SerializeField] private float cooldown;
    private float dashTime;

    private float preDashSpeed;

    [SerializeField] private float slowStrength;
    [SerializeField] private float slowDuration;
    [SerializeField] private float slowRadius;
    [SerializeField] private LayerMask slowTargets;

    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponentInParent<PlayerStats>();
        playerInput = GetComponentInParent<PlayerInput>();
        abilMoveAction = playerInput.actions["AbilMove"];
    }

    private void Update()
    {
        if (abilMoveAction.ReadValue<float>() == 1 && Time.time >= dashTime)
        {
            Debug.Log("ice dash");
            StartDash();

            dashTime = Time.time + cooldown;
        }
    }

    private void StartDash()
    {
        preDashSpeed = stats.Speed;

        stats.UpdateSpeed(preDashSpeed * movementSpeedBuff);

        //apply a slow to everyone around you, that is not you
        ApplySlow();

        Invoke("EndHaste", duration);
    }

    private void ApplySlow()
    {
        //set up layermask, how to make it flip to 0
        var bitMask = ~((1 << GetComponentInParent<PlayerStats>().PlayerID + 5)
            | (1 << 0)
            | (1 << 1)
            | (1 << 2)
            | (1 << 3)
            | (1 << 4)
            | (1 << 5)
            | (1 << 12)
            | (1 << 13)
            | (1 << 14)
            | (1 << 15)
            | (1 << 16)
            | (1 << 17)
            | (1 << 18))
            ;

        slowTargets = bitMask;

        Collider2D[] enemiesToHit = Physics2D.OverlapCircleAll(transform.position, slowRadius, slowTargets);

        foreach (var enemy in enemiesToHit)
        {
            enemy.GetComponent<StatusManager>().StartStaus(slowDuration, 1, slowStrength, StatusManager.StatusType.Slow);
        }
    }

    private void EndHaste()
    {
        stats.UpdateSpeed(preDashSpeed);
    }

}
