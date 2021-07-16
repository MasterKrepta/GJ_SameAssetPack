using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryPotion : MonoBehaviour, ICollect
{
    public float potionAmount = 5f;
    
    public void Pickup(PlayerPickups player)
    {
        var fate = TestOfFate();

        if (fate == 1 ) // CURSE
        {
            player.GetComponent<PlayerHealth>().TakeDamage(potionAmount);
        }
        else
        {
            player.GetComponent<PlayerHealth>().Heal(potionAmount);
            //Buff
        }
    }

    private int TestOfFate()
    {
        int result = 0;
        //TODO Random Chance based on percentages

        return result;
    }
}
