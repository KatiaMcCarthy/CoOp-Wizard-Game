using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityVortex : MonoBehaviour
{
    [SerializeField] private float duration;

    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilEnviroAction;

    [SerializeField] private float cooldown;
    private float vortexTime;

    private Transform mouseLocation;
    [SerializeField] private GameObject vortex;

    private GameObject spawnedVortex;

    private bool bSpawnPool;

    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponentInParent<PlayerStats>();
        playerInput = GetComponentInParent<PlayerInput>();
        abilEnviroAction = playerInput.actions["AbilEnviro"];
    }

    private void Update()
    {
        if (!stats.IsDead)
        {
            if (abilEnviroAction.ReadValue<float>() == 1 && Time.time >= vortexTime)
            {
                Debug.Log("vortex");
                mouseLocation = GetComponentInParent<MouseIcon>().Icon;
                SpawnVortex();
                vortexTime = Time.time + cooldown;
            }
        }
    }

    private void SpawnVortex()
    {
        if (spawnedVortex == false)
        {

            spawnedVortex = Instantiate(vortex, mouseLocation.position, mouseLocation.rotation);

            Invoke("DestroyVortex", duration);
        }
    }

    private void DestroyVortex()
    {
        DestroySpawnedVortex(spawnedVortex);
    }

    private void DestroySpawnedVortex(GameObject spawnedVortex)
    {
        bSpawnPool = false;
        Destroy(spawnedVortex);
    }
}
