using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyed : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        StartCoroutine(DisableRB());
    }

   IEnumerator DisableRB()
    {
        yield return new WaitForSeconds(1);
        rb.isKinematic = true;
        collider.enabled = false;
    }
}
