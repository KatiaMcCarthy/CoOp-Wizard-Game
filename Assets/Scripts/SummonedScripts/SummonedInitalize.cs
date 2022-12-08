using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonedInitalize : MonoBehaviour
{
    [SerializeField] private SummonConfig config;
    private SummonStats stats;
    public void Initalize()
    {
        stats = GetComponent<SummonStats>();

        stats.UpdateHealth(config.health, true);
        stats.UpdateSpeed(config.speed);
        stats.UpdateBaseDamage(config.damage);
        stats.UpdateAttackSpeed(config.attackSpeed);
        stats.UpdateAttackRange(config.attackRange);

        this.gameObject.layer = stats.OwnerID + 5;
        this.gameObject.tag = "Player" + stats.OwnerID;
    }
}
