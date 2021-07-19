using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasueOnDestory : MonoBehaviour
{
    public GameObject[] treasures;
    public float AmountToSpawn;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        AmountToSpawn = UnityEngine.Random.Range(1, 5);
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        SpawnTreasure();
        rb.AddForce(Vector2.up * .5f);
        
    }

    public void SpawnTreasure()
    {
        for (int i = 0; i < AmountToSpawn; i++)
        {
            int randTreasure = UnityEngine.Random.Range(0, treasures.Length);
            GameObject t = Instantiate(treasures[randTreasure], transform.position, Quaternion.identity);
            AddRandomforce(t);
        }
    
    }

    private void AddRandomforce(GameObject t)
    {
        Rigidbody2D rb = t.GetComponent<Rigidbody2D>();
        float randomDir = UnityEngine.Random.Range(.25f, 1f);
        Vector2 force = t.transform.up;
        force = new Vector2(force.x * randomDir, 1);
        rb.AddForce(force * randomDir);
    }
}
