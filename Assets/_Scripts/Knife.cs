using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    CircleCollider2D handle;
    public float throwForce = 5f;
    

    private void Start()
    {
        
        player = FindObjectOfType<Player>();
        handle = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            handle.enabled = false;
            rb.gravityScale = 0;
            EquipKnife(player.throwPoint);
            
        }
    }


    public void ThrowKnife()
    {
        Debug.Log("throw");
        rb.gravityScale = 1;
        
        rb.AddForce(transform.parent.parent.right * throwForce);
        transform.parent = null;
        StartCoroutine(ResetPickup());
    }

    

    public void EquipKnife(Transform throwPoint)
    {
        Debug.Log("pickup");
        player.knife = this.transform;
        transform.parent = throwPoint.transform;
        this.transform.position = transform.parent.position;
        
        
    }

    IEnumerator ResetPickup()
    {
        yield return new WaitForSeconds(1f);
        handle.enabled = true;
    }
}
