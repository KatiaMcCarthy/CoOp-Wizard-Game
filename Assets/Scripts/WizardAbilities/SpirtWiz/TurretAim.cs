using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    [SerializeField] private SummonStats stats;
    [SerializeField] private CircleCollider2D rangeCollider;
    [SerializeField] private Transform art;

    private List<GameObject> potentialTargets = new List<GameObject>();

    public Transform target;

    private void Start()
    {
        rangeCollider.radius = stats.SummonAttackRange;
    }

    private void GetTarget()
    {
        target = GetNearestTarget(potentialTargets);
        if(target != null)
        Debug.Log(target.name);
    }

    private void Update()
    {
        if (target != null)
        {
            RotateTurret();
        }
    }

    private void RotateTurret()
    {
        float AngleRad = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
    }


    //use this to get potential targets, when something enters range, add it to the list of potential targets, when it leaves remove it form the list
    private void OnTriggerEnter2D(Collider2D collision)
    {
        potentialTargets.Add(collision.gameObject);
        GetTarget();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GetTarget();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        potentialTargets.Remove(collision.gameObject);
        GetTarget();
    }

    public Transform GetNearestTarget(List<GameObject> potentialTargets)
    {
        
        float smallestDistance = Mathf.Infinity;
        Transform nearestGameObject = null;

        foreach (var go in potentialTargets)
        {
            if(go.GetComponent<Projectile>())
            {
                return null;
            }

            if(go.GetComponentInParent<PlayerStats>() != null  && go.GetComponentInParent<PlayerStats>().PlayerID == stats.OwnerID)
            {
                return null;
            }

            var distance = Vector2.Distance(transform.position, go.transform.position);

            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                nearestGameObject = go.transform;
            }
        }

        return nearestGameObject;
    }
}
