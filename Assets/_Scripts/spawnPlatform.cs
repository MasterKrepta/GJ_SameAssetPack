using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlatform : MonoBehaviour
{
   
    public GameObject Enemy;
    
    private void OnEnable()
    {
        InvokeRepeating("Spawn", 1, 60);
    }
    
    void Spawn()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    } 
}
