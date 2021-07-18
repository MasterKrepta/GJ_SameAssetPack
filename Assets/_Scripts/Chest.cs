using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    Animator anim;
    int numToSpawn;
    TreasueOnDestory treasureScript;
    private void Start()
    {
        anim = GetComponent<Animator>();
        treasureScript = GetComponent<TreasueOnDestory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<Key>())
        {
            anim.SetBool("unlocked", true);
            //TODO spawn treasure
            for (int i = 0; i < numToSpawn; i++)
            {
                treasureScript.SpawnTreasure();
            }
            
        }
    }
}
