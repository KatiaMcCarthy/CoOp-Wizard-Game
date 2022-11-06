using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityBloodPool : MonoBehaviour
{
    [SerializeField] private float duration;

    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilEnviroAction;

    [SerializeField] private float cooldown;
    private float bloodPoolTime;

    private Transform mouseLocation;
    [SerializeField] private GameObject bloodPool;

    private GameObject spawnedBloodPool;

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
        if (abilEnviroAction.ReadValue<float>() == 1 && Time.time >= bloodPoolTime)
        {
            Debug.Log("bloodpool");
            mouseLocation = GetComponentInParent<MouseIcon>().Icon;
            SpawnPool();
            bloodPoolTime = Time.time + cooldown;
        }
    }

    private void SpawnPool()
    {
        if (spawnedBloodPool == false)
        {

            spawnedBloodPool = Instantiate(bloodPool, mouseLocation.position, mouseLocation.rotation);

            spawnedBloodPool.GetComponent<BloodPool>().SetPlayer(GetComponentInParent<PlayerStats>().PlayerID);

            Invoke("DestroyPool", duration);
        }
    }

    private void DestroyPool()
    {
        DestroySpawnedPool(spawnedBloodPool);
    }

    private void DestroySpawnedPool(GameObject spawnedPool)
    {
        bSpawnPool = false;
        Destroy(spawnedPool);
    }
}
