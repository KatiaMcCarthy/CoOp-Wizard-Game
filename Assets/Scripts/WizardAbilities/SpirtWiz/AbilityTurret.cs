using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityTurret : MonoBehaviour
{
    [SerializeField] private float duration;

    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilEnviroAction;

    [SerializeField] private float cooldown;
    private float spiritTurretTime;

    private Transform mouseLocation;
    [SerializeField] private GameObject spirtTurret;

    private GameObject spawnedSpirtTurret;

    private bool bSpawnedTurret;

    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponentInParent<PlayerStats>();
        playerInput = GetComponentInParent<PlayerInput>();
        abilEnviroAction = playerInput.actions["AbilEnviro"];
    }

    private void Update()
    {
        if (stats.IsDead) { return; }

        if (abilEnviroAction.ReadValue<float>() == 1 && Time.time >= spiritTurretTime)
        {
            Debug.Log("spirt turret");
            mouseLocation = GetComponentInParent<MouseIcon>().Icon;
            SpawnSpirtTurret();
            spiritTurretTime = Time.time + cooldown;
        }
    }

    private void SpawnSpirtTurret()
    {
        if (spawnedSpirtTurret == false)
        {

            spawnedSpirtTurret = Instantiate(spirtTurret, mouseLocation.position, mouseLocation.rotation);

            spawnedSpirtTurret.GetComponent<SummonStats>().UpdateOwnerID(GetComponentInParent<PlayerStats>().PlayerID);

            spawnedSpirtTurret.GetComponent<SummonedInitalize>().Initalize();

            Invoke("DestroyTurret", duration);
        }
    }

    private void DestroyTurret()
    {
        DestroySpawnedTurret(spawnedSpirtTurret);
    }

    private void DestroySpawnedTurret(GameObject spawnedTurret)
    {
        bSpawnedTurret = false;
        Destroy(spawnedTurret);
    }
}
