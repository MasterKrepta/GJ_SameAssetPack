using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryPotion : MonoBehaviour, ICollect
{
    public float potionAmount = 5f;
    public GameObject curseEffect, buffEffect;
    
    public void Pickup(PlayerPickups player)
    {
        var fate = TestOfFate();

        if (fate == 1 ) // CURSE
        {
            player.GetComponent<PlayerHealth>().TakeDamage(potionAmount);
            Instantiate(curseEffect, new Vector2(transform.position.x, -1.75f), Quaternion.identity);
        }
        else
        {
            player.GetComponent<PlayerHealth>().Heal(potionAmount);
            Instantiate(buffEffect, new Vector2(transform.position.x, -1.75f), Quaternion.identity);
            //Buff
        }
    }

    private int TestOfFate()
    {
        int result = 1;
        //TODO Random Chance based on percentages

        return result;
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
