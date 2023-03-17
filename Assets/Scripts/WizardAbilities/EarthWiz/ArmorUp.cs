using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmorUp : MonoBehaviour
{
    [SerializeField] private float armorStrength;
    [SerializeField] private float armorDuration;

    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilMoveAction;

    [SerializeField] private float cooldown;
    private float armorTime;

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

        if (abilMoveAction.ReadValue<float>() == 1 && Time.time >= armorTime)
        {
            Debug.Log("armor up");
            //trigger animation
            ArmorEffect();

            armorTime = Time.time + cooldown;
        }
    }

    private void ArmorEffect()
    {
        GetComponent<Health>().GainTempHealth(armorStrength, armorDuration);
    }
}
