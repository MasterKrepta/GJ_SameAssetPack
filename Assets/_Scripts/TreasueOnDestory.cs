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
        AmountToSpawn = Random.Range(0, 3);
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        int randTreasure = Random.Range(0, treasures.Length);
        for (int i = 0; i < AmountToSpawn; i++)
        {
            Instantiate(treasures[randTreasure], transform.position, Quaternion.identity);

        }
        rb.AddForce(Vector2.up * .5f);
        
    }
}
