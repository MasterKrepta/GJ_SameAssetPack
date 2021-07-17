using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    CircleCollider2D handle;
    CircleCollider2D damage;
    BoxCollider2D bc;
    SpriteRenderer sr;
    public float throwForce = 5f;
    

    private void Start()
    {
        
        player = FindObjectOfType<Player>();
        handle = GetComponent<CircleCollider2D>();
        damage = transform.GetChild(0).GetComponent<CircleCollider2D>();
        //damage.enabled = false; 

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EquipKnife(player.throwPoint);
            damage.enabled = false;
        }
    }


    public void ThrowKnife()
    {
        sr.enabled = true;
        rb.isKinematic = false;
        bc.enabled = true;
        
        rb.AddForce(transform.parent.parent.right * throwForce);
        transform.rotation = transform.parent.parent.rotation; //! make sure knife is rotated correctly
        transform.parent = null;
        
        StartCoroutine(ResetPickup());
        StartCoroutine(ToggleDamage());
    }

    

    public void EquipKnife(Transform throwPoint)
    {
        
        sr.enabled = false;
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

    IEnumerator ToggleDamage()
    {
        damage.enabled = true;
        yield return new WaitForSeconds(1f);
        damage.enabled = false;
    }
}
