using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPickups bank = collision.GetComponent<PlayerPickups>();
        if (bank != null)
        {
            sr.enabled = false;
            transform.parent = collision.transform;
        }
    }
}
