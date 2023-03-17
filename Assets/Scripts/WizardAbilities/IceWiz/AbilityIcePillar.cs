using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityIcePillar : MonoBehaviour
{
    [SerializeField] private float duration;

    private PlayerStats stats;
    private PlayerInput playerInput;
    private InputAction abilEnviroAction;

    [SerializeField] private float cooldown;
    private float icePillarTime;

    private Transform mouseLocation;
    [SerializeField] private GameObject icePillar;

    private GameObject spawnedIcePillar;

    private bool bSpawnedPillar;

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

        if (abilEnviroAction.ReadValue<float>() == 1 && Time.time >= icePillarTime)
        {
            Debug.Log("Ice Pillar");
            mouseLocation = GetComponentInParent<MouseIcon>().Icon;
            SpawnPillar();
            icePillarTime = Time.time + cooldown;
        }
    }

    private void SpawnPillar()
    {
        if (spawnedIcePillar == false)
        {

            spawnedIcePillar = Instantiate(icePillar, mouseLocation.position, mouseLocation.rotation);

            spawnedIcePillar.GetComponent<IcePillar>().SetPlayer(GetComponentInParent<PlayerStats>().PlayerID);

            Invoke("DestroyPillar", duration);
        }
    }

    private void DestroyPillar()
    {
        DestroySpawnedPillar(spawnedIcePillar);
    }

    private void DestroySpawnedPillar(GameObject spawnedPillar)
    {
        bSpawnedPillar = false;
        Destroy(spawnedPillar);
    }
}
