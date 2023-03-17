using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityIntagibility : MonoBehaviour
{

    [SerializeField] private float movementSpeedBuff;
    [SerializeField] private float duration;

    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilMoveAction;

    [SerializeField] private float cooldown;
    private float dashTime;

    private float preDashSpeed;

    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponentInParent<PlayerStats>();
        playerInput = GetComponentInParent<PlayerInput>();
        abilMoveAction = playerInput.actions["AbilMove"];
    }

    private void Update()
    {
        if (stats.IsDead) { return; }

        if (abilMoveAction.ReadValue<float>() == 1 && Time.time >= dashTime)
        {
            Debug.Log("spirt dash");
            StartDash();

            dashTime = Time.time + cooldown;
        }
    }

    private void StartDash()
    {
        preDashSpeed = stats.Speed;

        stats.UpdateSpeed(preDashSpeed * movementSpeedBuff);

        this.GetComponent<StatusManager>().UpdateIFrameStatus(true);

        Invoke("EndHaste", duration);
    }

    private void EndHaste()
    {
        stats.UpdateSpeed(preDashSpeed);
        this.GetComponent<StatusManager>().UpdateIFrameStatus(false);
    }

}
