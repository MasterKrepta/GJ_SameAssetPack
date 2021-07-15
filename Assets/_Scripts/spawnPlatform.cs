using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlatform : MonoBehaviour
{
    public GameObject Enemy;
    
    private void OnEnable()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }


}
