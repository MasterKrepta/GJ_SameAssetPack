using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour, ICollect
{
    public int treasureAmount = 1;
    public void Pickup(PlayerPickups player)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        PlayerPickups bank = collision.GetComponent<PlayerPickups>();
        if (bank != null)
        {
            bank.GetCoin(treasureAmount);
            Destroy(gameObject);
        }
    }
}
