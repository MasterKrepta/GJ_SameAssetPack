using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollect
{
    public float potionAmount = 5f;
    public GameObject potionEffect;
    public void Pickup(PlayerPickups player)
    {
        player.GetComponent<PlayerHealth>().Heal(potionAmount);
        Instantiate(potionEffect, new Vector2(transform.position.x, -1.75f), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerPickups bank = collision.GetComponent<PlayerPickups>();
        if (bank != null)
        {
            Pickup(bank);
            Destroy(gameObject);
        }
    }

}
