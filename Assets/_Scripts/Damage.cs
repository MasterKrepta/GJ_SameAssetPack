using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float dmg = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{this.gameObject} hit { collision.name}");
        var health = collision.GetComponent<IDamagable>();
        if (health != null)
        {
            health.TakeDamage(dmg);
        }
    }
}
