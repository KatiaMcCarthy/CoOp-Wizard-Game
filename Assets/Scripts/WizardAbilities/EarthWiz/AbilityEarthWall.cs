using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityEarthWall : MonoBehaviour
{
    [SerializeField] private float duration;

    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilEnviroAction;

    [SerializeField] private float cooldown;
    private float earthWallTime;

    private Transform mouseLocation;
    [SerializeField] private GameObject earthWall;

    private GameObject spawnedEarthWall;

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

        if (abilEnviroAction.ReadValue<float>() == 1 && Time.time >= earthWallTime)
        {
            Debug.Log("earth wall");
            mouseLocation = GetComponentInParent<MouseIcon>().Icon;
            SpawnWall();
            earthWallTime = Time.time + cooldown;
        }
    }

    private void SpawnWall()
    {
        if (spawnedEarthWall == false)
        {

            spawnedEarthWall = Instantiate(earthWall, mouseLocation.position, mouseLocation.rotation);

            Invoke("DestroyWall", duration);
        }
    }

    private void DestroyWall()
    {
        DestroySpawnedWall(spawnedEarthWall);
    }

    private void DestroySpawnedWall(GameObject spawnedWall)
    {
        bSpawnedWall = false;
        Destroy(spawnedWall);
    }
}
