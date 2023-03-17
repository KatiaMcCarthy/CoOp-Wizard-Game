using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityFireWall : MonoBehaviour
{
    [SerializeField] private float duration;

    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilEnviroAction;

    [SerializeField] private float cooldown;
    private float firewallTime;

    private Transform mouseLocation;
    [SerializeField] private GameObject fireWall;

    private GameObject spawnedFireWall;

    private bool bSpawnedWall;

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

        if (abilEnviroAction.ReadValue<float>() == 1 && Time.time >= firewallTime)
        {
            Debug.Log("firewall");
            mouseLocation = GetComponentInParent<MouseIcon>().Icon;
            SpawnWall();
            firewallTime = Time.time + cooldown;
        }
    }

    private void SpawnWall()
    {
        if (spawnedFireWall == false)
        {

            spawnedFireWall = Instantiate(fireWall, mouseLocation.position, mouseLocation.rotation);

            spawnedFireWall.GetComponent<FireWall>().SetPlayer(GetComponentInParent<PlayerStats>().PlayerID);

            Invoke("DestroyWall", duration);
        }
    }

    private void DestroyWall()
    {
        DestroySpawnedWall(spawnedFireWall);
    }

    private void DestroySpawnedWall(GameObject spawnedWall)
    {
        bSpawnedWall = false;
        Destroy(spawnedWall);
    }
}
