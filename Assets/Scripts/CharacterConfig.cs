using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharacterConfig", menuName = "ScriptableObjects/CharacterConfig", order = 1)]
public class CharacterConfig : ScriptableObject
{
    public float health;
    public float speed;   
    public float attackSpeed;
    public float damage;
    public GameObject player;
}
