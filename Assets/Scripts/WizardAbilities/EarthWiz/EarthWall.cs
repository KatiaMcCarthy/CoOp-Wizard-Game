using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }
    }
}

