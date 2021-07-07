using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    CircleCollider2D handle;
    BoxCollider2D bc;
    public float throwForce = 5f;
    

    private void Start()
    {
        
        player = FindObjectOfType<Player>();
        handle = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EquipKnife(player.throwPoint);
        }
    }


    public void ThrowKnife()
    {
        rb.isKinematic = false;
        bc.enabled = true;
        
        rb.AddForce(transform.parent.parent.right * throwForce);
        transform.parent = null;
        
        StartCoroutine(ResetPickup());
    }

    

    public void EquipKnife(Transform throwPoint)
    {
        //TODO make sure knife is rotated correctly in relation to the player
        bc.enabled = false;
        player.knife = this.transform;
        transform.position = throwPoint.position;
        transform.parent = throwPoint.transform;
        handle.enabled = false;
        rb.isKinematic = true;
    }

    IEnumerator ResetPickup()
    {
        yield return new WaitForSeconds(1f);
        handle.enabled = true;
    }
}
