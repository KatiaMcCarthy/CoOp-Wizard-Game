using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//on the child object, will refer to the parent
public class Haste : MonoBehaviour
{
    [SerializeField] private float movementSpeedBuff;
    [SerializeField] private float attackSpeedBuff;
    [SerializeField] private float duration;

    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilMoveAction;

    [SerializeField] private float cooldown;
    private float hasteTime;

    private float preHasteSpeed;
    private float preHasteAttackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponentInParent<PlayerStats>();
        playerInput = GetComponentInParent<PlayerInput>();
        abilMoveAction = playerInput.actions["AbilMove"];
    }

    private void Update()
    {
        if (abilMoveAction.ReadValue<float>() == 1 && Time.time >= hasteTime)
        {
            Debug.Log("haste");
            StartHaste();

            hasteTime = Time.time + cooldown;
        }
    }

    private void StartHaste()
    {
        preHasteSpeed = stats.Speed;
        preHasteAttackSpeed = stats.AttackSpeed;

        stats.UpdateSpeed(preHasteSpeed * movementSpeedBuff);
        stats.UpdateAttackSpeed(preHasteAttackSpeed / attackSpeedBuff);

        Invoke("EndHaste", duration);
    }   
    
    private void EndHaste()
    {
        stats.UpdateSpeed(preHasteSpeed);
        stats.UpdateAttackSpeed(preHasteAttackSpeed);
    }

}
