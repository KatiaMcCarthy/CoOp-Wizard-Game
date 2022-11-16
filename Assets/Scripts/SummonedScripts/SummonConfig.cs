using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SummonConfig", menuName = "ScriptableObjects/SummonConfig", order = 2)]
public class SummonConfig : ScriptableObject
{
    public float health;
    public float speed;
    public float attackSpeed;
    public float attackRange;
    public float damage;
}