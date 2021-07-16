using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollect
{
    public float potionAmount = 5f;
    public void Pickup(PlayerPickups player)
    {
        player.GetComponent<PlayerHealth>().Heal(potionAmount);
    }

    
}
