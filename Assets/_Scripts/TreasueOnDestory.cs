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
        AmountToSpawn = Random.Range(1, 5);
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        
        for (int i = 0; i < AmountToSpawn; i++)
        {
            SpawnTreasure();

        }
        rb.AddForce(Vector2.up * .5f);
        
    }

    public void SpawnTreasure()
    {
        int randTreasure = Random.Range(0, treasures.Length);
        Instantiate(treasures[randTreasure], transform.position, Quaternion.identity);
    }
}
